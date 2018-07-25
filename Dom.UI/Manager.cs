using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.UI
{
	public class Manager
	{
		List<ComponentSystem> systems;
		List<Control> controls = new List<Control>();

		public Manager(Graphics.Renderer renderer)
		{
			systems = new List<ComponentSystem>
			{
				new SpriteSystem(renderer)
			};
		}

		public T GetSystem<T>() where T : ComponentSystem
		{
			foreach (var s in systems)
			{
				if (s is T)
					return s as T;
			}
			return null;
		}

		public void Button(string name, int x, int y, int w, int h, string text)
		{
			Control control = new Control
			{
				Name = name
			};
			var sprite = GetSystem<SpriteSystem>().Create();
			sprite.Position = new SharpDX.Vector2(x, y);
			sprite.Size = new SharpDX.Vector2(w, h);

		}

		public Control Create()
		{
			Control control = new Control();
			controls.Add(control);
			return control;
		}
	}
}
