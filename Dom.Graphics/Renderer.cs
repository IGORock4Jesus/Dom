using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dom.Graphics
{
	public class Renderer : IDisposable
	{
		Direct3D direct;
		Device device;
		private bool enable;
		private Thread thread;

		public delegate void DrawHandler(Drawer drawer);
		public event DrawHandler Drawing;
		public event Action PreReset, PostReset;

		Drawer drawer;
		public Device Device => device;

		public Renderer(Form form)
		{
			direct = new Direct3D();
			device = new Device(direct, 0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded, new PresentParameters
			{
				AutoDepthStencilFormat = Format.D24S8,
				BackBufferCount = 1,
				BackBufferFormat = Format.A8R8G8B8,
				BackBufferHeight = form.ClientSize.Height,
				BackBufferWidth = form.ClientSize.Width,
				DeviceWindowHandle = form.Handle,
				EnableAutoDepthStencil = true,
				SwapEffect = SwapEffect.Discard,
				Windowed = true
			});

			drawer = new Drawer(device);

			form.ClientSizeChanged += Form_ClientSizeChanged;
		}

		private void Form_ClientSizeChanged(object sender, EventArgs e)
		{
			if (!(sender is Form form)) return;
			if (form.ClientSize.Height == 0 || form.ClientSize.Width == 0)
				return;

			PreReset?.Invoke();

			device.Reset(new PresentParameters
			{
				AutoDepthStencilFormat = Format.D24S8,
				BackBufferCount = 1,
				BackBufferFormat = Format.A8R8G8B8,
				BackBufferHeight = form.ClientSize.Height,
				BackBufferWidth = form.ClientSize.Width,
				DeviceWindowHandle = form.Handle,
				EnableAutoDepthStencil = true,
				SwapEffect = SwapEffect.Discard,
				Windowed = true
			});

			PostReset?.Invoke();
		}

		//public bool Enable
		//{
		//	get => enable;
		//	set
		//	{
		//		if (value == enable) return;
		//		enable = value;
		//		if (value)
		//		{
		//			thread = new Thread(StartRendering);
		//			thread.Start();
		//		}
		//		else
		//		{
		//			if (thread.IsAlive)
		//				thread.Join();
		//		}
		//	}
		//}

		//private void StartRendering()
		//{
		//	while (enable)
		//	{
		//		device.Clear(ClearFlags.All, Color.DarkGray, 1.0f, 0);
		//		device.BeginScene();

		//		Drawing?.Invoke(drawer);

		//		device.EndScene();
		//		device.Present();

		//		Thread.Sleep(1);
		//	}
		//}

		public void Draw()
		{
			device.Clear(ClearFlags.All, Color.DarkGray, 1.0f, 0);
			device.BeginScene();

			Drawing?.Invoke(drawer);

			device.EndScene();
			device.Present();
		}

		public void Dispose()
		{
			//Enable = false;
			device.Dispose();
			direct.Dispose();
		}
	}
}
