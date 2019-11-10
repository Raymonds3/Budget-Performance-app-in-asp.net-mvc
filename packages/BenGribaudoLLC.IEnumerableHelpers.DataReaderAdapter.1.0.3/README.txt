BenGribaudoLLC.IEnumerableHelpers.DataReaderAdapter


===========================================
What does it to?
===========================================
Adapts IEnumerable<T> to the IDataReader interface. Enables enumerable 
sequences to be used where a data reader is expected.

Great for loading data from a List<T>, LINQ expression or CSV parser 
into a database using SqlBulkCopy! Streams data to SqlBulkCopy, 
bypassing the need to first materialize the entire sequence in memory 
and load it into a DataTable.

	var data = from p in DataContext.People
				where o.Age >= 18
				select new { p.FirstName, p.LastName, p.Age};

	using (var bulkCopy = new SqlBulkCopy(connection)) {
	  bulkCopy.DestinationTableName = "Adults";
	  bulkCopy.WriteToServer(data.AsDataReader());
	}


===========================================
How does it work?
===========================================
Each item in the enumerable becomes a record returned by the data reader.

AsDataReader()
-------------------------------------------
Used when the enumerable contains IEnumerable<T>s. The items in the inner 
enumerable become the data record’s fields. Optionally, field names may 
be provided.

	var data = new[] {
	  new[] { "Joe", "Smith" },
	  new[] { "Bob", "Brown" }
	};
 
	var reader = data.AsDataReader();
	//var reader = data.AsDataReader(fieldNames: new[] { "FirstName", "LastName" });

	while (reader.Read())
	{
	  Console.WriteLine($"{reader.GetValue(0) } {reader.GetValue(1)}");
	  //Console.WriteLine($"{reader["FirstName"] } {reader["LastName"]}");
	}

	// Outputs:
	// Joe Smith
	// Bob Brown

AsDataReaderOfObjects()
-------------------------------------------
Used when the enumerable contains objects whose public readable 
instance properties should become the fields returned by the data
reader.

	var data = new[]
	{
	  new Item { ItemNumber = 1, Name = "Widget", Price = 10.00m },
	  new Item { ItemNumber = 2, Name = "Gadget", Price = 4.99m },
	};
 
	var reader = data.AsDataReaderOfObjects();
	while (reader.Read())
	{
	  var priceForTwo = reader.GetDecimal(reader.GetOrdinal("Price")) * 2;
	  Console.WriteLine($"Item # {reader["ItemNumber"]} - {priceForTwo:C2}");
	}

	// Outputs:
	// Item 1 - $20.00
	// Item 2 - $9.98


===========================================
Legal
===========================================

Package Copyright 2017 Ben Gribaudo, LLC <http://bengribaudo.com>
Package License Agreement: https://opensource.org/licenses/MIT

===========================================
Notes
===========================================
* .Net Standard 1.6's SqlBulkCopy.WriteToServer() does not work with
  IDataReader, limiting this package's usefulness on that platform. 
* This package's data reader implementation does not support  
  IDataReader.GetSchemaTable().