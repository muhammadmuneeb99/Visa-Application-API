using Visa_Application_API.ServiceModel;

namespace Visa_Application_API.DataAccessLayer.Helpers
{
    public class Utility
    {
        public static void SaveFile(string base64, string path, string fileName)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                byte[] bytes = Convert.FromBase64String(base64);
                path = Path.Combine(path, fileName);
                File.WriteAllBytes(path, bytes);
            }
            catch
            {
                Exception ex = new Exception("Internal error while saving document(s)");
                throw ex;
            }
        }

        public static Result GetException(Exception ex, Result result)
        {
            result.SetError("Unknown internal server error");
            return result;
        }

    }
}
