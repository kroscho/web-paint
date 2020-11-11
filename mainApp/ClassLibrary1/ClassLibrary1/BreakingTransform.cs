using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace ClassLibrary1
{
    [Version(1, 0)]
    class BreakingTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Разбиение на 9 частей и расположить рандомно";
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
            Random r = new Random();            
            int sizeW = bitmap.Width;
            int sizeH = bitmap.Height / 9;
            int y;
            
            for (int j = 0; j < 9; j++) //проходим по 9 частям по высоте
            {                
                y = r.Next(0, 8); //равндомно выбираем часть с которой будет меняться первая часть
                //проходим по всем пикселям частей и обмениваем их
                for (int w = 0; w < sizeW; w++) 
                    for (int h = 0; h < sizeH; h++)
                    {
                        Color color = bitmap.GetPixel(w, j * sizeH + h); //сохраняем пиксель  из первой части
                        bitmap.SetPixel( w, j * sizeH + h, bitmap.GetPixel(w, y * sizeH + h)); //вставляем пиксель из любой другой части в первую
                        bitmap.SetPixel(w, y * sizeH + h, color); //вставляем сохраненный пиксель в часть из которой взяли пиксель
                    }
            }
            app.Image = bitmap;
        }
    }
}
