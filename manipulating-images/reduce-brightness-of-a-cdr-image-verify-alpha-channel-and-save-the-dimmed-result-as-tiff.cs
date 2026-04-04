using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Rasterize CDR to a PNG in memory
            using (MemoryStream ms = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    Source = new StreamSource(ms),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };
                cdr.Save(ms, pngOptions);
                ms.Position = 0;

                // Load rasterized image
                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    // Reduce brightness (negative value dims the image)
                    raster.AdjustBrightness(-50);

                    // Verify presence of alpha channel
                    bool hasAlpha = raster.HasAlpha;
                    Console.WriteLine($"Alpha channel present: {hasAlpha}");

                    // Save the dimmed image as TIFF
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    raster.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}