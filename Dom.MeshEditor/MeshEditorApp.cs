using Dom.Application;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dom.MeshEditor
{
	class MeshEditorApp : App
	{
		public MeshEditorApp()
		{
			//InitializeUI();
		}

		protected override void OnInitialize()
		{
			var selectToolButton = new UI.Button
			{
				Name = "SelectToolButton",
				Text = "Select",
				Location = new Point(10, 10),
				Size = new Size2(90, 25)
			};
			UIManager.Add(selectToolButton);

			var moveToolButton = new UI.Button
			{
				Name = "MoveToolButton",
				Text = "Move",
				Location = new Point(110, 10),
				Size = new Size2(90, 25)
			};
			UIManager.Add(moveToolButton);

			var rotateToolButton = new UI.Button
			{
				Name = "RotateToolButton",
				Text = "Rotate",
				Location = new Point(210, 10),
				Size = new Size2(90, 25)
			};
			UIManager.Add(rotateToolButton);

			var scaleToolButton = new UI.Button
			{
				Name = "Scale",
				Text = "Scale",
				Location = new Point(310, 10),
				Size = new Size2(90, 25)
			};
			UIManager.Add(scaleToolButton);

			selectToolButton.Click += Click_Test;
			moveToolButton.Click += Click_Test;
			rotateToolButton.Click += Click_Test;
			scaleToolButton.Click += Click_Test;
		}

		void Click_Test(UI.Button button)
		{
			MessageBox.Show(button.Text);
		}
	}
}
