using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = image.Size;
                rasterOptions.BackgroundColor = Aspose.Imaging.Color.White;

                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.Image rasterImage = Aspose.Imaging.Image.Load(ms))
                    {
                        var raster = (Aspose.Imaging.RasterImage)rasterImage;
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
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
 * 1. When a developer needs to convert an SVG logo into a soft‑focused PNG thumbnail for a website, they can load the SVG, rasterize it, apply a Gaussian blur kernel, and save the blurred PNG.
 * 2. When generating preview images of vector diagrams for a document management system, applying a Gaussian blur via ConvolutionFilter helps obscure sensitive details while preserving overall layout.
 * 3. When creating blurred background images from SVG assets for mobile app splash screens, this code shows how to load the SVG, rasterize it, apply a 5‑pixel radius Gaussian blur, and export the result as PNG.
 * 4. When preprocessing SVG icons before embedding them in a PDF report, developers can use this approach to smooth edges and reduce aliasing by applying a Gaussian blur filter.
 * 5. When building an automated pipeline that converts user‑uploaded SVG illustrations into blurred PNG overlays for video compositing, this snippet demonstrates the required C# steps with Aspose.Imaging.
 */