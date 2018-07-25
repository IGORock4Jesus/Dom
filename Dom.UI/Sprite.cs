using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.UI
{
	class Sprite : Component
	{
		public Vector2 Position { get; set; }
		public Vector2 Size { get; set; }
	}

	class SpriteSystem : ComponentSystem<Sprite>
	{
		public SpriteSystem(Graphics.Renderer renderer)
		{
			renderer.Drawing += Renderer_Drawing;
		}

		private void Renderer_Drawing(Graphics.Drawer drawer)
		{
			foreach (var item in Items)
			{
				drawer.DrawRect(item.Position, item.Size);
			}
		}
	}
}
