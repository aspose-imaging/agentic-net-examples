// HOW-TO: Resize SVG to PNG and Apply Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                int targetWidth = 800;
                int targetHeight = 600;

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = targetWidth,
                    PageHeight = targetHeight,
                    BackgroundColor = Color.White
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        var blurOptions = new GaussianBlurFilterOptions(5, 1.0);
                        raster.Filter(raster.Bounds, blurOptions);
                        raster.Save(outputPath);
                    }
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
 * 1. When you need to convert a high‑resolution SVG logo into a smaller PNG thumbnail and soften its edges with a Gaussian blur for web display.
 * 2. When generating preview images of vector graphics for a mobile app, you can rasterize the SVG to a specific size and apply blur to create a background‑blur effect.
 * 3. When preparing assets for a PDF report, you may resize the SVG to fit the page layout and add a subtle blur to match the document’s visual style.
 * 4. When building an automated pipeline that processes user‑uploaded SVG icons, you can rasterize them to a fixed PNG size and apply a blur filter to reduce visual noise.
 * 5. When creating stylized map markers, you can downscale the SVG map symbol to a PNG and apply Gaussian blur to produce a soft shadow effect.
 */
