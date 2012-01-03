using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Lenovo.CFI.BLL.Sys
{
    /// <summary>
    /// 生成随机字符串。
    /// </summary>
    public class RandomString
    {
        private static Random random;
        static RandomString()
        {
            random = new Random();
        }

        /// <summary>
        /// 获取随即密码，根据配置的模式生成。
        /// </summary>
        /// <returns>随即密码</returns>
        public static string GetPassword()
        {
            return GetRandomString(ConfigurationManager.AppSettings["PasswordPattern"]);
        }

        /// <summary>
        /// 获取随即验证码，根据配置的模式生成。
        /// </summary>
        /// <returns></returns>
        public static string GetValidateCode()
        {
            return GetRandomString(ConfigurationManager.AppSettings["ValidatePattern"]);
        }

        // 根据指定的模式获取随即字符串
        private static string GetRandomString(string pattern)
        {

            string str = "";
            foreach (char p in pattern)
            {
                str += GetRandomString(p);
            }
            return str;
        }

        // 根据指定的模式获取随即字符
        private static char GetRandomString(char pattern)
        {
            switch (pattern)
            {
                case '1':
                    return chars[random.Next(0, 25)];
                case '2':
                    return chars[random.Next(26, 51)];
                case '3':
                    return chars[random.Next(52, 61)];
                case '4':
                    return chars[random.Next(62, 93)];
                case '5':
                    return chars[random.Next(0, 51)];
                case '6':
                    return chars[random.Next(0, 93)];
            }
            return 'A';
        }

        // 可用字符集
        // 0-25 大写字母
        // 26-51 小写字母
        // 52-61 数字
        // 62- 93
        private static char[] chars = new char[] { 
            'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'e', 'e', 'e', 'f', 'g',
            'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*',
            '*', '+', ',', '-', '.', '/', ':', ';', '<', '=',
            '>', '@', '[', '\\', ']', '^', '_', '`', '{', '|',
            '}', '~'
        };
    }
}
