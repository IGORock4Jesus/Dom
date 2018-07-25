using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.UI
{
	public class Button : Control
	{
		public string Text { get; set; }
		public event Action OnClick;
	}
}
