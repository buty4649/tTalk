using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace tTalk
{
    class TwitterRequestOAuth : TwitterRequest
    {
        private string _consumer_key = "";
        private string _consumer_secret = "";
        private string _access_token = "";
        private string _access_token_secret = "";
        private string _twitter_oauth_request_token = @"https://twitter.com/oauth/request_token";
        private string _twitter_oauth_authorize = @"https://twitter.com/oauth/authorize";
        private string _twitter_oauth_access_token = @"https://twitter.com/oauth/access_token";
        Random _rnd = new Random();

        public string AccessToken
        {
            get { return _access_token; }
        }

        public string AccessTokenSecret
        {
            get { return _access_token_secret; }
        }

        public TwitterRequestOAuth(string access_token, string access_token_secret)
        {
            _access_token = access_token;
            _access_token_secret = access_token_secret;

            /* おまじない */
            if (ServicePointManager.Expect100Continue)
            {
                ServicePointManager.Expect100Continue = false;
            }
        }

        public override HttpWebResponse Request(string api_suffix)
        {
            return Request(api_suffix, new Dictionary<string, string>());
        }

        public override HttpWebResponse Request(string api_suffix, IDictionary<string, string> request_parms)
        {
            /* 初回のみアクセストークンを取得する */
            if (_access_token == "" || _access_token_secret == "")
            {
                /* パラメータを作成 */
                SortedDictionary<string, string> parms = new SortedDictionary<string, string>();

                /* リクエストトークンを取得*/
                WebResponse xauth_response = OAuthRequest(_twitter_oauth_request_token, "GET", parms);
                Dictionary<string, string> xauth_response_parms = ParseOAuthResponce(new StreamReader(xauth_response.GetResponseStream()));

                _access_token = xauth_response_parms["oauth_token"];
                _access_token_secret = xauth_response_parms["oauth_token_secret"];


                /* 確認ボックスを表示する */
                DialogResult result = MessageBox.Show(
                    "OKボタンを押すと、デフォルトのブラウザが起動します。\r\n" +
                    "起動したブラウザにてTwitterへログインを行ない、アクセスを許可してください。\r\n" +
                    "その後、表示される暗証番号(PIN)を入力してください。",
                    "確認", MessageBoxButtons.OKCancel
                );
                if (result == DialogResult.Cancel)
                {
                    throw new Exception("ユーザによってキャンセルされました");
                }

                /* 認証ページを表示する */
                StringBuilder xauth_request_url = new StringBuilder(_twitter_oauth_authorize);
                xauth_request_url.AppendFormat("?oauth_token={0}", _access_token);
                System.Diagnostics.Process.Start(xauth_request_url.ToString());

                /* 暗証番号(PIN)入力ダイアログを表示する */
                OAuth oauth = new OAuth();
                if (oauth.ShowDialog() != DialogResult.OK)
                {
                    _access_token = "";
                    _access_token_secret = "";
                    throw new Exception("OAuth認証に失敗しました");
                }


                /* アクセストークンを取得 */
                parms["oauth_verifier"] = oauth.PIN;

                xauth_response = OAuthRequest(_twitter_oauth_access_token, "POST", parms);
                xauth_response_parms = ParseOAuthResponce(new StreamReader(xauth_response.GetResponseStream()));

                _access_token = xauth_response_parms["oauth_token"];
                _access_token_secret = xauth_response_parms["oauth_token_secret"];
            }

            /* リクエストURLを作成する */
            string request_url = Url(api_suffix);

            /* リクエストを発行 */
            return (HttpWebResponse)OAuthRequest(request_url, "GET", request_parms);
        }


        /// <summary>
        /// OAuth用いてWebリクエストを発行する
        /// </summary>
        /// <param name="uri">リクエストURI</param>
        /// <param name="request_method">HTTPのリクエストメソッド</param>
        /// <param name="parms">パラメータ</param>
        /// <param name="signature_type">シグネチャの暗号化形式</param>
        /// <returns>リクエストの結果</returns>
        private WebResponse OAuthRequest(string uri, string request_method, IDictionary<String, String> parms)
        {
            String request_parms;
            WebRequest request;

            // ソートしたパラメータを生成する
            SortedDictionary<String, String> sorted_parms = new SortedDictionary<String, String>(parms);

            // OAuthパラメータを生成する
            GenerateOAuthParameters(sorted_parms);

            // リクエストパラメータを生成する
            request_parms = GenerateRequestParameters(sorted_parms);

            // シグネチャを計算
            request_parms += "&" + ComputeSignature(request_method, uri, request_parms);

            // Webレスポンスを生成
            if (request_method == "GET")
            {
                // リクエストを作成
                StringBuilder request_uri = new StringBuilder(uri);
                request_uri.AppendFormat("?{0}", request_parms);
                request = (HttpWebRequest)WebRequest.Create(request_uri.ToString());
            }
            else
            {
                // バイト列を取得
                byte[] request_parms_bytes = Encoding.ASCII.GetBytes(request_parms);

                //それ意外の場合
                request = WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = request_parms_bytes.Length;

                // リクエストパラメータを書き込む
                Stream st = request.GetRequestStream();
                st.Write(request_parms_bytes, 0, request_parms_bytes.Length);
                st.Close();
            }

            // サーバにリクエストを投げる
            return request.GetResponse();
        }

        /// <summary>
        /// OAuth認証に必要なパラメータを生成する。
        /// ただし、oauth_signatureは含まない。
        /// </summary>
        /// <param name="parms">パラメータの生成先</param>
        /// <param name="type">署名の暗号化方式</param>
        /// <returns>パラメータを返す</returns>
        private void GenerateOAuthParameters(SortedDictionary<String, String> parms)
        {
            // OAuthパラメータを追加
            parms["oauth_consumer_key"] = _consumer_key;
            parms["oauth_nonce"] = GenerateNonce();
            parms["oauth_timestamp"] = Timestamp().ToString();
            parms["oauth_version"] = "1.0";
            parms["oauth_signature_method"] = "HMAC-SHA1";

            // アクセストークンが空文字意外の場合のみ追加
            if (_access_token != "")
            {
                parms["oauth_token"] = _access_token;
            }
            return;
        }

        /// <summary>
        /// HTTPのリクエストパラメータを生成する
        /// </summary>
        /// <param name="parms">生成するパラメータ一覧</param>
        /// <returns>生成したパラメータ</returns>
        private String GenerateRequestParameters(SortedDictionary<String, String> parms)
        {
            String query = "";
            Encoding enc = Encoding.ASCII;

            // クエリーパラメータを作る
            foreach (String key in parms.Keys)
            {
                // URLエンコードして変数に追加
                query += HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(parms[key]) + "&";
            }

            // 末尾の&を削除
            return query.Remove(query.Length - 1);
        }

        /// <summary>
        /// OAuthシグネチャを生成
        /// ex. oauth_signature=**********
        /// </summary>
        /// <param name="request_method">HTTPリクエストの種類(GET, POST, HEADなど)</param>
        /// <param name="uri">リクエストURI</param>
        /// <param name="request_parms">リクエストパラメータ</param>
        /// <param name="signature_method">シグネチャの暗号化形式</param>
        /// <returns>oauth_signature=*** な文字列</returns>
        private String ComputeSignature(string request_method, string uri, String request_parms)
        {
            String signature;
            String request_uri;
            Encoding enc = Encoding.ASCII;

            // メソッド文字を追加
            signature = request_method.ToUpper();
            signature += "&";

            // リクエストURIを正規化＋"?"以降を削除
            request_uri = uri;

            // 正規化したURIを追加
            signature += HttpUtility.UrlEncode(request_uri);
            signature += "&";

            // パラメータ内の"="と"&"をエンコードして追加
            signature += HttpUtility.UrlEncode(request_parms);

            // URLエンコードした文字を大文字化する
            signature = System.Text.RegularExpressions.Regex.Replace(signature, "(%[0-9a-fA-F][0-9a-fA-F])", (m) =>
            {
                return m.Groups[0].Value.ToUpper();
            });

            // ハッシュ値を計算して文字列を返す
            // SHA1エンジンを生成
            HMACSHA1 hmacsha1 = new HMACSHA1(enc.GetBytes(_consumer_secret + "&" + _access_token_secret));

            // ハッシュ値を計算
            byte[] hash = hmacsha1.ComputeHash(enc.GetBytes(signature));

            // Base64 + URIエンコード
            signature = HttpUtility.UrlEncode(Convert.ToBase64String(hash));

            return "oauth_signature=" + signature;
        }

        /// <summary>
        /// OAuthレスポンスの結果をパースする
        /// </summary>
        /// <param name="st">WebResponceのストリーム</param>
        /// <returns>パースした結果</returns>
        private Dictionary<String, String> ParseOAuthResponce(StreamReader st)
        {
            Dictionary<String, String> responce = new Dictionary<String, String>();

            // &で分割して読み込む
            foreach (String value in st.ReadLine().Split('&'))
            {
                String[] v = value.Split('=');
                responce[v[0]] = v[1];
            }

            return responce;
        }

        /// <summary>
        /// 一時的な文字列を生成する
        /// </summary>
        /// <returns></returns>
        private String GenerateNonce()
        {
            const String key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            String nonce = "";

            // ランダムな文字列を生成する
            for (int i = 0; i < 32; i++)
            {
                nonce += key[_rnd.Next(key.Length)];
            }

            return nonce;
        }

        /// <summary>
        /// 現在の時刻を返す
        /// </summary>
        /// <returns>現在の時刻のエポックタイム</returns>
        private static long Timestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }
    }
}
