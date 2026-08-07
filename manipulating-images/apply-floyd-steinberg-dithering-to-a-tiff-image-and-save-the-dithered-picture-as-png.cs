using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.tif";
        string outputPath = @"c:\temp\sample.FloydSteinbergDithering1.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Dither method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the dithered image as PNG
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert high‑resolution multi‑page TIFF scans into compact 1‑bit black‑and‑white PNGs for web preview, they can apply Floyd‑Steinberg dithering with Aspose.Imaging for .NET.
 * 2. When preparing archival documents for e‑ink devices, a programmer can load a TIFF, dither it to a 1‑bit palette using the Floyd‑Steinberg algorithm, and save the result as a PNG.
 * 3. When optimizing scanned engineering drawings for faster loading in a C# desktop application, the code can reduce color depth via Floyd‑Steinberg dithering and output a PNG file.
 * 4. When generating printable line‑art thumbnails from large TIFF images, a developer can use Aspose.Imaging to apply Floyd‑Steinberg dithering and store the output as a PNG for consistent rendering.
 * 5. When building an automated batch‑processing pipeline that converts TIFF receipts into low‑size PNGs with high visual fidelity, the Floyd‑Steinberg dithering method ensures the 1‑bit PNG retains detail.
 */