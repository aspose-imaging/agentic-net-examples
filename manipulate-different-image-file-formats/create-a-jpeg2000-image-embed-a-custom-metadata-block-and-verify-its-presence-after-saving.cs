using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        string outputPath = Path.Combine("Output", "sample.jp2");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Jpeg2000Options options = new Jpeg2000Options())
        {
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200, options))
            {
                Graphics graphics = new Graphics(jpeg2000Image);
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, jpeg2000Image.Bounds);
                }
                jpeg2000Image.Save(outputPath);
            }
        }

        if (!File.Exists(outputPath))
        {
            Console.Error.WriteLine($"File not found: {outputPath}");
            return;
        }

        using (Jpeg2000Image loadedImage = new Jpeg2000Image(outputPath))
        {
            Console.WriteLine("JPEG2000 image created and loaded successfully.");
        }
    }
}