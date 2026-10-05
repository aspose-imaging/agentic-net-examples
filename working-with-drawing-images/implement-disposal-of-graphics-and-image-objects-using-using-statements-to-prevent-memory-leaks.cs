// HOW-TO: How to Draw and Fill Shapes on JPEG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Pen pen = new Pen(Color.Blue, 5);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);
                    graphics.DrawRectangle(pen, new Rectangle(10, 10, 100, 50));
                    graphics.FillRectangle(brush, new Rectangle(10, 10, 100, 50));
                }

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to overlay a colored rectangle on an existing JPEG photo and export the result as a PNG without leaking memory.
 * 2. When a web service must annotate uploaded images with borders and fill colors before storing them in a PNG format using Aspose.Imaging.
 * 3. When a desktop application generates thumbnails with custom graphics, such as highlighted areas, and must ensure proper disposal of Graphics objects.
 * 4. When batch processing a folder of JPEG files to add watermarks or markers and save them as lossless PNGs while preventing resource leaks.
 * 5. When integrating image editing features into a C# utility that requires safe handling of RasterImage, Pen, and Brush objects for reliable performance.
 */
