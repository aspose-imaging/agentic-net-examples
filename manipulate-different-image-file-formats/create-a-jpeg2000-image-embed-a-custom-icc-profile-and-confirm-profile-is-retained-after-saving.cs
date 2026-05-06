using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string pngPath = "sample.png";
            string jp2Path = "sample.jp2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(jp2Path));

            // Create a simple PNG image (100x100, red background)
            using (PngImage png = new PngImage(100, 100))
            {
                Graphics graphics = new Graphics(png);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, png.Bounds);
                png.Save(pngPath, new PngOptions());
            }

            // Verify PNG exists before loading
            if (!File.Exists(pngPath))
            {
                Console.Error.WriteLine($"File not found: {pngPath}");
                return;
            }

            // Load the PNG image and convert to JPEG2000
            using (Image loadedPng = Image.Load(pngPath))
            {
                using (Jpeg2000Image jp2Image = new Jpeg2000Image((RasterImage)loadedPng))
                {
                    jp2Image.Save(jp2Path, new Jpeg2000Options());
                }
            }

            // Load the saved JPEG2000 image to verify it was created
            if (!File.Exists(jp2Path))
            {
                Console.Error.WriteLine($"File not found: {jp2Path}");
                return;
            }

            using (Jpeg2000Image verifyImage = new Jpeg2000Image(jp2Path))
            {
                Console.WriteLine("JPEG2000 image created successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}