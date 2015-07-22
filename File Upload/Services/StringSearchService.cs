using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextMatch.Services
{
    /// <summary>
    /// Class to search for a sub-string in text
    /// </summary>
    public class StringSearchService
    {
        /// <summary>
        /// Searches for one or more occurences of a sub-string in a piece of text. Returns a list of character poitions
        /// </summary>
        /// <param name="text">Text to search in</param>
        /// <param name="subText">text to search for</param>
        /// <returns>CSV list of character positions</returns>
        public string MatchString(string text, string subText)
        {
            var matches = new List<int>();

            // Ignore case
            text = text.ToLower();
            subText = subText.ToLower();

            int lengthOfSubText = subText.Length;

            // Loop through text, one character at a time
            for ( int c = 0; c < text.Length; c ++) 
            {
                // test for match in first character of subtext
                if (text[c] == subText[0] ) 
                {
                    // get next [subtext length] characters from the text
                    string substring = ExtractSubString(text, c, lengthOfSubText);

                    // Does it match the required subject
                    if (substring == subText)
                    {
                        // Add position as a 'start at 1' array index
                        matches.Add(c + 1);
                        // move beyond sub-string
                        c += lengthOfSubText - 1;
                    }
                }
            }

            // convert to CSV
            return String.Join(",", matches.Select(i => i.ToString()).ToArray());
        }

        /// <summary>
        /// Extract a substring from the supplied text using the starting position and length
        /// </summary>
        /// <param name="text">Text to extract from</param>
        /// <param name="start">startting character in text</param>
        /// <param name="length">length of characters to extract</param>
        /// <returns>Sub-string, if found</returns>
        private string ExtractSubString(string text, int start, int length)
        {
            string substring = string.Empty;

            // If there are enought characters left in the string...
            if (text.Length > start + length - 1)
            {
                for (int c = 0; c < length; c++)
                {
                    substring += text[start + c];
                }
            }

            return substring;
        }
    }
}