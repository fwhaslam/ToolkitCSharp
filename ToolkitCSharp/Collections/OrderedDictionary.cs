// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace ToolkitCSharp.Collections {

	/// <summary>
	/// CHEAP implementation works fine for short lists.
	/// </summary>
	/// <typeparam name="K"></typeparam>
	/// <typeparam name="V"></typeparam>
    public class OrderedDictionary<K,V> : IDictionary<K,V> {

		internal List<KeyValuePair<K,V>> entries = new List<KeyValuePair<K, V>>();

		public int IndexOf( K key ) {
			for (int ix=0;ix<entries.Count;ix++) {
				if (entries[ix].Key.Equals(key)) return ix;
			}
			return -1;
		}

//======================================================================================================================
// IDictionary

		public V this[K key] {
			get {
				var ix = IndexOf(key);
				if (ix>=0) return entries[ix].Value;
				throw new SystemException("Key Not Found");
			}
			set { 
				Add( key, value );
			}
		}

		public ICollection<K> Keys { get { return entries.Select( (e) => e.Key ).ToList(); } }
		public ICollection<V> Values { get { return entries.Select( (e) => e.Value ).ToList(); } }

		public void Add(K key, V value) {
			var ix = IndexOf(key);
			if (ix>=0) {
				entries[ix] = new KeyValuePair<K,V>( key, value );
			}
			else {
				entries.Add( new KeyValuePair<K,V>( key, value ) );
			}
		}

		public bool ContainsKey(K key) { return ( IndexOf(key)>=0 ); }

		public bool Remove(K key){
			var ix = IndexOf(key);
			if (ix<0) return false;
			entries.RemoveAt(ix);
			return true;
		}

		public bool TryGetValue(K key, out V value) {
			var ix = IndexOf(key);
			if (ix<0) {
				value = default(V);
				return false;
			}
			value = entries[ix].Value;
			return true;
		}

//======================================================================================================================
// ICollection

		public int Count { get { return entries.Count; } }
		public bool IsReadOnly { get { return false; } }

		public void Clear() {
			entries.Clear();
		}

		public void Add( KeyValuePair<K,V> item ) {
			entries.Add( item );
		}

		public bool Contains(KeyValuePair<K,V> item){
			return entries.Contains(item);
		}

		public void CopyTo(KeyValuePair<K,V>[] array, int arrayIndex) {
			throw new NotImplementedException();
		}

		public bool Remove(KeyValuePair<K,V> item) {
			return entries.Remove(item);
		}


//======================================================================================================================
// IEnumerator<generic>, IEnumerator
 
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator() {
            return entries.GetEnumerator();
        }

		IEnumerator IEnumerable.GetEnumerator() {
			return entries.GetEnumerator();
		}
	}

}