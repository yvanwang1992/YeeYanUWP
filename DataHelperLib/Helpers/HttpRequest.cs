using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataHelperLib.Helpers
{
    public class HttpRequest
    {
        #region --------------- Property ---------------

        public string _url;
        public string _body;
        private byte[] _formData;
        public RequestType _requestType;
        //Set Headers
        private Dictionary<string, object> _dictionary = null;
        private HttpWebRequest _httpRequest = null;

        #endregion

        #region --------------- Delegates ---------------

        public delegate void OnSuccessEventHandle(string result, HttpStatusCode statusCode);
        public delegate void OnFailedEventHandle(string error, WebExceptionStatus status);
        public delegate void OnCancelEvenetHandle(string message);

        #endregion

        #region --------------- Events ---------------

        public event OnFailedEventHandle OnFailed;
        public event OnSuccessEventHandle OnSuccess;
        public event OnCancelEvenetHandle OnCancel;

        #endregion

        #region --------------- Constructors ---------------

        public HttpRequest()
        {

        }

        public HttpRequest(string url, string body = null,  RequestType requestType = RequestType.Get)
        {
            this._url = url;
            this._body = body;
            this._requestType = requestType;
        }

        #endregion

        #region --------------- Methods ---------------

        public void Run()
        {
            ProcessWithUrl();

            DoHttpWebRequest(this._url, GetRequestStream, GetResponse);
        }

        //Absort to the Internet
        public void Absort()
        {
            _httpRequest.Abort();
        }

        private void ProcessWithUrl()
        {
            //url:www.baidu.com   ////// ?/////// body:a=111&b=222&c=333
            if (_requestType == RequestType.Get)
            {
                if (_body != null)
                {
                    //combine url and body
                    _url = string.Format("{0}?{1}", _url, _body);
                }
                else
                {
                    //can do nothing
                }
            }
            else if(_requestType == RequestType.Post)
            {
                if (_body != null)
                {
                    //Dictionary<string, object> dic = new Dictionary<string, object>();
                    //foreach (var item in _body.Split('&'))
                    //{
                    //    string[] list = item.Split('=');
                    //    dic.Add(list[0], list[1]);  //add key:list[0]  & value:list[1]
                    //    //Dosen't contains post file;
                    //}
                    //_dictionary = dic;
                    _formData = Encoding.UTF8.GetBytes(_body);
                }
            }
        }

        private void DoHttpWebRequest(string url, AsyncCallback GetRequestStream, AsyncCallback GetResponse)
        {
            var request = CreateHttp(url);
            this._httpRequest = request;

            if (request != null)
            {
                //Post Send Data
                if (_requestType == RequestType.Post)
                {
                    //Send Data
                    request.BeginGetRequestStream(GetRequestStream, request);
                }
                //Get GetData
                else if (_requestType == RequestType.Get)
                {
                    request.BeginGetResponse(GetResponse, request);
                }
            }

        }

        private HttpWebRequest CreateHttp(string url)
        {
            HttpWebRequest request = null;
            try
            {
                request = WebRequest.CreateHttp(url);
            }
            catch (WebException e)
            {
                //failed
                OnFailed(e.Message, e.Status);
                return null;
            }
            //the "Get"/"Post"method must be capitalization 
            request.Method = _requestType == RequestType.Get ? "GET" : "POST";
            
            SetHeaders(request);

            return request;
        }

        //Set Headers
        private void SetHeaders(HttpWebRequest request)
        {
            if (_requestType == RequestType.Post)
            {
                request.CookieContainer = new CookieContainer();
                request.ContentType = "application/x-www-form-urlencoded";
                
            }
        }        
        private void GetResponse(IAsyncResult async)
        {
            var httpRequest = (HttpWebRequest)async.AsyncState;
            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)httpRequest.EndGetResponse(async);
                
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    //DoSomething with callback stream
                    OnSuccess(content, response.StatusCode);
                }
            }
            catch (WebException e)
            {
                //Failed
                if (e.Status == WebExceptionStatus.RequestCanceled)
                {
                    //if Absort Method is Called
                    if (OnCancel != null)
                    {
                        OnCancel(Constant.NET_CANCELED);
                    }
                }
                else
                {
                    OnFailed(e.Message, e.Status);
                }
            }
        }

        private void GetRequestStream(IAsyncResult async)
        {
            var request = (HttpWebRequest)async.AsyncState;
            try
            {
                if (!string.IsNullOrEmpty(_body))
                {
                    using (var requestStream = request.EndGetRequestStream(async))
                    {
                        //Write FormData toStream
                        requestStream.Write(_formData, 0, _formData.Length);
                    }
                    //than Get Data with GetResponse Method
                    request.BeginGetResponse(GetResponse, request);
                }
                
            }
            catch (WebException e)
            {
                //Failed
                OnFailed(e.Message, e.Status);
            }
        }
        #endregion
    }

    public enum RequestType
    {
        Get,
        Post
    }
}
