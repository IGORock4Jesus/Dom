﻿using Dom.Graphics;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.UI
{
	public class Control
	{
		//List<Component> components = new List<Component>();

		public string Name { get; internal set; }

		protected virtual void OnDraw(Drawer drawer) { }

		protected virtual void OnMouseDown(Point point) { }
		protected virtual void OnMouseUp(Point point) { }

		protected virtual bool IsPointOver(Point point) { return false; }
	}
}