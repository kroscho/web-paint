using System;

using PluginInterface;
using System.Drawing;


namespace ClassLibrary1
{
    [Version(1, 0)]
    public class ReverseTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Переворот изображения";
            }
        }

        public string Author
        {
            get
            {
                return "Kros";
            }
        }

        public void Transform(IMainApp app)
        {
            var bitmap = app.Image;
            for (int i = 0; i < bitmap.Width; ++i)
            {
                for (int j = 0; j < bitmap.Height / 2; ++j)
                {
                    Color color = bitmap.GetPixel(i, j);
                    bitmap.SetPixel(i, j, bitmap.GetPixel(i, bitmap.Height - j - 1));
                    bitmap.SetPixel(i, bitmap.Height - j - 1, color);
                }
            }
            app.Image = bitmap;
        }
    }

}

