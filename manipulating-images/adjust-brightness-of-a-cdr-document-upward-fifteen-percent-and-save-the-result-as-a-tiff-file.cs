// HOW-TO: Increase Brightness of CDR by 15% and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample_adjusted.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Adjust brightness upward by ~15% (≈38 on a scale of -255..255)
                if (image is RasterImage rasterImage)
                {
                    rasterImage.AdjustBrightness(38);
                }
                else
                {
                    // Fallback: try generic AdjustBrightness if available
                    var method = image.GetType().GetMethod("AdjustBrightness");
                    method?.Invoke(image, new object[] { 38 });
                }

                // Save the result as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a designer needs to brighten a CorelDRAW (.cdr) illustration by roughly 15% before converting it to a high‑resolution TIFF for printing.
 * 2. When an automated workflow must adjust the exposure of batch‑processed CDR files and store the results as lossless TIFF images for archival.
 * 3. When a web service receives CDR graphics and must improve their visibility by increasing brightness before delivering them as TIFF thumbnails.
 * 4. When a document conversion tool integrates Aspose.Imaging to enhance the brightness of vector drawings and output them in a TIFF format compatible with legacy systems.
 * 5. When a quality‑control script checks CDR assets, applies a uniform brightness boost, and saves the corrected files as TIFF for downstream image analysis.
 */
