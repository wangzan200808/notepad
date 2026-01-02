using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Notepad.Comm;
using Notepad.Entitys;
using Notepad.Properties;
using SqlSugar;
using Sunny.UI;

namespace Notepad
{
	// Token: 0x02000006 RID: 6
	public partial class Frm_Main : Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002326 File Offset: 0x00000526
		public Frm_Main()
		{
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.InitializeComponent();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002341 File Offset: 0x00000541
		private void Frm_Main_Load(object sender, EventArgs e)
		{
			this.LoadUpgrade();
			this.LoadTree();
			this.Text = string.Format(this.Text, base.Tag);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002368 File Offset: 0x00000568
		private void LoadUpgrade()
		{
			base.Tag.ToString();
			try
			{
				if (SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().ToList().Exists((CatalogFlie x) => x.SysType == 1))
				{
					return;
				}
			}
			catch
			{
				string text = "ALTER TABLE \"main\".\"CatalogFlie\" RENAME TO \"_CatalogFlie_old_20210922\";";
				string text2 = "CREATE TABLE \"main\".\"CatalogFlie\" (\"Id\" INTEGER PRIMARY KEY AUTOINCREMENT,\"Name\" VARCHAR (300),\"ItemType\" INTEGER (11),\"ParentId\" INTEGER (11),\"Sort\" INTEGER (11),\"CreateTime\" DATE,\"Content\" TEXT,\"SysType\" integer(11) DEFAULT 0,\"IsDelete\" integer(11) DEFAULT 0); ";
				string text3 = "INSERT INTO \"main\".\"sqlite_sequence\" (name, seq) VALUES ('CatalogFlie', '2');";
				string text4 = "INSERT INTO \"main\".\"CatalogFlie\" (\"Id\", \"Name\", \"ItemType\", \"ParentId\", \"Sort\", \"CreateTime\", \"Content\") SELECT \"Id\", \"Name\", \"ItemType\", \"ParentId\", \"Sort\", \"CreateTime\", \"Content\" FROM \"main\".\"_CatalogFlie_old_20210922\";";
				SqlSugarHelper.GetInstance().Ado.ExecuteCommand(text, Array.Empty<SugarParameter>());
				SqlSugarHelper.GetInstance().Ado.ExecuteCommand(text2, Array.Empty<SugarParameter>());
				SqlSugarHelper.GetInstance().Ado.ExecuteCommand(text3, Array.Empty<SugarParameter>());
				SqlSugarHelper.GetInstance().Ado.ExecuteCommand(text4, Array.Empty<SugarParameter>());
			}
			CatalogFlie catalogFlie = new CatalogFlie
			{
				Name = "回收站",
				ItemType = 1,
				ParentId = 0,
				Sort = 999,
				CreateTime = DateTime.Now,
				Content = "",
				IsDelete = 0,
				SysType = 1
			};
			SqlSugarHelper.GetInstance().Insertable<CatalogFlie>(catalogFlie).ExecuteCommand();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024A4 File Offset: 0x000006A4
		private void LoadTree()
		{
			Frm_Main.<>c__DisplayClass3_0 CS$<>8__locals1 = new Frm_Main.<>c__DisplayClass3_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.keyword = this.txt_keyword.Text.Trim();
			this.txt_info.Text = string.Empty;
			UITreeView uitreeView = this.tv_lst;
			if (uitreeView != null)
			{
				TreeNodeCollection nodes = uitreeView.Nodes;
				if (nodes != null)
				{
					nodes.Clear();
				}
			}
			List<CatalogFlie> list = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().WhereIF(!string.IsNullOrWhiteSpace(CS$<>8__locals1.keyword), (CatalogFlie x) => x.ItemType == 2).WhereIF(!string.IsNullOrWhiteSpace(CS$<>8__locals1.keyword), (CatalogFlie x) => x.Name.Contains(CS$<>8__locals1.keyword) || x.Content.Contains(CS$<>8__locals1.keyword)).ToList();
			if (!string.IsNullOrWhiteSpace(CS$<>8__locals1.keyword))
			{
				list.ForEach(delegate(CatalogFlie x)
				{
					x.ParentId = 0;
				});
			}
			CS$<>8__locals1.selNode = null;
			TreeNode[] nodes2 = CS$<>8__locals1.<LoadTree>g__BuildTree|3(0, list);
			this.tv_lst.Nodes.AddRange(nodes2);
			this.tv_lst.ExpandAll();
			TreeNode selNode = CS$<>8__locals1.selNode;
			if (!string.IsNullOrWhiteSpace((selNode != null) ? selNode.Name : null))
			{
				this.tv_lst.SelectedNode = CS$<>8__locals1.selNode;
				this.txt_info.Enabled = true;
				int id = StringEx.ToInt(CS$<>8__locals1.selNode.Name, 0);
				CatalogFlie catalogFlie = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
				this.txt_info.Text = catalogFlie.Content;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000278B File Offset: 0x0000098B
		private void tv_lst_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.ImageIndex == 3)
			{
				e.Node.ImageIndex = 3;
				return;
			}
			e.Node.ImageIndex = (e.Node.IsExpanded ? 0 : 1);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000278B File Offset: 0x0000098B
		private void tv_lst_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.ImageIndex == 3)
			{
				e.Node.ImageIndex = 3;
				return;
			}
			e.Node.ImageIndex = (e.Node.IsExpanded ? 0 : 1);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000027C4 File Offset: 0x000009C4
		private void 新建根目录toolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string text = "新建目录";
				if (UIInputDialog.InputStringDialog(ref text, false, "请输入新的目录名", 1, false))
				{
					if (string.IsNullOrWhiteSpace(text))
					{
						text = "新建目录";
					}
					CatalogFlie catalogFlie = new CatalogFlie
					{
						Name = text,
						ItemType = 1,
						ParentId = 0,
						Sort = 0,
						CreateTime = DateTime.Now,
						Content = "",
						IsDelete = 0,
						SysType = 0
					};
					if (this.tv_lst.SelectedNode != null)
					{
						int num = (from x in SqlSugarHelper.GetInstance().Queryable<CatalogFlie>()
						where x.ParentId == catalogFlie.ParentId
						select x).Max<int>((CatalogFlie x) => x.Sort);
						catalogFlie.Sort = num + 1;
					}
					if (SqlSugarHelper.GetInstance().Insertable<CatalogFlie>(catalogFlie).ExecuteCommand() > 0)
					{
						UIMessageTip.ShowOk("添加目录成功", -1, null, null, false);
						this.LoadTree();
					}
					else
					{
						UIMessageTip.ShowError("添加目录失败", 1000, new bool?(false), null, false);
					}
				}
			}
			catch (Exception)
			{
				UIMessageTip.ShowError("失败，出现异常", 1000, new bool?(false), null, false);
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000029CC File Offset: 0x00000BCC
		private void 新建目录ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string text = "新建目录";
				if (UIInputDialog.InputStringDialog(ref text, false, "请输入新的目录名", 1, false))
				{
					if (string.IsNullOrWhiteSpace(text))
					{
						text = "新建目录";
					}
					CatalogFlie catalogFlie = new CatalogFlie
					{
						Name = text,
						ItemType = 1,
						ParentId = 0,
						Sort = 0,
						CreateTime = DateTime.Now,
						Content = "",
						IsDelete = 0,
						SysType = 0
					};
					TreeNode selectedNode = this.tv_lst.SelectedNode;
					if (selectedNode != null)
					{
						int id = StringEx.ToInt(selectedNode.Name, 0);
						CatalogFlie catalogFlie2 = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
						if (catalogFlie2.ItemType == 1)
						{
							catalogFlie.ParentId = catalogFlie2.Id;
						}
						else
						{
							catalogFlie.ParentId = catalogFlie2.ParentId;
						}
						int num = (from x in SqlSugarHelper.GetInstance().Queryable<CatalogFlie>()
						where x.ParentId == catalogFlie.ParentId
						select x).Max<int>((CatalogFlie x) => x.Sort);
						catalogFlie.Sort = num + 1;
					}
					if (SqlSugarHelper.GetInstance().Insertable<CatalogFlie>(catalogFlie).ExecuteCommand() > 0)
					{
						UIMessageTip.ShowOk("添加目录成功", -1, null, null, false);
						this.LoadTree();
					}
					else
					{
						UIMessageTip.ShowError("添加目录失败", 1000, new bool?(false), null, false);
					}
				}
			}
			catch (Exception)
			{
				UIMessageTip.ShowError("失败，出现异常", 1000, new bool?(false), null, false);
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002C98 File Offset: 0x00000E98
		private void 编辑目录ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeNode selectedNode = this.tv_lst.SelectedNode;
				if (selectedNode != null)
				{
					int id = StringEx.ToInt(selectedNode.Name, 0);
					CatalogFlie catalogFlie = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
					if (catalogFlie != null)
					{
						string name = catalogFlie.Name;
						if (UIInputDialog.InputStringDialog(ref name, false, "请输入新的名称", 1, false))
						{
							if (string.IsNullOrWhiteSpace(name))
							{
								UIMessageTip.ShowError("修改失败，不能为空", 1000, new bool?(false), null, false);
							}
							else
							{
								catalogFlie.Name = name;
								if (SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(catalogFlie).UpdateColumns((CatalogFlie it) => new
								{
									it.Name
								}).ExecuteCommand() > 0)
								{
									UIMessageTip.ShowOk("修改成功", -1, null, null, false);
									this.LoadTree();
								}
								else
								{
									UIMessageTip.ShowError("修改失败", 1000, new bool?(false), null, false);
								}
							}
						}
					}
				}
			}
			catch (Exception)
			{
				UIMessageTip.ShowError("失败，出现异常", 1000, new bool?(false), null, false);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002EB8 File Offset: 0x000010B8
		private void 删除目录ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeNode selectedNode = this.tv_lst.SelectedNode;
				if (selectedNode != null)
				{
					int id = StringEx.ToInt(selectedNode.Name, 0);
					CatalogFlie selnode = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
					if (selnode != null)
					{
						if (selnode.SysType != 1)
						{
							if (UIMessageDialog.ShowMessageDialog(this, "确定删除[" + selnode.Name + "]？下级将自动升级", "删除提示", true, 1))
							{
								CatalogFlie catalogFlie = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == selnode.ParentId);
								CatalogFlie catalogFlie2 = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.SysType == 1);
								if (catalogFlie != null && catalogFlie.SysType == 1)
								{
									SqlSugarHelper.GetInstance().Deleteable<CatalogFlie>(selnode).ExecuteCommand();
								}
								else
								{
									selnode.ParentId = catalogFlie2.Id;
									SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(selnode).UpdateColumns((CatalogFlie it) => new
									{
										it.ParentId
									}).ExecuteCommand();
								}
								List<CatalogFlie> list = (from x in SqlSugarHelper.GetInstance().Queryable<CatalogFlie>()
								where x.ParentId == selnode.Id
								select x).ToList();
								if (list.Count > 0)
								{
									list.ForEach(delegate(CatalogFlie x)
									{
										x.ParentId = selnode.ParentId;
									});
									SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(list).UpdateColumns((CatalogFlie it) => new
									{
										it.ParentId
									}).ExecuteCommand();
								}
								List<CatalogFlie> list2 = (from x in SqlSugarHelper.GetInstance().Queryable<CatalogFlie>()
								where x.ParentId == selnode.ParentId
								select x).OrderBy((CatalogFlie x) => (object)x.Id, 0).ToList();
								if (list2.Count > 0)
								{
									for (int i = 0; i < list2.Count; i++)
									{
										list2[i].Sort = i;
									}
									SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(list2).UpdateColumns((CatalogFlie it) => new
									{
										it.Sort
									}).ExecuteCommand();
								}
								UIMessageTip.ShowOk("删除成功", -1, null, null, false);
								this.LoadTree();
							}
						}
					}
				}
			}
			catch (Exception)
			{
				UIMessageTip.ShowError("失败，出现异常", 1000, new bool?(false), null, false);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000034B0 File Offset: 0x000016B0
		private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LoadTree();
			UIMessageTip.ShowOk("刷新成功", -1, null, null, false);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000034E4 File Offset: 0x000016E4
		private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeNode selectedNode = this.tv_lst.SelectedNode;
				if (selectedNode != null)
				{
					TreeNode prevNode = selectedNode.PrevNode;
					if (prevNode == null)
					{
						UIMessageTip.ShowWarning("不能再向上移动了", 1000, new bool?(false), null, false);
					}
					else
					{
						int id = StringEx.ToInt(selectedNode.Name, 0);
						int previd = StringEx.ToInt(prevNode.Name, 0);
						CatalogFlie catalogFlie = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
						CatalogFlie catalogFlie2 = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == previd);
						if (catalogFlie.ParentId != catalogFlie2.ParentId)
						{
							UIMessageTip.ShowWarning("不能再向上移动了", 1000, new bool?(false), null, false);
						}
						else
						{
							int sort = catalogFlie.Sort;
							catalogFlie.Sort = catalogFlie2.Sort;
							catalogFlie2.Sort = sort;
							SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(catalogFlie).UpdateColumns((CatalogFlie it) => new
							{
								it.Sort
							}).ExecuteCommand();
							SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(catalogFlie2).UpdateColumns((CatalogFlie it) => new
							{
								it.Sort
							}).ExecuteCommand();
							UIMessageTip.ShowOk("上移成功", -1, null, null, false);
							this.LoadTree();
						}
					}
				}
			}
			catch (Exception)
			{
				UIMessageTip.ShowError("失败，出现异常", 1000, new bool?(false), null, false);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000381C File Offset: 0x00001A1C
		private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeNode selectedNode = this.tv_lst.SelectedNode;
				if (selectedNode != null)
				{
					TreeNode nextNode = selectedNode.NextNode;
					if (nextNode == null)
					{
						UIMessageTip.ShowWarning("不能再向下移动了", 1000, new bool?(false), null, false);
					}
					else
					{
						int id = StringEx.ToInt(selectedNode.Name, 0);
						int previd = StringEx.ToInt(nextNode.Name, 0);
						CatalogFlie catalogFlie = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
						CatalogFlie catalogFlie2 = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == previd);
						if (catalogFlie.ParentId != catalogFlie2.ParentId)
						{
							UIMessageTip.ShowWarning("不能再向下移动了", 1000, new bool?(false), null, false);
						}
						else
						{
							int sort = catalogFlie.Sort;
							catalogFlie.Sort = catalogFlie2.Sort;
							catalogFlie2.Sort = sort;
							SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(catalogFlie).UpdateColumns((CatalogFlie it) => new
							{
								it.Sort
							}).ExecuteCommand();
							SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(catalogFlie2).UpdateColumns((CatalogFlie it) => new
							{
								it.Sort
							}).ExecuteCommand();
							UIMessageTip.ShowOk("下移成功", -1, null, null, false);
							this.LoadTree();
						}
					}
				}
			}
			catch (Exception)
			{
				UIMessageTip.ShowError("失败，出现异常", 1000, new bool?(false), null, false);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003B54 File Offset: 0x00001D54
		private void txt_keyword_TextChanged(object sender, EventArgs e)
		{
			this.LoadTree();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003B5C File Offset: 0x00001D5C
		private void tv_lst_ItemDrag(object sender, ItemDragEventArgs e)
		{
			TreeNode data = e.Item as TreeNode;
			base.DoDragDrop(data, DragDropEffects.Move);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003B80 File Offset: 0x00001D80
		private void tv_lst_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TreeNode)))
			{
				TreeNode treeNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
				int id = StringEx.ToInt(treeNode.Name, 0);
				CatalogFlie catalogFlie = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
				this.Position.X = e.X;
				this.Position.Y = e.Y;
				this.Position = this.tv_lst.PointToClient(this.Position);
				TreeNode nodeAt = this.tv_lst.GetNodeAt(this.Position);
				if (nodeAt != null && nodeAt.Parent != treeNode && nodeAt != treeNode && nodeAt.Tag.ToString() == "1")
				{
					catalogFlie.ParentId = StringEx.ToInt(nodeAt.Name, 0);
				}
				if (nodeAt == null)
				{
					catalogFlie.ParentId = 0;
				}
				SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(catalogFlie).UpdateColumns((CatalogFlie it) => new
				{
					it.ParentId
				}).ExecuteCommand();
				this.LoadTree();
				return;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003D71 File Offset: 0x00001F71
		private void tv_lst_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TreeNode)))
			{
				e.Effect = DragDropEffects.Move;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003D9C File Offset: 0x00001F9C
		private void 新建文件ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string text = "新建文档";
				if (UIInputDialog.InputStringDialog(ref text, false, "请输入新的文档名", 1, false))
				{
					if (string.IsNullOrWhiteSpace(text))
					{
						text = "新建文档";
					}
					CatalogFlie catalogFlie = new CatalogFlie
					{
						Name = text,
						ItemType = 2,
						ParentId = 0,
						Sort = 0,
						CreateTime = DateTime.Now,
						Content = "",
						IsDelete = 0,
						SysType = 0
					};
					TreeNode selectedNode = this.tv_lst.SelectedNode;
					if (selectedNode != null)
					{
						int id = StringEx.ToInt(selectedNode.Name, 0);
						CatalogFlie catalogFlie2 = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
						if (catalogFlie2.ItemType == 1)
						{
							catalogFlie.ParentId = catalogFlie2.Id;
						}
						else
						{
							catalogFlie.ParentId = catalogFlie2.ParentId;
						}
						int num = (from x in SqlSugarHelper.GetInstance().Queryable<CatalogFlie>()
						where x.ParentId == catalogFlie.ParentId
						select x).Max<int>((CatalogFlie x) => x.Sort);
						catalogFlie.Sort = num + 1;
					}
					if (SqlSugarHelper.GetInstance().Insertable<CatalogFlie>(catalogFlie).ExecuteCommand() > 0)
					{
						UIMessageTip.ShowOk("添加文档成功", -1, null, null, false);
						this.LoadTree();
					}
					else
					{
						UIMessageTip.ShowError("添加文档失败", 1000, new bool?(false), null, false);
					}
				}
			}
			catch (Exception)
			{
				UIMessageTip.ShowError("失败，出现异常", 1000, new bool?(false), null, false);
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00004068 File Offset: 0x00002268
		private void Frm_Main_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
			{
				if (this.Save(false))
				{
					UIMessageTip.ShowOk("保存成功", -1, null, null, false);
					return;
				}
			}
			else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
			{
				this.新建文件ToolStripMenuItem_Click(sender, e);
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000040D3 File Offset: 0x000022D3
		private void tv_lst_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				this.删除目录ToolStripMenuItem_Click(sender, e);
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000040E7 File Offset: 0x000022E7
		private void time_save_Tick(object sender, EventArgs e)
		{
			this.Save(true);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000040F4 File Offset: 0x000022F4
		private bool Save(bool autosave = false)
		{
			TreeNode selectedNode = this.tv_lst.SelectedNode;
			if (selectedNode == null)
			{
				return false;
			}
			int id = StringEx.ToInt(selectedNode.Name, 0);
			CatalogFlie catalogFlie = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
			if (catalogFlie == null || catalogFlie.ItemType == 1)
			{
				return false;
			}
			catalogFlie.Content = this.txt_info.Text;
			return (!autosave || !string.IsNullOrWhiteSpace(catalogFlie.Content)) && SqlSugarHelper.GetInstance().Updateable<CatalogFlie>(catalogFlie).UpdateColumns((CatalogFlie it) => new
			{
				it.Content
			}).ExecuteCommand() > 0;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00004258 File Offset: 0x00002458
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Tab)
			{
				if (this.txt_info.Enabled)
				{
					int selectionStart = this.txt_info.SelectionStart;
					this.txt_info.Text = this.txt_info.Text.Insert(selectionStart, "\t");
					this.txt_info.SelectionStart = selectionStart + 1;
				}
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000042BC File Offset: 0x000024BC
		private void tv_lst_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag.ToString() == "1")
			{
				this.txt_info.Text = "";
				this.txt_info.Enabled = false;
				return;
			}
			this.txt_info.Enabled = true;
			int id = StringEx.ToInt(e.Node.Name, 0);
			CatalogFlie catalogFlie = SqlSugarHelper.GetInstance().Queryable<CatalogFlie>().First((CatalogFlie x) => x.Id == id);
			this.txt_info.Text = catalogFlie.Content;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000043A9 File Offset: 0x000025A9
		private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.txt_info.SelectAll();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000043B8 File Offset: 0x000025B8
		private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendKeys.SendWait("^C");
			UIMessageTip.ShowOk("已复制", -1, null, null, false);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000043ED File Offset: 0x000025ED
		private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendKeys.SendWait("^V");
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000043F9 File Offset: 0x000025F9
		private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendKeys.SendWait("^X");
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004405 File Offset: 0x00002605
		private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.txt_info.Text = "";
		}

		// Token: 0x04000005 RID: 5
		private Point Position = new Point(0, 0);
	}
}
