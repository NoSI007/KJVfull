#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace makeJson
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="KJVBible")]
	public partial class kjVDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public kjVDataContext() : 
				base(global::makeJson.Properties.Settings.Default.KJVBibleConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public kjVDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public kjVDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public kjVDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public kjVDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<json4section> json4sections
		{
			get
			{
				return this.GetTable<json4section>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.json4section")]
	public partial class json4section
	{
		
		private string _jsont;
		
		public json4section()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_jsont", DbType="NVarChar(MAX)")]
		public string jsont
		{
			get
			{
				return this._jsont;
			}
			set
			{
				if ((this._jsont != value))
				{
					this._jsont = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
