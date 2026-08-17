// HOW-TO: Dim a CorelDRAW CDR Image, Check Alpha, and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
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
            using (var cdr = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize CDR to a PNG in memory
                using (var ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (var raster = (RasterImage)Image.Load(ms))
                    {
                        // Verify presence of alpha channel
                        bool hasAlpha = raster.HasAlpha;
                        Console.WriteLine($"Alpha channel present: {hasAlpha}");

                        // Reduce brightness (dim the image)
                        raster.AdjustBrightness(-50);

                        // Save the result as TIFF
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to programmatically lower the brightness of a CorelDRAW CDR file before archiving it as a TIFF for print workflows.
 * 2. When you must confirm that a rasterized CDR image contains an alpha channel before applying further compositing or masking operations.
 * 3. When a batch process has to convert vector CDR drawings to lossless TIFFs while adjusting exposure for consistent visual appearance.
 * 4. When integrating a .NET service that receives CDR uploads, dims the artwork to meet branding guidelines, and stores the result in a TIFF repository.
 * 5. When automating image preprocessing for OCR or analysis, and you need to ensure the TIFF output is dimmed and retains transparency information.
 */
