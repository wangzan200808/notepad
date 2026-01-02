using System;
using System.Windows.Forms;

namespace Notepad
{
	// Token: 0x02000017 RID: 23
	internal static class Program
	{
		// Token: 0x0600004D RID: 77 RVA: 0x0000550F File Offset: 0x0000370F
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Frm_Main());
		}
	}
}
