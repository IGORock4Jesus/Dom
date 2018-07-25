using Dom.Graphics;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.UI
{
	public abstract class Control
	{
		//List<Component> components = new List<Component>();

		public string Name { get; set; }

		internal virtual void OnInitialize(Renderer renderer) { }

		internal virtual void OnDraw(Drawer drawer) { }

		internal virtual void OnMouseDown(Point point) { }
		internal virtual void OnMouseUp(Point point) { }

		internal virtual bool IsPointOver(Point point) { return false; }
	}
}
