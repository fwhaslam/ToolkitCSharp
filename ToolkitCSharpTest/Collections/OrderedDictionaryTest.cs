// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System;
using System.Collections.Generic;

using ToolkitCSharp.Collections;

namespace ToolkitCSharpTest.Collections {

	[TestClass]
    public class OrderedDictionaryTest {

		internal OrderedDictionary<string,int> map;

		[TestInitialize]
		public void SetUp(){

			map = new OrderedDictionary<string,int>(); 

			map["one"] = 1;
			map["two"] = 2;
			map["three"] = 3;
		}


        [TestMethod]
        public void _constructor() {
            
            var results = new OrderedDictionary<string,string>();

            IsNotNull( results );
        }

        [TestMethod]
		public void IndexOf() {

			// assertions
			AreEqual( 0, map.IndexOf("one") );			
			AreEqual( 2, map.IndexOf("three") );
		}

		[TestMethod]
		public void get_set() {

			// assertions
			AreEqual( 1, map["one"] );
			AreEqual( 3, map["three"] );
		}


		[TestMethod]
		public void Keys() {

			var results = map.Keys;

			// assertions
			AreEqual( 3, results.Count );
			AreEqual( "one, two, three", string.Join(", ",results) );
		}


		[TestMethod]
		public void Values() {

			var results = map.Values;

			// assertions
			AreEqual( 3, results.Count );
			AreEqual( "1, 2, 3", string.Join(", ",results) );
		}

		[TestMethod]
		public void Add_append(){

			map.Add("four",4);

			AreEqual( 4, map.Count );
			AreEqual( "one, two, three, four", string.Join(", ",map.Keys) );
			AreEqual( "1, 2, 3, 4", string.Join(", ",map.Values) );
		}

		[TestMethod]
		public void Add_replace(){

			map.Add("two",4);

			AreEqual( 3, map.Count );
			AreEqual( "one, two, three", string.Join(", ",map.Keys) );
			AreEqual( "1, 4, 3", string.Join(", ",map.Values) );
		}


		[TestMethod]
		public void ContainsKey() {

			IsTrue( map.ContainsKey("one") );
			IsFalse( map.ContainsKey("four") );
		}

		[TestMethod]
		public void Remove(){
		
			map.Remove( "two" );

			AreEqual( 2, map.Count );
			AreEqual( "one, three", string.Join(", ",map.Keys) );
			AreEqual( "1, 3", string.Join(", ",map.Values) );
		}

		[TestMethod]
		public void TryGetValue(){

			int value;
			IsTrue( map.TryGetValue("two",out value ) );
			AreEqual( 2, value );

			IsFalse( map.TryGetValue("four", out value) );
			AreEqual( 0, value);
		}

		[TestMethod]
		public void Count(){
			AreEqual( 3, map.Count );
		}

		[TestMethod]
		public void IsReadOnly(){ 
			IsFalse( map.IsReadOnly );	
		}

		[TestMethod]
		public void Clear(){

			map.Clear();
			AreEqual( 0, map.Count );
		}

		[TestMethod]
		public void Add_kvpair() {
			map.Add( new KeyValuePair<string,int>("four",4) );
			AreEqual( 4, map.Count );
			AreEqual( 4, map["four"] );
		}

		[TestMethod]
		public void Contains_kvpair(){

			IsTrue( map.Contains(new KeyValuePair<string,int>("two",2) ) );

			IsFalse( map.Contains(new KeyValuePair<string,int>("two",4) ) );
			IsFalse( map.Contains(new KeyValuePair<string,int>("four",2) ) );
		}

		[TestMethod]
		public void CopyTo() {
			try {
				map.CopyTo(null, 0);
			}
			catch (Exception ex ) {
				AreEqual( typeof(NotImplementedException),ex.GetType());
			}
		}

		[TestMethod]
		public void Remove_kvpair() {

			map.Remove( new KeyValuePair<string,int>("two",2));

			AreEqual( 2, map.Count );
			AreEqual( "one, three", string.Join(", ",map.Keys) );
			AreEqual( "1, 3", string.Join(", ",map.Values) );
		}

		[TestMethod]
		public void GetEnumerator(){


			var checkKeys = new List<string>();
			var checkValues = new List<int>();

			foreach ( var entry in map ) {
				checkKeys.Add( entry.Key );
				checkValues.Add( entry.Value );
			}

			AreEqual( "one, two, three", string.Join(", ",map.Keys) );
			AreEqual( "1, 2, 3", string.Join(", ",map.Values) );
		}

    }

}