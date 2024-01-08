namespace Visa_Application_API.ServiceModel
{
    public class Result
    {
        public string Msg { get; private set; }
        public string ErrMsg { get; private set; }
        public bool Error { get; private set; }
        public bool AuthorizationError { get; private set; }
        public object Obj { get; set; }
        public Result()
        {
            Msg = "";
            ErrMsg = "";
            Error = false;
            AuthorizationError = false;
        }

        public void SetError(string errMsg)
        {
            Error = true;
            AuthorizationError = false;
            ErrMsg = errMsg;
        }
        public void SetAuthorizationError(string errMsg)
        {
            Error = false;
            AuthorizationError = true;
            ErrMsg = errMsg;
        }
        public void SetSuccess(string msg)
        {
            Error = false;
            AuthorizationError = false;
            Msg = msg;
        }

    }
}
