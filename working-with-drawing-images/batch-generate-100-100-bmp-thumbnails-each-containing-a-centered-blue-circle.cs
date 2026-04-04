using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputFolder = "Input";
        string outputFolder = "Output";

        if (!Directory.Exists(inputFolder))
        {
            Directory.CreateDirectory(inputFolder);
            Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        foreach (var inputPath in Directory.GetFiles(inputFolder))
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                image.Resize(100, 100, ResizeType.NearestNeighbourResample);

                Graphics graphics = new Graphics(image);

                int radius = 40;
                int centerX = image.Width / 2;
                int centerY = image.Height / 2;
                int left = centerX - radius;
                int top = centerY - radius;

                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(brush, new Rectangle(left, top, radius * 2, radius * 2));
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                image.Save(outputPath, new BmpOptions());
            }
        }
    }
}