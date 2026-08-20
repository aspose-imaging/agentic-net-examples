// HOW-TO: Apply Motion Blur Convolution Filter to PNG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine("Output", "filtered.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var pngOptions = new PngOptions())
            {
                pngOptions.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(pngOptions, 400, 300))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);
                    graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 50, 200, 150));

                    double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(4, 135);
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, filterOptions);

                    image.Save();
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
 * 1. When you need to generate a blank PNG canvas, draw shapes, and add a motion‑blur effect for a stylized graphic in a C# application.
 * 2. When you want to programmatically create thumbnails with a directional blur to simulate movement in product preview images.
 * 3. When you are building a reporting tool that overlays annotations on images and requires a consistent blur filter to hide sensitive details.
 * 4. When you need to preprocess scanned documents by applying a motion blur to reduce noise before OCR in a .NET workflow.
 * 5. When you are developing a game UI and want to render UI elements with a custom 135‑degree blur to match a dynamic background effect.
 */
