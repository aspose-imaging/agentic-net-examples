// HOW-TO: Create BMP with Semi Transparent Filled Rectangle in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "output/output.bmp";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions options = new BmpOptions();
                options.BitsPerPixel = 32;
                options.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(options, 300, 200))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    int rectX = 50;
                    int rectY = 50;
                    int rectWidth = 200;
                    int rectHeight = 100;

                    Pen pen = new Pen(Color.Blue, 3);
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                    {
                        graphics.FillRectangle(brush, rectX, rectY, rectWidth, rectHeight);
                    }
                    graphics.DrawRectangle(pen, rectX, rectY, rectWidth, rectHeight);

                    image.Save();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a 32‑bit BMP report image that highlights a region with a semi‑transparent overlay for visual emphasis.
 * 2. When creating custom UI assets such as button backgrounds where a translucent colored rectangle must be drawn over a white canvas in C#.
 * 3. When producing test images for image‑processing pipelines that require alpha‑blended shapes inside a BMP file.
 * 4. When automating the creation of watermark stamps that use a partially opaque rectangle to mark confidential sections of a document.
 * 5. When building a graphics‑editing tool that lets users draw and fill shapes with adjustable opacity and then save the result as a BMP file.
 */
