using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ZCommon
{
    public class cRegex
    {
        /// <summary>
        /// 获取指定的字符串
        /// </summary>
        /// <param name="input">内容</param>
        /// <param name="match">匹配项</param>
        /// <param name="pattern">不需要的项</param>
        /// <returns></returns>
        public static string getString(string input, string match, string pattern)
        {
            Regex r = new Regex(match);
            Match m = r.Match(input);
            return (Regex.Replace(m.Value, pattern, string.Empty, RegexOptions.IgnoreCase));
        }
    }
}
