// HOW-TO: Selective Background Removal From Rectangular Area of CDR Vector in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cdr";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary rasterized PNG path
            string tempPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            // Rasterize the CDR vector image to a PNG file
            using (CdrImage vectorImage = (CdrImage)Image.Load(inputPath))
            {
                var rasterOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempPath, false)
                };
                vectorImage.Save(tempPath, rasterOptions);
            }

            // Load the rasterized image and apply selective background removal
            using (RasterImage rasterImage = (RasterImage)Image.Load(tempPath))
            {
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                };

                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.Manual,
                    Decompose = false,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions,
                    // Define the rectangular area where background removal will be applied
                    MaskingArea = new Rectangle(100, 100, 300, 200)
                };

                var masking = new ImageMasking(rasterImage);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                {
                    using (Image resultImage = result[1].GetImage())
                    {
                        resultImage.Save(outputPath, exportOptions);
                    }
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
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
 * 1. When you need to extract a logo from a CorelDRAW (CDR) file while keeping only the portion inside a defined rectangle and save it as a transparent PNG.
 * 2. When you want to prepare product images from vector designs by removing the background around a specific area before uploading to an e‑commerce site.
 * 3. When a printing workflow requires converting CDR artwork to raster format and isolating a selected region for further compositing in a graphics editor.
 * 4. When you are building a batch tool that automatically crops and makes the background transparent for icons stored in CDR files.
 * 5. When you need to integrate selective background removal into a .NET application that processes corporate branding assets stored as CDR vectors.
 */
