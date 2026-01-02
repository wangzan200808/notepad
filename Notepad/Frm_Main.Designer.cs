namespace Notepad
{
	// Token: 0x02000006 RID: 6
	public partial class Frm_Main : global::System.Windows.Forms.Form
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00004417 File Offset: 0x00002617
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004438 File Offset: 0x00002638
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Notepad.Frm_Main));
			this.tv_lst = new global::Sunny.UI.UITreeView();
			this.cms_dir = new global::Sunny.UI.UIContextMenuStrip();
			this.新建文件ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.新建根目录toolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.新建目录ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.编辑目录ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.删除目录ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.上移ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.下移ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new global::System.Windows.Forms.ToolStripSeparator();
			this.刷新ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.img_lst = new global::System.Windows.Forms.ImageList(this.components);
			this.cms_txt = new global::Sunny.UI.UIContextMenuStrip();
			this.全选ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.复制ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.粘贴ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.剪切ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.清空ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.time_save = new global::System.Windows.Forms.Timer(this.components);
			this.txt_info = new global::Sunny.UI.UIRichTextBox();
			this.splitter1 = new global::System.Windows.Forms.Splitter();
			this.uiPanel1 = new global::Sunny.UI.UIPanel();
			this.txt_keyword = new global::Sunny.UI.UITextBox();
			this.cms_dir.SuspendLayout();
			this.cms_txt.SuspendLayout();
			this.uiPanel1.SuspendLayout();
			base.SuspendLayout();
			this.tv_lst.AllowDrop = true;
			this.tv_lst.ContextMenuStrip = this.cms_dir;
			this.tv_lst.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tv_lst.FillColor = global::System.Drawing.Color.White;
			this.tv_lst.Font = new global::System.Drawing.Font("微软雅黑", 12f);
			this.tv_lst.ImageIndex = 0;
			this.tv_lst.ImageList = this.img_lst;
			this.tv_lst.Location = new global::System.Drawing.Point(0, 29);
			this.tv_lst.Margin = new global::System.Windows.Forms.Padding(0, 5, 4, 5);
			this.tv_lst.MinimumSize = new global::System.Drawing.Size(1, 1);
			this.tv_lst.Name = "tv_lst";
			this.tv_lst.SelectedImageIndex = 0;
			this.tv_lst.SelectedNode = null;
			this.tv_lst.ShowLines = true;
			this.tv_lst.ShowPlusMinus = false;
			this.tv_lst.Size = new global::System.Drawing.Size(270, 644);
			this.tv_lst.TabIndex = 0;
			this.tv_lst.Text = null;
			this.tv_lst.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.tv_lst.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tv_lst_KeyDown);
			this.tv_lst.BeforeCollapse += new global::System.Windows.Forms.TreeViewCancelEventHandler(this.tv_lst_BeforeCollapse);
			this.tv_lst.BeforeExpand += new global::System.Windows.Forms.TreeViewCancelEventHandler(this.tv_lst_BeforeExpand);
			this.tv_lst.ItemDrag += new global::System.Windows.Forms.ItemDragEventHandler(this.tv_lst_ItemDrag);
			this.tv_lst.NodeMouseClick += new global::System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_lst_NodeMouseClick);
			this.tv_lst.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.tv_lst_DragDrop);
			this.tv_lst.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.tv_lst_DragEnter);
			this.cms_dir.Font = new global::System.Drawing.Font("微软雅黑", 12f);
			this.cms_dir.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.新建文件ToolStripMenuItem,
				this.toolStripSeparator1,
				this.新建根目录toolStripMenuItem,
				this.新建目录ToolStripMenuItem,
				this.编辑目录ToolStripMenuItem,
				this.删除目录ToolStripMenuItem,
				this.toolStripSeparator4,
				this.上移ToolStripMenuItem,
				this.下移ToolStripMenuItem,
				this.toolStripSeparator6,
				this.刷新ToolStripMenuItem
			});
			this.cms_dir.Name = "cms_dir";
			this.cms_dir.Size = new global::System.Drawing.Size(177, 230);
			this.新建文件ToolStripMenuItem.Image = global::Notepad.Properties.Resources._4;
			this.新建文件ToolStripMenuItem.Name = "新建文件ToolStripMenuItem";
			this.新建文件ToolStripMenuItem.Size = new global::System.Drawing.Size(176, 26);
			this.新建文件ToolStripMenuItem.Text = "新建文件";
			this.新建文件ToolStripMenuItem.Click += new global::System.EventHandler(this.新建文件ToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(173, 6);
			this.新建根目录toolStripMenuItem.Image = global::Notepad.Properties.Resources._3;
			this.新建根目录toolStripMenuItem.Name = "新建根目录toolStripMenuItem";
			this.新建根目录toolStripMenuItem.Size = new global::System.Drawing.Size(176, 26);
			this.新建根目录toolStripMenuItem.Text = "新建根目录";
			this.新建根目录toolStripMenuItem.Click += new global::System.EventHandler(this.新建根目录toolStripMenuItem_Click);
			this.新建目录ToolStripMenuItem.Image = global::Notepad.Properties.Resources._3;
			this.新建目录ToolStripMenuItem.Name = "新建目录ToolStripMenuItem";
			this.新建目录ToolStripMenuItem.Size = new global::System.Drawing.Size(176, 26);
			this.新建目录ToolStripMenuItem.Text = "新建下级目录";
			this.新建目录ToolStripMenuItem.Click += new global::System.EventHandler(this.新建目录ToolStripMenuItem_Click);
			this.编辑目录ToolStripMenuItem.Image = global::Notepad.Properties.Resources._6;
			this.编辑目录ToolStripMenuItem.Name = "编辑目录ToolStripMenuItem";
			this.编辑目录ToolStripMenuItem.Size = new global::System.Drawing.Size(176, 26);
			this.编辑目录ToolStripMenuItem.Text = "编辑";
			this.编辑目录ToolStripMenuItem.Click += new global::System.EventHandler(this.编辑目录ToolStripMenuItem_Click);
			this.删除目录ToolStripMenuItem.Image = global::Notepad.Properties.Resources._7;
			this.删除目录ToolStripMenuItem.Name = "删除目录ToolStripMenuItem";
			this.删除目录ToolStripMenuItem.Size = new global::System.Drawing.Size(176, 26);
			this.删除目录ToolStripMenuItem.Text = "删除";
			this.删除目录ToolStripMenuItem.Click += new global::System.EventHandler(this.删除目录ToolStripMenuItem_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new global::System.Drawing.Size(173, 6);
			this.上移ToolStripMenuItem.Image = global::Notepad.Properties.Resources._14;
			this.上移ToolStripMenuItem.Name = "上移ToolStripMenuItem";
			this.上移ToolStripMenuItem.Size = new global::System.Drawing.Size(176, 26);
			this.上移ToolStripMenuItem.Text = "上移";
			this.上移ToolStripMenuItem.Click += new global::System.EventHandler(this.上移ToolStripMenuItem_Click);
			this.下移ToolStripMenuItem.Image = global::Notepad.Properties.Resources._15;
			this.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem";
			this.下移ToolStripMenuItem.Size = new global::System.Drawing.Size(176, 26);
			this.下移ToolStripMenuItem.Text = "下移";
			this.下移ToolStripMenuItem.Click += new global::System.EventHandler(this.下移ToolStripMenuItem_Click);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new global::System.Drawing.Size(173, 6);
			this.刷新ToolStripMenuItem.Image = global::Notepad.Properties.Resources._16;
			this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
			this.刷新ToolStripMenuItem.Size = new global::System.Drawing.Size(176, 26);
			this.刷新ToolStripMenuItem.Text = "刷新";
			this.刷新ToolStripMenuItem.Click += new global::System.EventHandler(this.刷新ToolStripMenuItem_Click);
			this.img_lst.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("img_lst.ImageStream");
			this.img_lst.TransparentColor = global::System.Drawing.Color.Transparent;
			this.img_lst.Images.SetKeyName(0, "1.png");
			this.img_lst.Images.SetKeyName(1, "2.png");
			this.img_lst.Images.SetKeyName(2, "5.png");
			this.img_lst.Images.SetKeyName(3, "7.png");
			this.cms_txt.Font = new global::System.Drawing.Font("微软雅黑", 12f);
			this.cms_txt.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.全选ToolStripMenuItem,
				this.toolStripSeparator3,
				this.复制ToolStripMenuItem,
				this.粘贴ToolStripMenuItem,
				this.剪切ToolStripMenuItem,
				this.toolStripSeparator2,
				this.清空ToolStripMenuItem
			});
			this.cms_txt.Name = "cms_dir";
			this.cms_txt.Size = new global::System.Drawing.Size(113, 146);
			this.全选ToolStripMenuItem.Image = global::Notepad.Properties.Resources._13;
			this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
			this.全选ToolStripMenuItem.Size = new global::System.Drawing.Size(112, 26);
			this.全选ToolStripMenuItem.Text = "全选";
			this.全选ToolStripMenuItem.Click += new global::System.EventHandler(this.全选ToolStripMenuItem_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new global::System.Drawing.Size(109, 6);
			this.复制ToolStripMenuItem.Image = global::Notepad.Properties.Resources._9;
			this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
			this.复制ToolStripMenuItem.Size = new global::System.Drawing.Size(112, 26);
			this.复制ToolStripMenuItem.Text = "复制";
			this.复制ToolStripMenuItem.Click += new global::System.EventHandler(this.复制ToolStripMenuItem_Click);
			this.粘贴ToolStripMenuItem.Image = global::Notepad.Properties.Resources._11;
			this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
			this.粘贴ToolStripMenuItem.Size = new global::System.Drawing.Size(112, 26);
			this.粘贴ToolStripMenuItem.Text = "粘贴";
			this.粘贴ToolStripMenuItem.Click += new global::System.EventHandler(this.粘贴ToolStripMenuItem_Click);
			this.剪切ToolStripMenuItem.Image = global::Notepad.Properties.Resources._10;
			this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
			this.剪切ToolStripMenuItem.Size = new global::System.Drawing.Size(112, 26);
			this.剪切ToolStripMenuItem.Text = "剪切";
			this.剪切ToolStripMenuItem.Click += new global::System.EventHandler(this.剪切ToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(109, 6);
			this.清空ToolStripMenuItem.Image = global::Notepad.Properties.Resources._12;
			this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
			this.清空ToolStripMenuItem.Size = new global::System.Drawing.Size(112, 26);
			this.清空ToolStripMenuItem.Text = "清空";
			this.清空ToolStripMenuItem.Click += new global::System.EventHandler(this.清空ToolStripMenuItem_Click);
			this.time_save.Interval = 5000;
			this.time_save.Tick += new global::System.EventHandler(this.time_save_Tick);
			this.txt_info.AutoWordSelection = true;
			this.txt_info.ContextMenuStrip = this.cms_txt;
			this.txt_info.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txt_info.FillColor = global::System.Drawing.Color.White;
			this.txt_info.Font = new global::System.Drawing.Font("微软雅黑", 12f);
			this.txt_info.Location = new global::System.Drawing.Point(270, 0);
			this.txt_info.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txt_info.MinimumSize = new global::System.Drawing.Size(1, 1);
			this.txt_info.Name = "txt_info";
			this.txt_info.Padding = new global::System.Windows.Forms.Padding(10, 2, 2, 2);
			this.txt_info.Size = new global::System.Drawing.Size(903, 673);
			this.txt_info.Style = 0;
			this.txt_info.TabIndex = 0;
			this.txt_info.TabStop = false;
			this.txt_info.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.txt_info.WordWrap = true;
			this.splitter1.Location = new global::System.Drawing.Point(270, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new global::System.Drawing.Size(3, 673);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			this.uiPanel1.Controls.Add(this.tv_lst);
			this.uiPanel1.Controls.Add(this.txt_keyword);
			this.uiPanel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.uiPanel1.Font = new global::System.Drawing.Font("微软雅黑", 12f);
			this.uiPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.uiPanel1.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
			this.uiPanel1.MinimumSize = new global::System.Drawing.Size(1, 1);
			this.uiPanel1.Name = "uiPanel1";
			this.uiPanel1.Size = new global::System.Drawing.Size(270, 673);
			this.uiPanel1.TabIndex = 4;
			this.uiPanel1.Text = "uiPanel1";
			this.uiPanel1.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.txt_keyword.ButtonSymbol = 61761;
			this.txt_keyword.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.txt_keyword.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.txt_keyword.FillColor = global::System.Drawing.Color.White;
			this.txt_keyword.Font = new global::System.Drawing.Font("微软雅黑", 12f);
			this.txt_keyword.Icon = global::Notepad.Properties.Resources._17;
			this.txt_keyword.Location = new global::System.Drawing.Point(0, 0);
			this.txt_keyword.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txt_keyword.Maximum = 2147483647.0;
			this.txt_keyword.Minimum = -2147483648.0;
			this.txt_keyword.MinimumSize = new global::System.Drawing.Size(1, 1);
			this.txt_keyword.Name = "txt_keyword";
			this.txt_keyword.Size = new global::System.Drawing.Size(270, 29);
			this.txt_keyword.TabIndex = 1;
			this.txt_keyword.TextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.txt_keyword.TextChanged += new global::System.EventHandler(this.txt_keyword_TextChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new global::System.Drawing.Size(1173, 673);
			base.Controls.Add(this.splitter1);
			base.Controls.Add(this.txt_info);
			base.Controls.Add(this.uiPanel1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Name = "Frm_Main";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Tag = "1.3.1";
			this.Text = "C.Notepad v{0} By CarsonYang";
			base.Load += new global::System.EventHandler(this.Frm_Main_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.Frm_Main_KeyDown);
			this.cms_dir.ResumeLayout(false);
			this.cms_txt.ResumeLayout(false);
			this.uiPanel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000006 RID: 6
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000007 RID: 7
		private global::Sunny.UI.UITreeView tv_lst;

		// Token: 0x04000008 RID: 8
		private global::Sunny.UI.UIContextMenuStrip cms_dir;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.ToolStripMenuItem 新建文件ToolStripMenuItem;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.ToolStripMenuItem 新建目录ToolStripMenuItem;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.ToolStripMenuItem 编辑目录ToolStripMenuItem;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.ToolStripMenuItem 删除目录ToolStripMenuItem;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.ImageList img_lst;

		// Token: 0x0400000F RID: 15
		private global::Sunny.UI.UIContextMenuStrip cms_txt;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.ToolStripMenuItem 上移ToolStripMenuItem;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.ToolStripMenuItem 下移ToolStripMenuItem;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.ToolStripMenuItem 新建根目录toolStripMenuItem;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Timer time_save;

		// Token: 0x0400001E RID: 30
		private global::Sunny.UI.UIRichTextBox txt_info;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Splitter splitter1;

		// Token: 0x04000020 RID: 32
		private global::Sunny.UI.UIPanel uiPanel1;

		// Token: 0x04000021 RID: 33
		private global::Sunny.UI.UITextBox txt_keyword;
	}
}
