using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = source };
        int width = 800;
        int height = 600;

        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x1 = rand.Next(width);
                int y1 = rand.Next(height);
                int x2 = rand.Next(width);
                int y2 = rand.Next(height);

                Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                Pen pen = new Pen(randomColor, 1);
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }

            canvas.Save();
        }
    }
}