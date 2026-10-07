// HOW-TO: Resize PNG Image to Half Size and Export as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = Path.Combine("Input", "input.png");
                string outputPath = Path.Combine("Output", "output.svg");

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int newWidth = image.Width / 2;
                    int newHeight = image.Height / 2;
                    image.Resize(newWidth, newHeight);

                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = newWidth,
                            PageHeight = newHeight,
                            BackgroundColor = Color.White
                        };
                        image.Save(outputPath, svgOptions);
                    }
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
 * 1. When you need to generate a scalable SVG thumbnail from a high‑resolution PNG for responsive web design.
 * 2. When you want to reduce the file dimensions of a raster image before embedding it in an SVG‑based report.
 * 3. When an application must convert user‑uploaded PNG photos into smaller SVG assets for faster loading on mobile devices.
 * 4. When you are creating vector‑compatible icons from existing raster graphics and need to keep the aspect ratio.
 * 5. When a batch process must resize multiple raster images and store them as SVG files for later vector editing.
 */
