using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.UI
{
	public class ComponentSystem
	{
	}
	public class ComponentSystem<T> : ComponentSystem where T : Component, new()
	{
		protected List<T> Items { get; } = new List<T>();
		public virtual T Create()
		{
			T t = new T();
			Items.Add(t);
			return t;
		}
	}
}
