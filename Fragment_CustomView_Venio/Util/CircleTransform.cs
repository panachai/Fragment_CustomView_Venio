using System;
using Android.Graphics;
using Square.Picasso;

namespace ListViewTrain {


	public class CircleTransform : Java.Lang.Object, ITransformation {

		public Bitmap Transform(Bitmap source) {
			int size = Math.Min(source.Width, source.Height);

			int x = (source.Width - size) / 2;
			int y = (source.Height - size) / 2;

			Bitmap squaredBitmap = Bitmap.CreateBitmap(source, x, y, size, size);
			if (squaredBitmap != source) {
				source.Recycle();
			}

			Bitmap bitmap = Bitmap.CreateBitmap(size, size, source.GetConfig());

			Canvas canvas = new Canvas(bitmap);
			Paint paint = new Paint();
			BitmapShader shader = new BitmapShader(squaredBitmap, BitmapShader.TileMode.Clamp, BitmapShader.TileMode.Clamp);
			paint.SetShader(shader);
			paint.AntiAlias = true;

			float r = size / 2f;
			canvas.DrawCircle(r, r, r, paint);
			squaredBitmap.Recycle();

			return bitmap;
		}

		public string Key {
			get { return "circle()"; }
		}



		/*
				public Bitmap Transform(Bitmap source) {
					int size = Math.Min(source.Width, source.Height);
					int x = (source.Width - size) / 2;
					int y = (source.Height - size) / 2;
					Bitmap result = Bitmap.CreateBitmap(source, x, y, size, size);
					if (result != source) {
						source.Recycle();
					}
					return result;
				}
		*/


	}

}