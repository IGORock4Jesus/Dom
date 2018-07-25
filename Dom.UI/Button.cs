using Dom.Graphics;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.UI
{
	public class Button : Control
	{
		Font _font;


		public Point Location { get; set; } = new Point(0, 0);
		public Size2 Size { get; set; } = new Size2(100, 30);

		public string Text { get; set; } = "Button";
		public delegate void ButtonDelegate(Button sender);
		public event ButtonDelegate Click;

		public Font Font => _font;

		internal override void OnInitialize(Renderer renderer)
		{
			_font = new Font(renderer);
		}

		internal override bool IsPointOver(Point point)
		{
			return point.X >= Location.X && point.X < Location.X + Size.Width &&
				point.Y >= Location.Y && point.Y < Location.Y + Size.Height;
		}

		internal override void OnDraw(Drawer drawer)
		{
			drawer.DrawRect(Location, Size);
			drawer.DrawText(Location, Size, Text, _font);
		}

		internal override void OnMouseDown(Point point)
		{
			Click?.Invoke(this);
		}
	}
}
