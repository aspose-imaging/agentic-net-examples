// HOW-TO: Restore Details of a Blurred SVG Using Deconvolution Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\blurred.svg";
            string intermediatePath = @"C:\Images\temp.png";
            string outputPath = @"C:\Images\restored.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories for intermediate and final output exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image and rasterize it to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(intermediatePath, pngOptions);
            }

            // Load the rasterized PNG, apply a deconvolution (Gauss-Wiener) filter, and save the result
            using (Image rasterImg = Image.Load(intermediatePath))
            {
                RasterImage rasterImage = (RasterImage)rasterImg;
                var deconvOptions = new GaussWienerFilterOptions(5, 4.0); // radius=5, sigma=4.0
                rasterImage.Filter(rasterImage.Bounds, deconvOptions);
                rasterImage.Save(outputPath);
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
 * 1. When you need to sharpen a blurred SVG logo before embedding it in a web page.
 * 2. When converting vector graphics to a raster PNG and want to improve clarity after compression artifacts.
 * 3. When processing scanned SVG diagrams that appear out of focus and require detail restoration.
 * 4. When automating a batch job that cleans up blurry SVG icons for a mobile app’s asset pipeline.
 * 5. When preparing SVG illustrations for print and need to apply a Gauss‑Wiener deconvolution to meet quality standards.
 */
