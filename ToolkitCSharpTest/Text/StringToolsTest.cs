// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using ToolkitCSharp.Text;

namespace ToolkitCSharpTest.Text {

	[TestClass]
    public class StringToolsTest {

		internal string[] LongStringSamples(){
			var first = "something sort of long that has some similarity to the next";
			var second = "something that is sort fo long with some kind of similarity to the previous";
			return new string[]{first,second};
		}
        
		[TestMethod]
		public void SubstringBefore_str_str(){
			AreEqual( "something", StringTools.SubstringBefore("something","GO") );
			AreEqual( "something", StringTools.SubstringBefore("somethingGO","GO") );
			AreEqual( "some", StringTools.SubstringBefore("someGOthing","GO") );
			AreEqual( "", StringTools.SubstringBefore("GOsomething","GO") );
		}

		[TestMethod]
		public void SubstringBefore_str_char(){
			AreEqual( "something", StringTools.SubstringBefore("something",'X') );
			AreEqual( "something", StringTools.SubstringBefore("somethingX",'X') );
			AreEqual( "some", StringTools.SubstringBefore("someXthing",'X') );
			AreEqual( "", StringTools.SubstringBefore("Xsomething",'X') );
		}

		[TestMethod]
		public void SubstringBefore_char_str(){
			AreEqual( "something", StringTools.SubstringBefore('X',"something") );
			AreEqual( "something", StringTools.SubstringBefore('X',"somethingX") );
			AreEqual( "some", StringTools.SubstringBefore('X',"someXthing") );
			AreEqual( "", StringTools.SubstringBefore('X',"Xsomething") );
		}

		[TestMethod]
		public void SubstringBeforeLast_str_str(){
			AreEqual( "something", StringTools.SubstringBeforeLast("something","GO") );
			AreEqual( "someGOthing", StringTools.SubstringBeforeLast("someGOthingGO","GO") );
			AreEqual( "GOsome", StringTools.SubstringBeforeLast("GOsomeGOthing","GO") );
			AreEqual( "", StringTools.SubstringBeforeLast("GOsomething","GO") );
		}

		[TestMethod]
		public void SubstringBeforeLast_str_char(){
			AreEqual( "something", StringTools.SubstringBeforeLast("something",'X') );
			AreEqual( "someXthing", StringTools.SubstringBeforeLast("someXthingX",'X') );
			AreEqual( "Xsome", StringTools.SubstringBeforeLast("XsomeXthing",'X') );
			AreEqual( "", StringTools.SubstringBeforeLast("Xsomething",'X') );
		}

		[TestMethod]
		public void SubstringBeforeLast_char_str(){
			AreEqual( "something", StringTools.SubstringBeforeLast('X',"something") );
			AreEqual( "someXthing", StringTools.SubstringBeforeLast('X',"someXthingX") );
			AreEqual( "Xsome", StringTools.SubstringBeforeLast('X',"XsomeXthing") );
			AreEqual( "", StringTools.SubstringBeforeLast('X',"Xsomething") );
		}

		[TestMethod]
		public void SubstringAfter_str_str(){
			AreEqual( "something", StringTools.SubstringAfter("something","GO") );
			AreEqual( "something", StringTools.SubstringAfter("GOsomething","GO") );
			AreEqual( "thing", StringTools.SubstringAfter("someGOthing","GO") );
			AreEqual( "", StringTools.SubstringAfter("somethingGO","GO") );
		}

		[TestMethod]
		public void SubstringAfter_str_char(){
			AreEqual( "something", StringTools.SubstringAfter("something",'X') );
			AreEqual( "something", StringTools.SubstringAfter("Xsomething",'X') );
			AreEqual( "thing", StringTools.SubstringAfter("someXthing",'X') );
			AreEqual( "", StringTools.SubstringAfter("somethingX",'X') );
		}

		[TestMethod]
		public void SubstringAfter_char_str(){
			AreEqual( "something", StringTools.SubstringAfter('X',"something") );
			AreEqual( "something", StringTools.SubstringAfter('X',"Xsomething") );
			AreEqual( "thing", StringTools.SubstringAfter('X',"someXthing") );
			AreEqual( "", StringTools.SubstringAfter('X',"somethingX") );
		}

		[TestMethod]
		public void SubstringAfterLast_str_str(){
			AreEqual( "something", StringTools.SubstringAfterLast("something","GO") );
			AreEqual( "thing", StringTools.SubstringAfterLast("GOsomeGOthing","GO") );
			AreEqual( "", StringTools.SubstringAfterLast("someGOthingGO","GO") );
			AreEqual( "", StringTools.SubstringAfterLast("somethingGO","GO") );
		}

		[TestMethod]
		public void SubstringAfterLast_str_char(){
			AreEqual( "something", StringTools.SubstringAfterLast("something",'X') );
			AreEqual( "thing", StringTools.SubstringAfterLast("XsomeXthing",'X') );
			AreEqual( "", StringTools.SubstringAfterLast("someXthingX",'X') );
			AreEqual( "", StringTools.SubstringAfterLast("somethingX",'X') );
		}

		[TestMethod]
		public void SubstringAfterLast_char_str(){
			AreEqual( "something", StringTools.SubstringAfterLast('X',"something") );
			AreEqual( "thing", StringTools.SubstringAfterLast('X',"XsomeXthing") );
			AreEqual( "", StringTools.SubstringAfterLast('X',"someXthingX") );
			AreEqual( "", StringTools.SubstringAfterLast('X',"somethingX") );
		}


		[TestMethod]
		public void GetLevenshteinDistance(){

			AreEqual( 0, StringTools.GetLevenshteinDistance( "same", "same" ) );
			AreEqual( 0, StringTools.GetLevenshteinDistance( "", "" ) );
			AreEqual( 0, StringTools.GetLevenshteinDistance( "Same\nOld", "Same\nOld" ) );

			AreEqual( 1, StringTools.GetLevenshteinDistance( "a", "A" ) );
			AreEqual( 1, StringTools.GetLevenshteinDistance( "a", "" ) );
			AreEqual( 1, StringTools.GetLevenshteinDistance( "a", "b" ) );
			AreEqual( 1, StringTools.GetLevenshteinDistance( "a", "ab" ) );

			AreEqual( 2, StringTools.GetLevenshteinDistance( "ba", "ab" ) );

		}

		[TestMethod]
		public void GetLevenshteinDistance_longStrings(){

			var strs = LongStringSamples();

			var results = StringTools.GetLevenshteinDistance( strs[0], strs[1] );

			AreEqual( 31, results );
		}
		
		[TestMethod]
		public void GetDamerauLevenshteinDistance(){

			AreEqual( 0, StringTools.GetDamerauLevenshteinDistance( "same", "same" ) );
			AreEqual( 0, StringTools.GetDamerauLevenshteinDistance( "", "" ) );
			AreEqual( 0, StringTools.GetDamerauLevenshteinDistance( "Same\nOld", "Same\nOld" ) );

			AreEqual( 1, StringTools.GetDamerauLevenshteinDistance( "a", "A" ) );
			AreEqual( 1, StringTools.GetDamerauLevenshteinDistance( "a", "" ) );
			AreEqual( 1, StringTools.GetDamerauLevenshteinDistance( "a", "b" ) );
			AreEqual( 1, StringTools.GetDamerauLevenshteinDistance( "a", "ab" ) );

			AreEqual( 1, StringTools.GetDamerauLevenshteinDistance( "ba", "ab" ) );

		}
		[TestMethod]
		public void GetDamerauLevenshteinDistance_longStrings(){

			var strs = LongStringSamples();

			var results = StringTools.GetDamerauLevenshteinDistance( strs[0], strs[1] );

			AreEqual( 30, results );
		}
    }
}

