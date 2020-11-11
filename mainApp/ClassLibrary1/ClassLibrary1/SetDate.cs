using PluginInterface;
using System;
using System.Globalization;
using System.Drawing;

namespace ClassLibrary1
{
    [Version(1, 0)]
    class SetDate : IPlugin
    {
        public string Name
        {
            get { return "Добавить дату на изображение"; }
        }

        public string Author
        {
            get { return "Kros"; }
        }

        public void Transform(IMainApp app)
        {
            var bitmap = app.Image;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawString(timestamp, new Font("Times New Roman", (float)25), //текст на картинке, шрифт и его размер
            new SolidBrush(Color.Black), bitmap.Width -250, bitmap.Height - 30); //цвет и расположение текста на изображении
            app.Image = bitmap;
        }
    }
}
