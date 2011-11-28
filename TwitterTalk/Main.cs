using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.IO;


namespace tTalk
{
    public partial class Main : Form
    {
        const string _twitter_api_home_timeline = "statuses/friends_timeline.json";
        const string _twitter_api_mentions = "statuses/mentions.json";
        const string _twitter_api_lists_get = "lists.json";
        const string _twitter_api_lists_subscriptions = "lists/subscriptions.json";
        const string _twitter_api_lists_status = "statuses.json";
        const string _tempfile = "twit.txt";
        string _twitter_access_token = "";
        string _twitter_access_token_secret = "";
        string _default_title = "";
        ulong _last_twit_id = 0;
        TwitterRequest _twRequest = null;

        private byte[] ResizeBytesArray(byte[] input, int len)
        {
            byte[] output = new byte[len];
            int pos = 0;

            for (int i = 0; i < input.Length; i++)
            {
                output[pos] ^= input[i];
                pos++;
                if (pos >= len)
                {
                    pos = 0;
                }
            }
            return output;
        }

        private string Encrypt(string input)
        {
            if (input.Length < 1) return "";

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            byte[] keys = Encoding.Unicode.GetBytes("__TwitterTalk__");
            des.Key = ResizeBytesArray(keys, des.Key.Length);
            des.IV = ResizeBytesArray(keys, des.IV.Length);

            ICryptoTransform enc = des.CreateEncryptor();
            MemoryStream ms = new MemoryStream();
            CryptoStream crypt_st = new CryptoStream(ms, enc, CryptoStreamMode.Write);

            byte[] input_byte = Encoding.Unicode.GetBytes(input);
            byte[] bytes = new byte[4 + 128 + 128 * (input_byte.Length / 128)];

            /* パディングする */
            /* 先頭4バイトはサイズ */
            bytes[0] = (byte)(input_byte.Length & 0x000000ff);
            bytes[1] = (byte)((input_byte.Length & 0x0000ff00) >> 8);
            bytes[2] = (byte)((input_byte.Length & 0x00ff0000) >> 16);
            bytes[3] = (byte)((input_byte.Length & 0xff000000) >> 24);
            int pos = 4;
            for (int i = 0; i < input_byte.Length; i++)
            {
                bytes[pos] = input_byte[i];
                pos++;
            }
            byte[] random = new byte[bytes.Length - pos];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random);
            for (int i = 0; i < random.Length; i++)
            {
                bytes[pos] = random[i];
                pos++;
            }

            crypt_st.Write(bytes, 0, bytes.Length);
            crypt_st.Close();
            ms.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        private string Decrypt(string input)
        {
            if (input.Length < 1) return "";

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            byte[] keys = Encoding.Unicode.GetBytes("__TwitterTalk__");
            des.Key = ResizeBytesArray(keys, des.Key.Length);
            des.IV = ResizeBytesArray(keys, des.IV.Length);

            ICryptoTransform dec = des.CreateDecryptor();
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(input));
            CryptoStream crypt_st = new CryptoStream(ms, dec, CryptoStreamMode.Read);

            string output;
            try
            {
                /* 最初の4バイトを読み込んでサイズを確認する */
                byte[] buffer = new byte[128];
                crypt_st.Read(buffer, 0, 4);
                int len = (int)(buffer[0] + (buffer[1] << 8) + (buffer[2] << 16) + (buffer[3] << 24));

                /* バッファを作成 */
                byte[] str = new byte[len];

                /* 読み込み */
                crypt_st.Read(str, 0, len);

                /* すべてのストリームを読み出す */
                while (crypt_st.Read(buffer, 0, 128) > 0) ;

                crypt_st.Close();
                ms.Close();
                output = Encoding.Unicode.GetString(str);
            }
            catch
            {
                output = "";
            }

            return output;
        }

        private void LoadSetting()
        {
            /* タブ一枚目の設定 */
            ctl_checkbox_autologin.Checked = tTalk.Properties.Settings.Default.check_auto_login;
            ctl_textbox_softalk.Text = tTalk.Properties.Settings.Default.text_softalk;

            /* タブ二枚目の設定 */
            switch (tTalk.Properties.Settings.Default.twitter_target)
            {
                case 0: ctl_radio_home_timeline.Checked = true; break;
                case 1: ctl_radio_mentions.Checked = true; break;
                case 2: ctl_radio_list.Checked = true; break;
            }
            ctl_label_target_listname.Text = tTalk.Properties.Settings.Default.twitter_target_list_name;

            /* タブ3枚目の設定 */
            ctl_textbox_format.Text = tTalk.Properties.Settings.Default.text_format;
            ctl_checkbox_other.Checked = tTalk.Properties.Settings.Default.check_other;
            ctl_checkbox_replace_url.Checked = tTalk.Properties.Settings.Default.check_replace_url;
            ctl_textbox_replace_url.Text = tTalk.Properties.Settings.Default.text_replace_url;
            ctl_checkbox_reverse.Checked = tTalk.Properties.Settings.Default.check_reverse;

            ctl_updown_count.Value = tTalk.Properties.Settings.Default.num_count;
            ctl_updown_interval.Value = tTalk.Properties.Settings.Default.num_interval;

            _last_twit_id = tTalk.Properties.Settings.Default.num_last_twit_id;

            /* タブ4枚目の設定 */
            ctl_checkbox_startup.Checked = tTalk.Properties.Settings.Default.run_as_startup;
            ctl_checkbox_run_minimize.Checked = tTalk.Properties.Settings.Default.run_minimize;
            ctl_checkbox_softalk_minimize.Checked = tTalk.Properties.Settings.Default.softalk_minimize;
            ctl_checkbox_tasktray.Checked = tTalk.Properties.Settings.Default.tasktray;
            ctl_checkbox_no_tasktray_icon.Checked = tTalk.Properties.Settings.Default.no_tasktray_icon;

            /* OAuth関連 */
            _twitter_access_token = tTalk.Properties.Settings.Default.oauth_access_token;

            /* パスワードの復号化 */
            _twitter_access_token_secret = Decrypt(tTalk.Properties.Settings.Default.oauth_access_token_secret);
        }

        private void SaveSetting()
        {
            /* タブ一枚目の設定 */
            tTalk.Properties.Settings.Default.check_auto_login = ctl_checkbox_autologin.Checked;
            tTalk.Properties.Settings.Default.text_softalk = ctl_textbox_softalk.Text;

            /* タブ二枚目の設定 */
            if (ctl_radio_home_timeline.Checked)
            {
                tTalk.Properties.Settings.Default.twitter_target = 0;
            }
            else if (ctl_radio_mentions.Checked)
            {
                tTalk.Properties.Settings.Default.twitter_target = 1;
            }
            else
            {
                tTalk.Properties.Settings.Default.twitter_target = 2;
            }
            tTalk.Properties.Settings.Default.twitter_target_list_name = ctl_label_target_listname.Text;

            /* タブ三枚目の設定 */
            tTalk.Properties.Settings.Default.text_format = ctl_textbox_format.Text;
            tTalk.Properties.Settings.Default.check_other = ctl_checkbox_other.Checked;
            tTalk.Properties.Settings.Default.check_replace_url = ctl_checkbox_replace_url.Checked;
            tTalk.Properties.Settings.Default.text_replace_url = ctl_textbox_replace_url.Text;
            tTalk.Properties.Settings.Default.check_reverse = ctl_checkbox_reverse.Checked;

            tTalk.Properties.Settings.Default.num_count = decimal.ToInt32(ctl_updown_count.Value);
            tTalk.Properties.Settings.Default.num_interval = decimal.ToInt32(ctl_updown_interval.Value);

            /* タブ4枚目の設定 */
            tTalk.Properties.Settings.Default.run_as_startup = ctl_checkbox_startup.Checked;
            tTalk.Properties.Settings.Default.run_minimize = ctl_checkbox_run_minimize.Checked;
            tTalk.Properties.Settings.Default.softalk_minimize = ctl_checkbox_softalk_minimize.Checked;
            tTalk.Properties.Settings.Default.tasktray = ctl_checkbox_tasktray.Checked;
            tTalk.Properties.Settings.Default.no_tasktray_icon = ctl_checkbox_no_tasktray_icon.Checked;


            /* OAuth関連 */
            tTalk.Properties.Settings.Default.oauth_access_token = _twitter_access_token;

#if !DEBUG
            tTalk.Properties.Settings.Default.num_last_twit_id = _last_twit_id;
#endif

            /* パスワードを暗号化 */
            tTalk.Properties.Settings.Default.oauth_access_token_secret = Encrypt(_twitter_access_token_secret);

            /* 保存 */
            tTalk.Properties.Settings.Default.Save();
        }

        private void StatusCodeCheck(HttpWebResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("リクエストエラー: " + response.StatusCode.ToString());
            }
        }

        private XElement Json2Xml(Stream jsonStream)
        {
            return XElement.Load(JsonReaderWriterFactory.CreateJsonReader(jsonStream, XmlDictionaryReaderQuotas.Max));
        }


        public void Run()
        {
            /* すべてのコントロールのMouseEnterにUpdateInformationを追加する */
            this.MouseEnter += new EventHandler(UpdateInformation);
            SetAllMouseEnter(this);

            /* バージョン情報を取得 */
            AssemblyFileVersionAttribute vers =
                (AssemblyFileVersionAttribute)
                Attribute.GetCustomAttribute(
                    Assembly.GetExecutingAssembly(),
                    typeof(AssemblyFileVersionAttribute)
                    );

            /* ウインドウタイトルにバージョンを含める */
            this.Text += " " + vers.Version + " ";

            /* 今のタイトルを取得 */
            _default_title = this.Text;

            /* 通知アイコンを初期化 */
            ctl_notifyicon.Icon = this.Icon;

            /* 自動ログインを行う */
            if (ctl_checkbox_autologin.Checked &&
                (_twitter_access_token != "" && _twitter_access_token_secret != "")
             )
            {
                /* ログイン後自動実行する？ */
                if (Login() && ctl_checkbox_startup.Checked)
                {
                    /* 実行する */
                    EventExecProcess(null, null);
                }
            }

            /* ウインドウを表示する */
            if (!ctl_checkbox_run_minimize.Checked || !ctl_timer_notify.Enabled ||
                (ctl_timer_notify.Enabled && !ctl_checkbox_tasktray.Checked))
            {
                Show();
            }
            else
            {
                /* タスクアイコンの表示 */
                if (ctl_checkbox_tasktray.Checked && !ctl_checkbox_no_tasktray_icon.Checked)
                {
                    ctl_notifyicon.Visible = true;
                }
            }
        }

        private bool Exec()
        {
            try
            {
                /* 設定を確認 */
                if (ctl_textbox_softalk.Text.Length < 1)
                {
                    throw new Exception("SofTalkのパスが設定されていません");
                }

                /* 追加パラメータの作成 */
                Dictionary<string, string> parms = new Dictionary<string, string>();
                parms["count"] = ctl_updown_count.Value.ToString();
                if (_last_twit_id > 0)
                {
                    parms["since_id"] = _last_twit_id.ToString();
                }

                /* リクエストを発行する */
                HttpWebResponse response;
                if (ctl_radio_home_timeline.Checked)
                {
                    /* home_timeline を取得 */
                    response = _twRequest.Request(_twitter_api_home_timeline, parms);
                }
                else if (ctl_radio_mentions.Checked)
                {
                    /* mentions を取得 */
                    response = _twRequest.Request(_twitter_api_mentions, parms);
                }
                else
                {
                    /* リストを取得 */
                    string target_list = ctl_label_target_listname.Text;

                    /* @ を削除 */
                    target_list.Replace("@", "");

                    /* listの所有者と名前をパラメータに追加 */
                    StringBuilder suffix = new StringBuilder();
                    if (target_list.IndexOf('/') == -1)
                    {
                        /* 自分のリストだった */
                        suffix.AppendFormat("{0}/lists/{1}/", ctl_label_username.Text, target_list);
                    }
                    else
                    {
                        /* 他人のリストだった */
                        string[] s = target_list.Split('/');
                        suffix.AppendFormat("{0}/lists/{1}/", s[0], s[1]);
                    }
                    /* サフィックスを追加 */
                    suffix.Append(_twitter_api_lists_status);

                    /* リストを取得 */
                    response = _twRequest.Request(suffix.ToString(), parms);
                }

                /* ステータスコードのチェック */
                StatusCodeCheck(response);

                /* XML解析 */
                XElement elem = Json2Xml(response.GetResponseStream());

                var twit = elem.Elements()
                    .Where((XElement e) => e.Name == "item")
                    .Select((XElement e) =>
                    {
                        string text = e.Element("text").Value;
                        /* 置換処理 */
                        if (ctl_checkbox_replace_url.Checked)
                        {
                            /* URLを置換する */
                            text = System.Text.RegularExpressions.Regex.Replace(
                                text,
                                @"s?https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+",
                                ctl_textbox_replace_url.Text
                            );
                        }
                        ulong id = ulong.Parse(e.Element("id").Value);
                        DateTime created_at = DateTime.ParseExact(
                            e.Element("created_at").Value,
                            "ddd MMM dd HH':'mm':'ss zzz yyyy",
                            System.Globalization.DateTimeFormatInfo.InvariantInfo
                            );
                        XElement user_elem = e.Element("user");

                        return new
                        {
                            text = text,
                            id = id,
                            created_at = created_at,
                            user = new
                            {
                                screen_name = user_elem.Element("screen_name").Value,
                                id = ulong.Parse(user_elem.Element("id").Value),
                                name = user_elem.Element("name").Value
                            }
                        };
                    });

                if (twit.Count() > 0)
                {
                    /* 最後の発言のIDを取得 */
                    _last_twit_id = twit.Last().id;

                    /* 一時ファイルを作成する */
                    String path = Directory.GetCurrentDirectory() + @"\" + _tempfile;
                    using (StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding(932)))
                    {
                        /* つぶやきを処理する */
                        foreach (var t in ctl_checkbox_reverse.Checked ? twit.Reverse() : twit)
                        {
                            /* 出力文字列を生成 */
                            string output = Regex.Replace(ctl_textbox_format.Text, "%(?<type>\\w)", (m) =>
                            {
                                /* 発言された時間を取得 */
                                TimeSpan ts = DateTime.Now - t.created_at;
                                String time = ts.Hours > 0 ?
                                    ts.Hours.ToString() + "時間前 " :
                                    ts.Minutes > 0 ?
                                    ts.Minutes.ToString() + "分前 " :
                                    ts.Seconds > 1 ?
                                    ts.Seconds.ToString() + "秒前 " :
                                    "1秒以内";

                                /* 出力文字列を設定 */
                                switch (m.Groups["type"].Value)
                                {
                                    case "%": return "%";                    /* %%: % */
                                    case "i": return t.id.ToString();        /* %i: Twit ID */
                                    case "s": return t.user.screen_name;     /* %s: Screen name */
                                    case "t": return t.text;                 /* %t: Twit */
                                    case "T": return time;                   /* %T: Formated time */
                                    case "u": return t.user.id.ToString();   /* %u: User ID */
                                    case "n": return t.user.name;            /* %n: User Name */
                                }

                                return "";
                            }, RegexOptions.None);

                            /* ファイルに出力 */
                            sw.WriteLine(output);
                        }
                    }
                    
                    /* SofTalkの起動 */
                    System.Diagnostics.ProcessStartInfo psInfo = new System.Diagnostics.ProcessStartInfo(ctl_textbox_softalk.Text);
                    psInfo.Arguments = path;
                    if (ctl_checkbox_softalk_minimize.Checked)
                    {
                        psInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                    }
                    System.Diagnostics.Process.Start(psInfo);
                }
            }
            catch (Exception exp)
            {
                /* エラーメッセージを表示 */
                MessageBox.Show(
                    exp.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            return true;
        }

        private bool Login()
        {
            /* TwitterRequestを実体化 */
            _twRequest = new TwitterRequestOAuth(_twitter_access_token, _twitter_access_token_secret);

            /* ログインを実行 */
            string username;
            if (_twRequest.Login(out username) == false)
            {
                /* ログイン失敗 */
                _twRequest = null;
                MessageBox.Show(
                    "ログインに失敗しました",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            /* ログインボタンのラベルを変更 */
            ctl_button_login.Text = "ログアウト";

            /* ユーザ名を設定 */
            ctl_label_username.Text = username;

            /* アクセストークンを取得 */
            TwitterRequestOAuth twRequestOAuth = (TwitterRequestOAuth)_twRequest;
            _twitter_access_token = twRequestOAuth.AccessToken;
            _twitter_access_token_secret = twRequestOAuth.AccessTokenSecret;

            return true;
        }

        private void Logout()
        {
            /* TwitterRequestを破棄する */
            _twRequest = null;

            /* ログインボタンのラベルを元に戻す */
            ctl_button_login.Text = "ログイン";

            /* コントロールを元に戻す */
            ctl_label_username.Text = "";
            _twitter_access_token = "";
            _twitter_access_token_secret = "";
        }

        private void UpdateTwitterList()
        {
            try
            {
                /* 自分のリスト一欄を取得 */
                Dictionary<string, string> parms = new Dictionary<string, string>();
                parms["user"] = ctl_label_username.Text;
                HttpWebResponse response = _twRequest.Request(parms["user"] + "/" + _twitter_api_lists_get, parms);
                StatusCodeCheck(response);

                /* XMLを解析する */
                XElement elem = Json2Xml(response.GetResponseStream());

                /* slug 要素のみ抽出 */
                var slug = from e in elem.Element("lists").Elements()
                           where e.Element("slug") != null
                           select e.Element("slug").Value;

                /* リストコントロールのソートを一時的に有効化 */
                ctl_list.Sorted = true;
                foreach(var s in slug)
                {
                    ctl_list.Items.Add(s);
                }
                /* リストコントロールのソートを無効化 */
                ctl_list.Sorted = false;


                /* 購読しているリスト一覧を取得 */
                response = _twRequest.Request(parms["user"] + "/" + _twitter_api_lists_subscriptions, parms);
                StatusCodeCheck(response);

                /* XMLを解析する */
                elem = Json2Xml(response.GetResponseStream());

                /* full_name 要素のみ抽出 */
                var full_name = from e in elem.Element("lists").Elements()
                           where e.Element("full_name") != null
                           select e.Element("full_name").Value;

                foreach (var f in full_name)
                {
                    ctl_list.Items.Add(f);
                }
            }
            catch (Exception exp)
            {
                /* エラーメッセージの表示 */
                MessageBox.Show(
                    exp.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ReadOnlyMode(bool flag)
        {
            if (flag)
            {
                /* タイトルを変更 */
                this.Text = _default_title + "(実行中)";

                /* コントロールを読み取り専用にする */
                ctl_textbox_softalk.ReadOnly = true;
                ctl_button_login.Enabled = false;

                /* 自分の表示を変更 */
                ctl_button_exe.Text = "停止";
            }
            else
            {
                /* タイトルを元に戻す */
                this.Text = _default_title;

                /* コントロールを元に戻す */
                ctl_textbox_softalk.ReadOnly = false;
                ctl_button_login.Enabled = true;

                /* 自分の表示を変更 */
                ctl_button_exe.Text = "実行";
            }
        }

        private void SetAllMouseEnter(Control top)
        {
            foreach (Control c in top.Controls)
            {
                try
                {
                    c.MouseEnter += new EventHandler(UpdateInformation);
                }
                catch
                {
                }
                SetAllMouseEnter(c);
            }
            return;
        }

        private void UpdateInformation(object sender, EventArgs e)
        {
            /* ステータスバーの通知領域を設定 */
            Control ctrl = sender as Control;
            if (ctrl.Tag != null)
            {
                ctl_statusbar_information.Text = ctrl.Tag.ToString();
            }
            else
            {
                ctl_statusbar_information.Text = "";
            }
        }

        private void MinimizeWindow(object sender, EventArgs e)
        {
            /* フォームを最小化 */
            this.WindowState = FormWindowState.Minimized;
        }

        public void RestoreWindow(object sender, EventArgs e)
        {
            /* フォームを元に戻す */
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void EventExecProcess(object sender, EventArgs e)
        {
            /* ログインチェック */
            if (_twRequest == null || _twRequest.isLogin == false)
            {
                MessageBox.Show(
                    "Twitterにログインしてから実行してください",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            /* タイマーの有効/無効により処理を変更 */
            if (ctl_timer_notify.Enabled)
            {
                /* タイマーを無効にする */
                ctl_timer_notify.Enabled = false;

                /* コントロールを元に戻す */
                ReadOnlyMode(false);
            }
            else
            {
                /* コントロールを読み取り専用にする */
                ReadOnlyMode(true);

                /* 実行する */
                if (!Exec())
                {
                    /* 実行失敗。元に戻す */
                    ReadOnlyMode(false);
                    return;
                }

                /* タイマーの時間を設定 */
                ctl_timer_notify.Interval = decimal.ToInt32(ctl_updown_interval.Value) * 60 * 1000;

                /* タイマーを有効にする */
                ctl_timer_notify.Enabled = true;

                /* フォームを非表示にする */
                if (ctl_checkbox_run_minimize.Checked)
                {
                    MinimizeWindow(null, null);
                }
            }
        }

        public Main()
        {
            InitializeComponent();

            /* 設定ファイルを読み込む */
            LoadSetting();
        }

        private void ctl_button_open_Click(object sender, EventArgs e)
        {
            /* ダイアログを開く */
            ctl_opnefiledialog_softalk.FileName = ctl_textbox_softalk.Text;
            if (ctl_opnefiledialog_softalk.ShowDialog() == DialogResult.OK)
            {
                ctl_textbox_softalk.Text = ctl_opnefiledialog_softalk.FileName;
            }
        }

        private void ctl_checkbox_replace_url_CheckedChanged(object sender, EventArgs e)
        {
            /* 無効/有効を切り替える */
            if (ctl_checkbox_replace_url.Checked)
            {
                ctl_label_replace_url.Enabled = true;
                ctl_textbox_replace_url.Enabled = true;
            }
            else
            {
                ctl_label_replace_url.Enabled = false;
                ctl_textbox_replace_url.Enabled = false;
            }
        }

        private void ctl_timer_notify_Tick(object sender, EventArgs e)
        {
            /* 実行する */
            if (!Exec())
            {
                /* 無効化する */
                EventExecProcess(sender, e);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            /* 設定を保存 */
            SaveSetting();

            /* アプリケーションの終了 */
            Application.Exit();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            /* 最小化時にタスクトレイにしまう(非表示にする) */
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (ctl_checkbox_tasktray.Checked)
                {
                    /* フォームを非表示にする */
                    this.Visible = false;

                    if (!tTalk.Properties.Settings.Default.no_tasktray_icon)
                    {
                        /* タスクトレイアイコンを表示する */
                        ctl_notifyicon.Visible = true;
                    }
                    else
                    {
                        /* タスクトレイアイコンを非表示する */
                        ctl_notifyicon.Visible = false;
                    }
                }
                else
                {
                    /* フォームを表示する */
                    this.Visible = true;
                }
                
                /* メニューを更新する */
                ctl_menu_show_window.Visible = true;
                ctl_menu_hide_window.Visible = false;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                /* タスクアイコンを非表示にする */
                ctl_notifyicon.Visible = false;

                /* 元に戻された */
                ctl_menu_show_window.Visible = false;
                ctl_menu_hide_window.Visible = true;
            }
        }

        private void ctl_menu_exit_Click(object sender, EventArgs e)
        {
            /* アプリケーションを終了する */
            this.Close();
        }

        private void ctl_notifyicon_DoubleClick(object sender, EventArgs e)
        {
            /* フォームの状態によって処理を変える */
            if (this.WindowState == FormWindowState.Minimized)
            {
                /* 元に戻す */
                RestoreWindow(sender, e);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                /* 最小化 */
                MinimizeWindow(sender, e);
            }
        }

        private void ctl_btn_login_Click(object sender, EventArgs e)
        {
            if (_twRequest != null && _twRequest.isLogin)
            {
                /* ログアウトする */
                Logout();
            }
            else
            {
                /* ログインする */
                Login();
            }
        }

        private void ctl_button_list_update_Click(object sender, EventArgs e)
        {
            /* ログインチェック */
            if (_twRequest == null || _twRequest.isLogin == false)
            {
                MessageBox.Show(
                    "Twitterへログイン後に、実行してください",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            /* リスト初期化 */
            ctl_list.Items.Clear();

            /* リストを取得 */
            UpdateTwitterList();
        }

        private void ctl_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 選択されたアイテムを表示 */
            ctl_label_target_listname.Text = ctl_list.SelectedItem.ToString();
        }

        private void ctl_checkbox_tasktray_CheckedChanged(object sender, EventArgs e)
        {
            if (ctl_checkbox_tasktray.Checked)
            {
                /* チェックされたので有効化する */
                ctl_checkbox_no_tasktray_icon.Enabled = true;
                ctl_label_no_icon.Enabled = true;
            }
            else
            {
                /* チェックされたので無効化する */
                ctl_checkbox_no_tasktray_icon.Enabled = false;
                ctl_label_no_icon.Enabled = false;
            }
        }
    }
}
