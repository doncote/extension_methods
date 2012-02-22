using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace src
{
    public static class StringExtensionMethods
    {
        public static string ToHtmlUnorderedList(this IList<string> list)
        {
            if (list == null || list.Count == 0) return string.Empty;
            string items = string.Empty;
            foreach (string item in list)
            {
                items += "<li>" + item + "</li>";
            }
            return string.Format("<ul>{0}</ul>", items);
        }

        public static string ToCsv(this IList<string> list)
        {
            if (list.Count == 0) return string.Empty;
            string items = string.Empty;
            foreach (string item in list)
            {
                items += item + ", ";
            }
            return items.TrimEnd().RemoveTrailingComma();
        }

        public static string RemoveTrailingComma(this string s)
        {
            if (!s.Contains(",")) return s;
            int i = s.LastIndexOf(",", StringComparison.Ordinal);
            string returnVal = s.Remove(i);
            return returnVal;
        }

        public static string WrapWithQuotesIfHasComma(this string item)
        {
            if (string.IsNullOrEmpty(item)) return string.Empty;
            string s = item;
            s = s.Replace("\"", "'");
            s = (s.Contains(",")) ? "\"" + s + "\"" : s;
            return s;
        }

        public static string RemoveLineBreaks(this string item)
        {
            string replaceWith = string.Empty;
            string removedBreaks = item
                .Replace("\r\n", replaceWith)
                .Replace("\n", replaceWith)
                .Replace("\r", replaceWith)
                .Replace(Environment.NewLine, replaceWith);
            Byte[] myBytes13 = {13};
            string myStr13 = Encoding.ASCII.GetString(myBytes13);
            removedBreaks = removedBreaks.Replace(myStr13, string.Empty);
            return removedBreaks;
        }

        public static IList<string> ToListFromCsv(this string csv)
        {
            IList<string> list = new List<string>();
            if (string.IsNullOrEmpty(csv)) return list;
            foreach (string item in csv.Split(new[] {','}))
            {
                list.Add(item);
            }
            return list;
        }

        public static string ReplaceWordChars(this string text)
        {
            string s = text;
            // smart single quotes and apostrophe
            s = Regex.Replace(s, "[\u2018|\u2019|\u201A]", "'");
            // smart double quotes
            s = Regex.Replace(s, "[\u201C|\u201D|\u201E]", "\"");
            // ellipsis
            s = Regex.Replace(s, "\u2026", "...");
            // dashes
            s = Regex.Replace(s, "[\u2013|\u2014]", "-");
            // circumflex
            s = Regex.Replace(s, "\u02C6", "^");
            // open angle bracket
            s = Regex.Replace(s, "\u2039", "<");
            // close angle bracket
            s = Regex.Replace(s, "\u203A", ">");
            // spaces
            s = Regex.Replace(s, "[\u02DC|\u00A0]", " ");
            return s;
        }
    }
}