using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Graphics
{
	public class Font : IDisposable
	{
		SharpDX.Direct3D9.Font font;
		private string _faceName = "Consolas";
		private int _height = 16;
		private readonly Device device;

		public string FaceName
		{
			get => _faceName;
			set
			{
				_faceName = value;
				Create();
			}
		}
		public int Height
		{
			get => _height;
			set
			{
				_height = value;
				Create();
			}
		}

		public Font(Renderer renderer)
		{
			this.device = renderer.Device;
			Create();
			renderer.PreReset += Renderer_PreReset;
			renderer.PostReset += Renderer_PostReset;
		}

		private void Renderer_PostReset()
		{
			Create();
		}

		private void Renderer_PreReset()
		{
			if (font != null)
				font.Dispose();

		}

		private void Create()
		{
			if (font != null)
				font.Dispose();

			font = new SharpDX.Direct3D9.Font(device, new FontDescription
			{
				FaceName = FaceName,
				Height = Height
			});
		}

		public void Dispose()
		{
			if (font != null)
				font.Dispose();
		}

		internal SharpDX.Direct3D9.Font DFont => font;
	}
}
