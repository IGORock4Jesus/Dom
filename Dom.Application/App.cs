using Dom.Graphics;
using Dom.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Application
{
    public class App 
    {
		MainForm mainForm;
		Renderer renderer;

		UI.Manager uiManager;
		public UI.Manager UIManager => uiManager;
		public Renderer Renderer => renderer;


		public App()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

			mainForm = new MainForm();
			mainForm.Load += MainForm_Load;
			mainForm.FormClosed += MainForm_FormClosed;
			mainForm.Paint += MainForm_Paint;
			mainForm.ClientSizeChanged += MainForm_ClientSizeChanged;
		}

		private void MainForm_ClientSizeChanged(object sender, EventArgs e)
		{
			//renderer.ChangeSize()
		}

		private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			renderer.Draw();
		}

		private void MainForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			//renderer.Enable = false;
			renderer.Dispose();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			renderer = new Renderer(mainForm)
			{
				//Enable = true
			};

			uiManager = new UI.Manager(renderer);

			OnInitialize();
		}

		protected virtual void OnInitialize() { }

		public void Run()
		{
			System.Windows.Forms.Application.Run(mainForm);
		}
	}
}
