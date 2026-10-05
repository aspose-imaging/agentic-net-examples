// HOW-TO: Apply Gauss Wiener Filter to Sharpen Rasterized SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string inputSvgPath = Path.Combine(inputDirectory, "input.svg");
            string tempPngPath = Path.Combine(outputDirectory, "temp.png");
            string outputPath = Path.Combine(outputDirectory, "output.png");

            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    }
                };
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                svgImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                var filterOptions = new GaussWienerFilterOptions();
                raster.Filter(raster.Bounds, filterOptions);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert an SVG file to PNG and remove the slight blur introduced during rasterization.
 * 2. When you want to programmatically enhance the sharpness of vector graphics after rendering them in a .NET application.
 * 3. When you are building a batch image‑processing pipeline that must clean up slightly blurred PNGs generated from SVG assets.
 * 4. When you require a custom strength parameter for the Gauss‑Wiener filter to fine‑tune image clarity in C#.
 * 5. When you need to automate the creation of high‑quality PNG thumbnails from SVG logos for web or mobile apps.
 */
