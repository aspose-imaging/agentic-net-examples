using System;
using System.IO;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
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

        // Load the CDR document
        using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Prepare rasterization options for vector to raster conversion
            var rasterOptions = new VectorRasterizationOptions
            {
                PageWidth = cdr.Width,
                PageHeight = cdr.Height
            };

            // Tiff options for rasterization (no source needed when saving to stream)
            var rasterTiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize CDR to a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                cdr.Save(ms, rasterTiffOptions);
                ms.Position = 0;

                // Load the rasterized image as TiffImage
                using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(ms))
                {
                    // Increase brightness by ~15% (15% of 255 ≈ 38)
                    tiff.AdjustBrightness(38);

                    // Save the adjusted image as TIFF
                    var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiff.Save(outputPath, saveOptions);
                }
            }
        }
    }
}