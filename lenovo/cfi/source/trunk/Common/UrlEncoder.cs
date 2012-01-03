using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common
{
    /// <summary>
    /// 对URL进行编码
    /// </summary>
    public class UrlEncoder
    {
        /// <summary>
        /// 编码URL
        /// </summary>
        /// <param name="str">URL。</param>
        /// <returns>编码后的URL。</returns>
        /// <remarks>仅编码URL中的?前的部分。</remarks>
        public static string UrlPathEncode(string str)
        {
            if (str == null)
            {
                return null;
            }
            int index = str.IndexOf('?');
            if (index >= 0)
            {
                return (UrlPathEncode(str.Substring(0, index)) + str.Substring(index));
            }
            return UrlEncodeSpaces(UrlEncodeNonAscii(str, Encoding.UTF8));

        }

        /// <summary>
        /// 编码URL中的字符串。
        /// </summary>
        /// <param name="str">字符串。</param>
        /// <returns>编码后的字符串。</returns>
        public static string Encode(string str)
        {
            return UrlEncodeSpecial(UrlEncodeSpaces(UrlEncodeNonAscii(str, Encoding.UTF8)));
        }

        // 编码特殊字符，包括\ # & ' ( ) +
        private static string UrlEncodeSpecial(string str)
        {
            if (str != null)
            {
                if (str.IndexOf("\"") >= 0)
                    str = str.Replace("\"", "%22");
                if (str.IndexOf("#") >= 0)
                    str = str.Replace("#", "%23");
                if (str.IndexOf("&") >= 0)
                    str = str.Replace("&", "%26");
                if (str.IndexOf("'") >= 0)
                    str = str.Replace("'", "%27");
                if (str.IndexOf("(") >= 0)
                    str = str.Replace("(", "%28");
                if (str.IndexOf(")") >= 0)
                    str = str.Replace(")", "%29");
                if (str.IndexOf("+") >= 0)
                    str = str.Replace("+", "%2B");
                if (str.IndexOf("/") >= 0)
                    str = str.Replace("/", "%2F");
                if (str.IndexOf("=") >= 0)
                    str = str.Replace("=", "%3D");
                if (str.IndexOf("?") >= 0)
                    str = str.Replace("?", "%3F");
            }
            return str;
        }

        // 编码空格字符
        private static string UrlEncodeSpaces(string str)
        {
            if ((str != null) && (str.IndexOf(' ') >= 0))
            {
                str = str.Replace(" ", "%20");
            }
            return str;
        }


        #region UrlEncodeNonAscii 编码非Ascii字符

        private static string UrlEncodeNonAscii(string str, Encoding e)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            if (e == null)
            {
                e = Encoding.UTF8;
            }
            byte[] bytes = e.GetBytes(str);
            bytes = UrlEncodeBytesToBytesInternalNonAscii(bytes, 0, bytes.Length, false);
            return Encoding.ASCII.GetString(bytes);
        }

        private static bool IsNonAsciiByte(byte b)
        {
            if (b < 0x7f)
            {
                return (b < 0x20);
            }
            return true;
        }

        private static byte[] UrlEncodeBytesToBytesInternalNonAscii(byte[] bytes, int offset, int count, bool alwaysCreateReturnValue)
        {
            int num = 0;
            for (int i = 0; i < count; i++)
            {
                if (IsNonAsciiByte(bytes[offset + i]))
                {
                    num++;
                }
            }
            if (!alwaysCreateReturnValue && (num == 0))
            {
                return bytes;
            }
            byte[] buffer = new byte[count + (num * 2)];        // 非Ascii转换为 %加字符的ASCII码 -- 所以共计3位
            int num3 = 0;
            for (int j = 0; j < count; j++)
            {
                byte b = bytes[offset + j];
                if (IsNonAsciiByte(b))
                {
                    buffer[num3++] = 0x25;                              // % 对应16进制为0x25
                    buffer[num3++] = (byte)IntToHex((b >> 4) & 15);     // 
                    buffer[num3++] = (byte)IntToHex(b & 15);            // 
                }
                else
                {
                    buffer[num3++] = b;
                }
            }
            return buffer;
        }

        private static char IntToHex(int n)
        {
            if (n <= 9)
            {
                return (char)(n + 0x30);
            }
            return (char)((n - 10) + 0x61);
        }

        #endregion



        #region hash

        /// <summary>
        /// 对URL中的参数进行Hash
        /// </summary>
        /// <param name="para">参数。</param>
        /// <returns>Hash值。</returns>
        public static string HashPara(params string[] para)
        {
            string paraStr = "";
            foreach (string p in para)
            {
                paraStr += p;
            }
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(paraStr, "MD5");
        }

        /// <summary>
        /// 根据Hash值，验证URL中的参数
        /// </summary>
        /// <param name="hash">Hash值。</param>
        /// <param name="para">参数。</param>
        /// <returns>是否匹配。</returns>
        public static bool ValidatePara(string hash, params string[] para)
        {
            string paraStr = "";
            foreach (string p in para)
            {
                paraStr += p;
            }
            return (hash == System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(paraStr, "MD5"));
        }

        #endregion
    }
}
