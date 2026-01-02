using System;
using SqlSugar;

namespace Notepad.Comm
{
	// Token: 0x0200001B RID: 27
	public static class SqlSugarHelper
	{
		// Token: 0x06000079 RID: 121 RVA: 0x000057EA File Offset: 0x000039EA
		public static SqlSugarClient GetInstance()
		{
			return new SqlSugarClient(new ConnectionConfig
			{
				ConnectionString = "Data Source=|DataDirectory|\\AppData\\DataBase.db;",
				DbType = 2,
				IsAutoCloseConnection = true,
				InitKeyType = 1
			});
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00005818 File Offset: 0x00003A18
		public static bool ToBool(this object value)
		{
			bool result;
			try
			{
				if (value == null || value == DBNull.Value)
				{
					result = false;
				}
				else
				{
					result = Convert.ToBoolean(value);
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005854 File Offset: 0x00003A54
		public static int ToInt(this object value)
		{
			int result;
			try
			{
				if (value == null || value == DBNull.Value)
				{
					result = 0;
				}
				else
				{
					result = Convert.ToInt32(value);
				}
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005890 File Offset: 0x00003A90
		public static decimal ToDecimal(this object value)
		{
			decimal result;
			try
			{
				if (value == null || value == DBNull.Value)
				{
					result = 0m;
				}
				else
				{
					result = Convert.ToDecimal(value);
				}
			}
			catch (Exception)
			{
				result = 0m;
			}
			return result;
		}
	}
}
