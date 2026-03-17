using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string cdrPath = "input.cdr";
            string pngPath = "output.png";

            using (CdrImage cdrImage = (CdrImage)Image.Load(cdrPath))
            {
                int width = cdrImage.Width;
                int height = cdrImage.Height;

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(pngPath, false);

                using (Image canvas = Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    Pen rectanglePen = new Pen(Color.Blue, 5);
                    graphics.DrawRectangle(rectanglePen, 50, 50, width - 100, height - 100);

                    Pen linePen = new Pen(Color.Red, 3);
                    graphics.DrawLine(linePen, 0, 0, width, height);

                    Font font = new Font("Arial", 24, FontStyle.Regular);
                    using (SolidBrush blackBrush = new SolidBrush(Color.Black))
                    {
                        graphics.DrawString("Modified CDR Canvas", font, blackBrush, width - 250, height - 40);
                    }

                    canvas.Save();
                }
            }
        }
    }
}