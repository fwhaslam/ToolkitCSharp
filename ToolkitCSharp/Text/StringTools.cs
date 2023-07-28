// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Linq;

namespace ToolkitCSharp.Text {

    public class StringTools {
        
		public static string SubstringBefore( string src, string cutStr ) {
			int cutAt = src.IndexOf( cutStr );
			if (cutAt<0) cutAt = src.Length;
			return src.Substring( 0, cutAt );
		}
		public static string SubstringBefore( string src, char cutChar ) {
			int cutAt = src.IndexOf( cutChar );
			if (cutAt<0) cutAt = src.Length;
			return src.Substring( 0, cutAt );
		}
		public static string SubstringBefore( char cutChar, string src ) {
			return SubstringBefore( src, cutChar );
		}	
	
		public static string SubstringBeforeLast( string src, string cutStr ) {
			int cutAt = src.LastIndexOf( cutStr );
			if (cutAt<0) cutAt = src.Length;
			return src.Substring( 0, cutAt );
		}
		public static string SubstringBeforeLast( string src, char cutChar ) {
			int cutAt = src.LastIndexOf( cutChar );
			if (cutAt<0) cutAt = src.Length;
			return src.Substring( 0, cutAt );
		}
		public static string SubstringBeforeLast( char cutChar, string src ) {
			return SubstringBeforeLast( src, cutChar );
		}	

		public static string SubstringAfter( string src, string cutStr ) {
			int offset = cutStr.Length;
			int cutAt = src.IndexOf( cutStr );
			if (cutAt<0) cutAt = -offset;
			return src.Substring( offset + cutAt );
		}
		public static string SubstringAfter( string src, char cutChar ) {
			int cutAt = src.IndexOf( cutChar );
			if (cutAt<0) cutAt = -1;
			return src.Substring( 1+cutAt );
		}
		public static string SubstringAfter( char cutChar, string src ) {
			return SubstringAfter( src, cutChar );
		}
				
		public static string SubstringAfterLast( string src, string cutStr ) {
			int offset = cutStr.Length;
			int cutAt = src.LastIndexOf( cutStr );
			if (cutAt<0) cutAt = -offset;
			return src.Substring( offset+cutAt );
		}
		public static string SubstringAfterLast( string src, char cutChar ) {
			int cutAt = src.LastIndexOf( cutChar );
			if (cutAt<0) cutAt = -1;
			return src.Substring( 1+cutAt );
		}
		public static string SubstringAfterLast( char cutChar, string src ) {
			return SubstringAfterLast( src, cutChar );
		}

//======================================================================================================================

		/// <summary>
        /// Count of operations necessary to transform one string into the other.
        /// Operations include: insertion, deletion and substitution
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
		public static int GetLevenshteinDistance(string first, string second) {

            int flen = first.Length;
            int slen = second.Length;
            int[,] dist = new int[flen + 1, slen + 1];

            // Step 1
            if (flen == 0) return slen;
            if (slen == 0) return flen;

            // Step 2
            for (int i = 0; i <= flen; dist[i, 0] = i++) {}

            for (int j = 0; j <= slen; dist[0, j] = j++) {}

            // Step 3
            for (int i = 1; i <= flen; i++) {

                //Step 4
                for (int j = 1; j <= slen; j++) {
                    // Step 5
                    int cost = (second[j - 1] == first[i - 1]) ? 0 : 1;

                    // Step 6
                    dist[i, j] = Math.Min(
                        Math.Min(dist[i - 1, j] + 1, dist[i, j - 1] + 1),
                        dist[i - 1, j - 1] + cost);
                }
            }

            // Step 7
            return dist[flen, slen];
        }

		/// <summary>
        /// Count of operations necessary to transform one string into the other.
        /// Operations include: insertion, deletion, substitution and transposition
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
		public static int GetDamerauLevenshteinDistance(string first, string second) {

            var bounds = new { Height = first.Length + 1, Width = second.Length + 1 };

            int[,] matrix = new int[bounds.Height, bounds.Width];

            for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
            for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

            for (int height = 1; height < bounds.Height; height++) {

                for (int width = 1; width < bounds.Width; width++) {

                    int cost = (first[height - 1] == second[width - 1]) ? 0 : 1;
                    int insertion = matrix[height, width - 1] + 1;
                    int deletion = matrix[height - 1, width] + 1;
                    int substitution = matrix[height - 1, width - 1] + cost;

                    int distance = Math.Min(insertion, Math.Min(deletion, substitution));
                    if (height > 1 && width > 1 && first[height - 1] == second[width - 2] && first[height - 2] == second[width - 1]) {
                        distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
                    }

                    matrix[height, width] = distance;
                }
            }

            return matrix[bounds.Height - 1, bounds.Width - 1];
        }
    }
}
