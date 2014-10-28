﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using 행방불명.Game;


namespace 행방불명.Framework.UI
{
	public class CountView
		: View
	{
		Program app;
		TextFormat format;
		Bitmap ui, holder, medipack, key, hammer;
		Player player;
		SolidColorBrush brush;


		public CountView(Program app, Player player)
		{
			this.app = app;
			this.brush = new SolidColorBrush(app.Graphics2D.RenderTarget, new Color4(1, 1, 1, 1));
			this.format = app.Media.FormatDic["default32"];
			this.ui = app.Media.BitmapDic["count_ui"];
			this.holder = app.Media.BitmapDic["holder"];
			this.key = app.Media.BitmapDic["key"];
			this.hammer = app.Media.BitmapDic["hammer"];
			this.medipack = app.Media.BitmapDic["medipack"];
			this.player = player;


			rect = new RectangleF(0, 0, app.Width, app.Height);
			Draw += DrawView;
		}


		private void DrawView()
		{

			NumberAt(player.NumObtained, 880, 5);
			NumberAt(player.NumDead, 975, 5);
			NumberAt(player.NumPatients, 950, 55);

			DrawAtRight(ui, 0, 0);

			DrawAtRight(holder, 0, 120);
			if(player.NumMedicalKits > 0)
				DrawAtRight(medipack, 25, 125);

			DrawAtRight(holder, 0, 220);
			if (player.HasHammer)
				DrawAtRight(hammer, 25, 228);

			DrawAtRight(holder, 0, 320);
			if (player.HasKey)
				DrawAtRight(key, 20, 337);
		}

		private void DrawAtRight(Bitmap bitmap, float x, float y)
		{
			var nx = app.Width - x - bitmap.Size.Width - 15;

			app.Graphics2D.Draw(bitmap, nx, y);
		}

		RectangleF rect;

		private void NumberAt(int num, float x, float y)
		{
			rect.X = x;
			rect.Y = y;

			app.Graphics2D.RenderTarget.DrawText(
					num + "",
					format,
					rect,
					brush
					);
		}
	}
}
