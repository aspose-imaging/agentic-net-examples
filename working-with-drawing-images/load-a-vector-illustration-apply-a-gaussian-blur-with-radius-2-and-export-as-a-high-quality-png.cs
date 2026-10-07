// HOW-TO: Apply Gaussian Blur to SVG and Export as High Quality PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/vector.svg";
            string outputPath = "Output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(2, 2));
                        var finalOptions = new PngOptions();
                        raster.Save(outputPath, finalOptions);
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
 * 1. When you need to soften the edges of a vector logo before embedding it in a web page as a PNG.
 * 2. When you want to generate a blurred preview of an SVG illustration for a design mockup.
 * 3. When you must convert scalable graphics to raster format with a consistent blur effect for printing.
 * 4. When you are building an automated pipeline that processes SVG assets and outputs high‑resolution PNGs with a subtle Gaussian blur.
 * 5. When you require a C# solution to apply image filters to vector files without using external graphics editors.
 */
