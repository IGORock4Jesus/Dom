using Dom.Windows;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dom.UI
{
	public class Manager
	{
		List<Control> controls = new List<Control>();
		private readonly MainForm mainForm;
		private readonly Graphics.Renderer renderer;

		public List<Control> Controls => controls;



		public Manager(MainForm mainForm, Graphics.Renderer renderer)
		{
			renderer.Drawing += Renderer_Drawing;
			this.mainForm = mainForm;
			this.renderer = renderer;
			mainForm.MouseDown += MainForm_MouseDown;
		}

		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			var point = new Point(e.X, e.Y);
			foreach (var c in controls)
			{
				if (c.IsPointOver(point))
					c.OnMouseDown(point);
			}
		}

		private void Renderer_Drawing(Graphics.Drawer drawer)
		{
			foreach (var c in controls)
			{
				c.OnDraw(drawer);
			}
		}

		public void Add(Control control)
		{
			controls.Add(control);
			control.OnInitialize(renderer);
		}
	}
}
