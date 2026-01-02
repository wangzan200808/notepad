using System;
using SqlSugar;

namespace Notepad.Entitys
{
	// Token: 0x0200001A RID: 26
	public class CatalogFlie
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00005751 File Offset: 0x00003951
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00005759 File Offset: 0x00003959
		[SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
		public int Id { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00005762 File Offset: 0x00003962
		// (set) Token: 0x06000069 RID: 105 RVA: 0x0000576A File Offset: 0x0000396A
		public string Name { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00005773 File Offset: 0x00003973
		// (set) Token: 0x0600006B RID: 107 RVA: 0x0000577B File Offset: 0x0000397B
		public int ItemType { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00005784 File Offset: 0x00003984
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000578C File Offset: 0x0000398C
		public int ParentId { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00005795 File Offset: 0x00003995
		// (set) Token: 0x0600006F RID: 111 RVA: 0x0000579D File Offset: 0x0000399D
		public int Sort { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000057A6 File Offset: 0x000039A6
		// (set) Token: 0x06000071 RID: 113 RVA: 0x000057AE File Offset: 0x000039AE
		public DateTime CreateTime { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000057B7 File Offset: 0x000039B7
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000057BF File Offset: 0x000039BF
		public string Content { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000057C8 File Offset: 0x000039C8
		// (set) Token: 0x06000075 RID: 117 RVA: 0x000057D0 File Offset: 0x000039D0
		public int SysType { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000076 RID: 118 RVA: 0x000057D9 File Offset: 0x000039D9
		// (set) Token: 0x06000077 RID: 119 RVA: 0x000057E1 File Offset: 0x000039E1
		public int IsDelete { get; set; }
	}
}
