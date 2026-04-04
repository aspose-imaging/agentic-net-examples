using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input CDR file and output TIFF file paths
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\dithered.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Rasterize the CDR document to a PNG image in memory
        using (MemoryStream ms = new MemoryStream())
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
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
            }

            ms.Position = 0; // Reset stream position for reading

            // Load the rasterized image as a RasterImage
            using (RasterImage raster = (RasterImage)Image.Load(ms))
            {
                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the dithered image as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
            }
        }
    }
}