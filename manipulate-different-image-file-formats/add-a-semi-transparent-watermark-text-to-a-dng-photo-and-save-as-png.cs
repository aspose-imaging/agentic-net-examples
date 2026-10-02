// HOW-TO: Add Semi Transparent Watermark to DNG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var dng = (DngImage)Image.Load(inputPath))
            {
                int width = dng.Width;
                int height = dng.Height;

                using (var png = new PngImage(width, height))
                {
                    var graphics = new Graphics(png);
                    graphics.DrawImage(dng, new Rectangle(0, 0, width, height));

                    using (var brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                    {
                        var font = new Font("Arial", 48);
                        string text = "Watermark";
                        graphics.DrawString(text, font, brush, new PointF(width - 200, height - 60));
                    }

                    var pngOptions = new PngOptions();
                    png.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to protect raw camera files (DNG) with a copyright notice before publishing them as web‑friendly PNGs.
 * 2. When an e‑commerce platform must overlay a semi‑transparent brand logo on high‑resolution product photos stored in DNG and deliver them as PNG thumbnails.
 * 3. When a photography workflow requires converting RAW images to PNG while adding a discreet watermark for client previews.
 * 4. When a mobile app backend processes user‑uploaded DNG images, adds a translucent text watermark, and stores the result as PNG for faster loading.
 * 5. When a digital asset management system automates the creation of watermarked PNG previews from original DNG files for licensing purposes.
 */
