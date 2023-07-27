// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

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
    }
}
