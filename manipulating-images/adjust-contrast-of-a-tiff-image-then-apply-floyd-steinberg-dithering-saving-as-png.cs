// HOW-TO: Increase TIFF Contrast and Apply Floyd Steinberg Dithering to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.tif";
            string outputPath = @"c:\temp\sample_processed.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access TIFF‑specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Adjust contrast (example value: 50)
                tiffImage.AdjustContrast(50f);

                // Apply Floyd‑Steinberg dithering with 1‑bit palette (black & white)
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the processed image as PNG
                PngOptions pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
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
 * 1. When you need to improve the readability of scanned TIFF documents by boosting contrast before converting them to black‑and‑white PNGs for web display.
 * 2. When preparing high‑resolution TIFF scans for OCR, applying contrast enhancement and Floyd‑Steinberg dithering creates a clean 1‑bit PNG that reduces recognition errors.
 * 3. When generating printable line‑art from a colored TIFF, adjusting contrast and dithering produces a crisp monochrome PNG suitable for laser printers.
 * 4. When archiving legacy TIFF images in a space‑efficient format, the code increases contrast and dithers to a 1‑bit PNG, cutting file size while preserving detail.
 * 5. When building a C# image‑processing pipeline that must automatically convert incoming TIFF files to PNG with consistent contrast and binary dithering for downstream analysis.
 */
