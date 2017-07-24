using System.Collections.Generic;
using System.Data;

namespace Extensions
{
	public static class DataReaderExtensions
	{
		/// <summary>
		/// Convert reader to records, for easy LINQ access.
		/// </summary>
		/// <example>
		/// var items = reader.GetRecords().Select(r => new { Id = (int)r["Id"], name = (string)r["name"]}).ToArray();
		/// </example>
		/// <param name="reader">IDataReader</param>
		/// <returns>IEnumerable of IDataRecord</returns>
		public static IEnumerable<IDataRecord> GetRecords(this IDataReader reader)
		{
			while(reader.Read())
			{
				yield return reader;
			}
		}
	}
	
}