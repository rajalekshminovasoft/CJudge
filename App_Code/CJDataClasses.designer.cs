﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Tscout")]
public partial class CJDataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertInfokitDynamicContent(InfokitDynamicContent instance);
  partial void UpdateInfokitDynamicContent(InfokitDynamicContent instance);
  partial void DeleteInfokitDynamicContent(InfokitDynamicContent instance);
  #endregion
	
	public CJDataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TscoutConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public CJDataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public CJDataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public CJDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public CJDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<InfokitCategory> InfokitCategories
	{
		get
		{
			return this.GetTable<InfokitCategory>();
		}
	}
	
	public System.Data.Linq.Table<InfokitFileList> InfokitFileLists
	{
		get
		{
			return this.GetTable<InfokitFileList>();
		}
	}
	
	public System.Data.Linq.Table<InfokitDynamicContent> InfokitDynamicContents
	{
		get
		{
			return this.GetTable<InfokitDynamicContent>();
		}
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AddInfokitCategory")]
	public int AddInfokitCategory([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryId", DbType="Int")] System.Nullable<int> categoryId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryName", DbType="VarChar(250)")] string categoryName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DisplayOrder", DbType="Int")] System.Nullable<int> displayOrder, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CreatedBy", DbType="Int")] System.Nullable<int> createdBy)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), categoryId, categoryName, displayOrder, status, createdBy);
		return ((int)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AddInfokitFileDetails")]
	public int AddInfokitFileDetails([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FileId", DbType="Int")] System.Nullable<int> fileId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryId", DbType="Int")] System.Nullable<int> categoryId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DisplayName", DbType="VarChar(400)")] string displayName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InfoFileName", DbType="VarChar(400)")] string infoFileName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DisplayOrder", DbType="Int")] System.Nullable<int> displayOrder, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CreatedBy", DbType="Int")] System.Nullable<int> createdBy)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fileId, categoryId, displayName, infoFileName, displayOrder, status, createdBy);
		return ((int)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AddInfokitDynamicContent")]
	public int AddInfokitDynamicContent([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InfokitId", DbType="Int")] System.Nullable<int> infokitId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PhotoImage", DbType="NVarChar(400)")] string photoImage, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description1", DbType="NVarChar(MAX)")] string description1, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Image1", DbType="NVarChar(400)")] string image1, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description2", DbType="NVarChar(400)")] string description2, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Image2", DbType="NVarChar(400)")] string image2, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description3", DbType="NVarChar(400)")] string description3, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Image3", DbType="NVarChar(400)")] string image3, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description4", DbType="NVarChar(400)")] string description4, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Image4", DbType="NVarChar(400)")] string image4, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description5", DbType="NVarChar(400)")] string description5, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Image5", DbType="NVarChar(400)")] string image5, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CreatedBy", DbType="Int")] System.Nullable<int> createdBy)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), infokitId, photoImage, description1, image1, description2, image2, description3, image3, description4, image4, description5, image5, status, createdBy);
		return ((int)(result.ReturnValue));
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.InfokitCategory")]
public partial class InfokitCategory
{
	
	private int _CategoryId;
	
	private string _CategoryName;
	
	private System.Nullable<int> _DisplayOrder;
	
	private System.Nullable<int> _Status;
	
	private System.Nullable<System.DateTime> _CreatedOn;
	
	private System.Nullable<int> _CreatedBy;
	
	private System.Nullable<System.DateTime> _ModifiedOn;
	
	private System.Nullable<int> _ModifiedBy;
	
	public InfokitCategory()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryId", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
	public int CategoryId
	{
		get
		{
			return this._CategoryId;
		}
		set
		{
			if ((this._CategoryId != value))
			{
				this._CategoryId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryName", DbType="VarChar(400)")]
	public string CategoryName
	{
		get
		{
			return this._CategoryName;
		}
		set
		{
			if ((this._CategoryName != value))
			{
				this._CategoryName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DisplayOrder", DbType="Int")]
	public System.Nullable<int> DisplayOrder
	{
		get
		{
			return this._DisplayOrder;
		}
		set
		{
			if ((this._DisplayOrder != value))
			{
				this._DisplayOrder = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
	public System.Nullable<int> Status
	{
		get
		{
			return this._Status;
		}
		set
		{
			if ((this._Status != value))
			{
				this._Status = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedOn", DbType="DateTime")]
	public System.Nullable<System.DateTime> CreatedOn
	{
		get
		{
			return this._CreatedOn;
		}
		set
		{
			if ((this._CreatedOn != value))
			{
				this._CreatedOn = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedBy", DbType="Int")]
	public System.Nullable<int> CreatedBy
	{
		get
		{
			return this._CreatedBy;
		}
		set
		{
			if ((this._CreatedBy != value))
			{
				this._CreatedBy = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedOn", DbType="DateTime")]
	public System.Nullable<System.DateTime> ModifiedOn
	{
		get
		{
			return this._ModifiedOn;
		}
		set
		{
			if ((this._ModifiedOn != value))
			{
				this._ModifiedOn = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedBy", DbType="Int")]
	public System.Nullable<int> ModifiedBy
	{
		get
		{
			return this._ModifiedBy;
		}
		set
		{
			if ((this._ModifiedBy != value))
			{
				this._ModifiedBy = value;
			}
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.InfokitFileList")]
public partial class InfokitFileList
{
	
	private int _FileId;
	
	private System.Nullable<int> _CategoryId;
	
	private string _DisplayName;
	
	private string _InfoFileName;
	
	private System.Nullable<int> _DisplayOrder;
	
	private System.Nullable<int> _Status;
	
	private System.Nullable<System.DateTime> _CreatedOn;
	
	private System.Nullable<int> _CreatedBy;
	
	private System.Nullable<System.DateTime> _ModifiedOn;
	
	private System.Nullable<int> _ModifiedBy;
	
	public InfokitFileList()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileId", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
	public int FileId
	{
		get
		{
			return this._FileId;
		}
		set
		{
			if ((this._FileId != value))
			{
				this._FileId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryId", DbType="Int")]
	public System.Nullable<int> CategoryId
	{
		get
		{
			return this._CategoryId;
		}
		set
		{
			if ((this._CategoryId != value))
			{
				this._CategoryId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DisplayName", DbType="VarChar(400)")]
	public string DisplayName
	{
		get
		{
			return this._DisplayName;
		}
		set
		{
			if ((this._DisplayName != value))
			{
				this._DisplayName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InfoFileName", DbType="VarChar(400)")]
	public string InfoFileName
	{
		get
		{
			return this._InfoFileName;
		}
		set
		{
			if ((this._InfoFileName != value))
			{
				this._InfoFileName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DisplayOrder", DbType="Int")]
	public System.Nullable<int> DisplayOrder
	{
		get
		{
			return this._DisplayOrder;
		}
		set
		{
			if ((this._DisplayOrder != value))
			{
				this._DisplayOrder = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
	public System.Nullable<int> Status
	{
		get
		{
			return this._Status;
		}
		set
		{
			if ((this._Status != value))
			{
				this._Status = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedOn", DbType="DateTime")]
	public System.Nullable<System.DateTime> CreatedOn
	{
		get
		{
			return this._CreatedOn;
		}
		set
		{
			if ((this._CreatedOn != value))
			{
				this._CreatedOn = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedBy", DbType="Int")]
	public System.Nullable<int> CreatedBy
	{
		get
		{
			return this._CreatedBy;
		}
		set
		{
			if ((this._CreatedBy != value))
			{
				this._CreatedBy = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedOn", DbType="DateTime")]
	public System.Nullable<System.DateTime> ModifiedOn
	{
		get
		{
			return this._ModifiedOn;
		}
		set
		{
			if ((this._ModifiedOn != value))
			{
				this._ModifiedOn = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedBy", DbType="Int")]
	public System.Nullable<int> ModifiedBy
	{
		get
		{
			return this._ModifiedBy;
		}
		set
		{
			if ((this._ModifiedBy != value))
			{
				this._ModifiedBy = value;
			}
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.InfokitDynamicContents")]
public partial class InfokitDynamicContent : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _InfokitId;
	
	private string _PhotoImage;
	
	private string _Description1;
	
	private string _Image1;
	
	private string _Description2;
	
	private string _Image2;
	
	private string _Description3;
	
	private string _Image3;
	
	private string _Description4;
	
	private string _Image4;
	
	private string _Description5;
	
	private string _Image5;
	
	private System.Nullable<int> _CreatedBy;
	
	private System.Nullable<System.DateTime> _CreatedOn;
	
	private System.Nullable<int> _ModifiedBy;
	
	private System.Nullable<System.DateTime> _ModifiedOn;
	
	private System.Nullable<int> _Status;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnInfokitIdChanging(int value);
    partial void OnInfokitIdChanged();
    partial void OnPhotoImageChanging(string value);
    partial void OnPhotoImageChanged();
    partial void OnDescription1Changing(string value);
    partial void OnDescription1Changed();
    partial void OnImage1Changing(string value);
    partial void OnImage1Changed();
    partial void OnDescription2Changing(string value);
    partial void OnDescription2Changed();
    partial void OnImage2Changing(string value);
    partial void OnImage2Changed();
    partial void OnDescription3Changing(string value);
    partial void OnDescription3Changed();
    partial void OnImage3Changing(string value);
    partial void OnImage3Changed();
    partial void OnDescription4Changing(string value);
    partial void OnDescription4Changed();
    partial void OnImage4Changing(string value);
    partial void OnImage4Changed();
    partial void OnDescription5Changing(string value);
    partial void OnDescription5Changed();
    partial void OnImage5Changing(string value);
    partial void OnImage5Changed();
    partial void OnCreatedByChanging(System.Nullable<int> value);
    partial void OnCreatedByChanged();
    partial void OnCreatedOnChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedOnChanged();
    partial void OnModifiedByChanging(System.Nullable<int> value);
    partial void OnModifiedByChanged();
    partial void OnModifiedOnChanging(System.Nullable<System.DateTime> value);
    partial void OnModifiedOnChanged();
    partial void OnStatusChanging(System.Nullable<int> value);
    partial void OnStatusChanged();
    #endregion
	
	public InfokitDynamicContent()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InfokitId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int InfokitId
	{
		get
		{
			return this._InfokitId;
		}
		set
		{
			if ((this._InfokitId != value))
			{
				this.OnInfokitIdChanging(value);
				this.SendPropertyChanging();
				this._InfokitId = value;
				this.SendPropertyChanged("InfokitId");
				this.OnInfokitIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhotoImage", DbType="NVarChar(400)")]
	public string PhotoImage
	{
		get
		{
			return this._PhotoImage;
		}
		set
		{
			if ((this._PhotoImage != value))
			{
				this.OnPhotoImageChanging(value);
				this.SendPropertyChanging();
				this._PhotoImage = value;
				this.SendPropertyChanged("PhotoImage");
				this.OnPhotoImageChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description1", DbType="NVarChar(MAX)")]
	public string Description1
	{
		get
		{
			return this._Description1;
		}
		set
		{
			if ((this._Description1 != value))
			{
				this.OnDescription1Changing(value);
				this.SendPropertyChanging();
				this._Description1 = value;
				this.SendPropertyChanged("Description1");
				this.OnDescription1Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image1", DbType="NVarChar(400)")]
	public string Image1
	{
		get
		{
			return this._Image1;
		}
		set
		{
			if ((this._Image1 != value))
			{
				this.OnImage1Changing(value);
				this.SendPropertyChanging();
				this._Image1 = value;
				this.SendPropertyChanged("Image1");
				this.OnImage1Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description2", DbType="NVarChar(MAX)")]
	public string Description2
	{
		get
		{
			return this._Description2;
		}
		set
		{
			if ((this._Description2 != value))
			{
				this.OnDescription2Changing(value);
				this.SendPropertyChanging();
				this._Description2 = value;
				this.SendPropertyChanged("Description2");
				this.OnDescription2Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image2", DbType="NVarChar(400)")]
	public string Image2
	{
		get
		{
			return this._Image2;
		}
		set
		{
			if ((this._Image2 != value))
			{
				this.OnImage2Changing(value);
				this.SendPropertyChanging();
				this._Image2 = value;
				this.SendPropertyChanged("Image2");
				this.OnImage2Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description3", DbType="NVarChar(MAX)")]
	public string Description3
	{
		get
		{
			return this._Description3;
		}
		set
		{
			if ((this._Description3 != value))
			{
				this.OnDescription3Changing(value);
				this.SendPropertyChanging();
				this._Description3 = value;
				this.SendPropertyChanged("Description3");
				this.OnDescription3Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image3", DbType="NVarChar(400)")]
	public string Image3
	{
		get
		{
			return this._Image3;
		}
		set
		{
			if ((this._Image3 != value))
			{
				this.OnImage3Changing(value);
				this.SendPropertyChanging();
				this._Image3 = value;
				this.SendPropertyChanged("Image3");
				this.OnImage3Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description4", DbType="NVarChar(MAX)")]
	public string Description4
	{
		get
		{
			return this._Description4;
		}
		set
		{
			if ((this._Description4 != value))
			{
				this.OnDescription4Changing(value);
				this.SendPropertyChanging();
				this._Description4 = value;
				this.SendPropertyChanged("Description4");
				this.OnDescription4Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image4", DbType="NVarChar(400)")]
	public string Image4
	{
		get
		{
			return this._Image4;
		}
		set
		{
			if ((this._Image4 != value))
			{
				this.OnImage4Changing(value);
				this.SendPropertyChanging();
				this._Image4 = value;
				this.SendPropertyChanged("Image4");
				this.OnImage4Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description5", DbType="NVarChar(MAX)")]
	public string Description5
	{
		get
		{
			return this._Description5;
		}
		set
		{
			if ((this._Description5 != value))
			{
				this.OnDescription5Changing(value);
				this.SendPropertyChanging();
				this._Description5 = value;
				this.SendPropertyChanged("Description5");
				this.OnDescription5Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image5", DbType="NVarChar(400)")]
	public string Image5
	{
		get
		{
			return this._Image5;
		}
		set
		{
			if ((this._Image5 != value))
			{
				this.OnImage5Changing(value);
				this.SendPropertyChanging();
				this._Image5 = value;
				this.SendPropertyChanged("Image5");
				this.OnImage5Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedBy", DbType="Int")]
	public System.Nullable<int> CreatedBy
	{
		get
		{
			return this._CreatedBy;
		}
		set
		{
			if ((this._CreatedBy != value))
			{
				this.OnCreatedByChanging(value);
				this.SendPropertyChanging();
				this._CreatedBy = value;
				this.SendPropertyChanged("CreatedBy");
				this.OnCreatedByChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedOn", DbType="DateTime")]
	public System.Nullable<System.DateTime> CreatedOn
	{
		get
		{
			return this._CreatedOn;
		}
		set
		{
			if ((this._CreatedOn != value))
			{
				this.OnCreatedOnChanging(value);
				this.SendPropertyChanging();
				this._CreatedOn = value;
				this.SendPropertyChanged("CreatedOn");
				this.OnCreatedOnChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedBy", DbType="Int")]
	public System.Nullable<int> ModifiedBy
	{
		get
		{
			return this._ModifiedBy;
		}
		set
		{
			if ((this._ModifiedBy != value))
			{
				this.OnModifiedByChanging(value);
				this.SendPropertyChanging();
				this._ModifiedBy = value;
				this.SendPropertyChanged("ModifiedBy");
				this.OnModifiedByChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedOn", DbType="DateTime")]
	public System.Nullable<System.DateTime> ModifiedOn
	{
		get
		{
			return this._ModifiedOn;
		}
		set
		{
			if ((this._ModifiedOn != value))
			{
				this.OnModifiedOnChanging(value);
				this.SendPropertyChanging();
				this._ModifiedOn = value;
				this.SendPropertyChanged("ModifiedOn");
				this.OnModifiedOnChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
	public System.Nullable<int> Status
	{
		get
		{
			return this._Status;
		}
		set
		{
			if ((this._Status != value))
			{
				this.OnStatusChanging(value);
				this.SendPropertyChanging();
				this._Status = value;
				this.SendPropertyChanged("Status");
				this.OnStatusChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591
