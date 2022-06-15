using System.Text;

namespace DBAndAPIProject
{
    public static class StringUtils
    {
        public static string ConvertCoding(string value, Encoding srcEnc, Encoding dstEnc)
        {
            if (value != null)
            {
                byte[] bytesArr = dstEnc.GetBytes(value);
                byte[] endBytesArr = Encoding.Convert(srcEnc, dstEnc, bytesArr);
                return dstEnc.GetString(endBytesArr);
            }
            else
            {
                return null;
            }
        }
    }
}
