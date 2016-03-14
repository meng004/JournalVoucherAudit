﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JournalVoucherAudit.Utility
{
    /// <summary>
    /// 字符串扩展方法
    /// 半角/全角转换
    /// 取字符串中数字
    /// </summary>
    public static class StringExtensionMethods
    {
        /// <summary>
        /// 转化为半角字符串
        /// </summary>
        /// <param name="input">要转化的字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToSbc(this string input)//single byte charactor
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)//全角空格为12288，半角空格为32
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)//其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 转化为全角字符串
        /// </summary>
        /// <param name="input">要转化的字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToDbc(this string input)//double byte charactor 
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        /// <summary>
        /// 取出数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetNumber(this string str)
        {
            var actual = string.Empty;
            if (!string.IsNullOrWhiteSpace(str))
            {
                // 正则表达式剔除非数字字符（不包含小数点.） 
                actual = Regex.Replace(str, "\\D+", string.Empty);
            }
            //去掉左侧的0
            var result = actual.TrimStart(new char[] { '0' });
            return result;
        }
    }
}