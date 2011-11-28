using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace tTalk
{
    abstract class TwitterRequest
    {
        internal bool _is_login = false;
        internal bool _use_ssl = true;
        private const string _twitter_api_host = "api.twitter.com";
        private const int _twitter_api_version = 1;
        private const string _twitter_api_login_suffix = "account/verify_credentials.xml";

        public bool isLogin
        {
            get
            {
                return _is_login;
            }
        }

        public bool useSSL
        {
            get
            {
                return _use_ssl;
            }
            set
            {
                _use_ssl = value;
            }
        }

        public bool Login(out string username)
        {
            username = "";

            try
            {
                /* ログインリクエストを発行 */
                HttpWebResponse response = Request(_twitter_api_login_suffix);

                /* ステータスコードでログインチェック */
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _is_login = true;

                    /* レスポンスからユーザ名を取得 */
                    XmlTextReader xml = new XmlTextReader(response.GetResponseStream());
                    while (xml.Read())
                    {
                        /* user/screen_name 要素のみ抽出 */
                        if (xml.LocalName == "screen_name")
                        {
                            username = xml.ReadString();
                        }
                    }
                }
            }
            catch
            {
            }
            return _is_login;
        }

        internal string Url()
        {
            StringBuilder url = new StringBuilder(_use_ssl ? "https://" : "http://");
            url.Append(_twitter_api_host);
            url.Append("/");
            return url.ToString();
        }

        internal string Url(string api_suffix)
        {
            StringBuilder url = new StringBuilder(_use_ssl ? "https://" : "http://");
            url.AppendFormat("{0}/{1}/{2}", _twitter_api_host, _twitter_api_version, api_suffix);
            return url.ToString();
        }

        public abstract HttpWebResponse Request(string api_suffix);
        public virtual HttpWebResponse Request(string api_suffix, IDictionary<string, string> request_parms)
        {
            SortedDictionary<string, string> p = new SortedDictionary<string, string>(request_parms);
            
            /* api_suffix にパラメータを追加 */
            StringBuilder s = new StringBuilder(api_suffix);
            bool is_first = false;
            foreach (string k in p.Keys)
            {
                if (!is_first)
                {
                    is_first = true;
                    s.AppendFormat("?{0}={1}", k, p[k]);
                }
                else
                {
                    s.AppendFormat("&{0}={1}", k, p[k]);
                }
            }
            return Request(s.ToString());
        }
    }
}
