using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CDR vector image
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Rasterize CDR to PNG in memory
            using (MemoryStream ms = new MemoryStream())
            {
                var rasterizeOptions = new PngOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions()
                };
                cdr.Save(ms, rasterizeOptions);
                ms.Position = 0;

                // Load rasterized image
                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    // Apply Gaussian blur filter
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Resize to 1200x800
                    raster.Resize(1200, 800);

                    // Save as PNG
                    var saveOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, saveOptions);
                }
            }
        }
    }
}