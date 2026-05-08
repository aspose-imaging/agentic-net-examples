using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);

                int width = image.Width;
                int height = image.Height;
                int step = 50;
                Pen redPen = new Pen(Color.Red, 1);

                for (int x = 0; x <= width; x += step)
                {
                    graphics.DrawLine(redPen, new Point(x, 0), new Point(x, height));
                }

                for (int y = 0; y <= height; y += step)
                {
                    graphics.DrawLine(redPen, new Point(0, y), new Point(width, y));
                }

                image.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}