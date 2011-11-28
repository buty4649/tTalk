using System;
using System.Net;

namespace tTalk
{
    class TwitterRequestBasic : TwitterRequest
    {
        private string _username;
        private string _password;

        public TwitterRequestBasic(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public override HttpWebResponse Request(string api_suffix)
        {
            /* リクエストを発行する */
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url(api_suffix));
            request.Credentials = new NetworkCredential(_username, _password);

            return (HttpWebResponse)request.GetResponse();
        }
    }
}
