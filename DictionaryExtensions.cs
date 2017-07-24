using System;
using System.Collections.Generic;


namespace Extensions
{
    public static class DictionaryExtensions
    {
    	/// <summary>
    	/// Get value or default
    	/// </summary>
    	/// <param name="dictionary">Dictionary</param>
    	/// <param name="key">Key</param>
    	/// <returns>Value of key or default of TValue if not found</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {	
            TValue value;

            if(dictionary.TryGetValue(key, out value))
            {
                return value;
            }

            return default(TValue);
        }
        
        /// <summary>
        /// Get value or new
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="key">Key</param>
        /// <param name="newFunc">Function to create new TValue</param>
        /// <returns>Value of key or new value of TValue if not found</returns>
        public static TValue GetValueOrNew<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> newFunc)
        {
        	TValue value;

            if(dictionary.TryGetValue(key, out value))
            {
                return value;
            }
            
            return newFunc();
        }
    }
}