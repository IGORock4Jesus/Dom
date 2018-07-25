using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.UI
{
	public class Manager
	{
		List<Control> controls = new List<Control>();
		private readonly Graphics.Renderer renderer;

		public List<Control> Controls => controls;



		public Manager(Graphics.Renderer renderer)
		{
			renderer.Drawing += Renderer_Drawing;
			this.renderer = renderer;
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
