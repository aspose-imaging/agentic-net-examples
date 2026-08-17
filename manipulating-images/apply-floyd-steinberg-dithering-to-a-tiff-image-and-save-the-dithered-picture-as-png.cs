// HOW-TO: Apply Floyd Steinberg Dithering to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.tif";
            string outputPath = @"C:\temp\sample.FloydSteinbergDithering1.png";

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
                // Cast to TiffImage to access Dither method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the dithered image as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert a high‑resolution TIFF scan into a 1‑bit black‑and‑white PNG for faster web loading.
 * 2. When preparing images for e‑ink devices that require Floyd‑Steinberg dithering to preserve detail with a limited palette.
 * 3. When generating printable line‑art from a TIFF source while keeping the file size low by saving as a dithered PNG.
 * 4. When automating a batch workflow that transforms archival TIFF documents into dithered PNGs for systems that only accept PNG files.
 * 5. When creating monochrome thumbnails of TIFF images with Floyd‑Steinberg dithering to maintain visual quality in previews.
 */
