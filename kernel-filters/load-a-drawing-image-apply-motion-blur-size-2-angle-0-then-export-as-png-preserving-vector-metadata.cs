// HOW-TO: Apply Motion Blur to Drawing and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.drawing";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image srcImage = Image.Load(inputPath))
            {
                int width = srcImage.Width;
                int height = srcImage.Height;

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(srcImage, new Aspose.Imaging.Rectangle(0, 0, width, height));

                    double[,] kernel = ConvolutionFilter.GetBlurMotion(2, 0);
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    canvas.Filter(canvas.Bounds, filterOptions);

                    canvas.Save();
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
 * 1. When you need to add a subtle motion‑blur effect to a vector drawing before converting it to a web‑friendly PNG.
 * 2. When you must preserve the original drawing’s dimensions while rasterizing it for thumbnail generation.
 * 3. When an automated pipeline requires converting proprietary .drawing files to PNG with a consistent blur filter applied.
 * 4. When you want to create a PNG preview of a CAD or illustration file with a fixed blur to hide details.
 * 5. When you are building a reporting tool that exports vector graphics as PNGs with a motion‑blur watermark for branding.
 */
