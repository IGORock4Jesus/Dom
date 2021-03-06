﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct3D9;

namespace Dom.Graphics
{
	public class Drawer
	{
		struct Vertex2D
		{
			public Vector4 pos;
			public Color color;
		}
		private Device device;


		public Drawer(Device device)
		{
			this.device = device;
		}

		public void DrawRect(Vector2 position, Vector2 size)
		{
			device.VertexFormat = VertexFormat.PositionRhw | VertexFormat.Diffuse;
			device.DrawUserPrimitives(PrimitiveType.TriangleFan, 2, new Vertex2D[]
			{
				new Vertex2D{pos = new Vector4(position.X, position.Y, 0.0f, 1.0f), color = Color.White},
				new Vertex2D{pos = new Vector4(position.X+size.X, position.Y, 0.0f, 1.0f), color = Color.White},
				new Vertex2D{pos = new Vector4(position.X+size.X, position.Y+size.Y, 0.0f, 1.0f), color = Color.White},
				new Vertex2D{pos = new Vector4(position.X, position.Y+size.Y, 0.0f, 1.0f), color = Color.White},
			});
		}

		public void DrawRect(Point location, Size2 size)
		{
			DrawRect(new Vector2(location.X, location.Y), new Vector2(size.Width, size.Height));
		}

		public void DrawText(Point location, Size2 size, string text, Font font)
		{
			font.DFont.DrawText(null, text, new Rectangle(location.X, location.Y, size.Width, size.Height), FontDrawFlags.Center | FontDrawFlags.VerticalCenter, Color.Black);
		}
	}
}
