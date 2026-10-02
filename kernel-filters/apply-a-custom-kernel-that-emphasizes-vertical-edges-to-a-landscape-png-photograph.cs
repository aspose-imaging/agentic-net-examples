// HOW-TO: Apply Vertical Edge Detection Filter to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When you need to highlight vertical structures such as building edges in a landscape PNG for a mapping application.
 * 2. When preprocessing photos for a computer‑vision pipeline that requires edge maps before feature extraction.
 * 3. When creating stylized thumbnails that emphasize vertical lines to improve visual contrast in a web gallery.
 * 4. When converting high‑resolution landscape scans into edge‑detected PNGs for printing on technical documentation.
 * 5. When automating batch processing of PNG photographs to generate vertical edge overlays for architectural analysis.
 */
