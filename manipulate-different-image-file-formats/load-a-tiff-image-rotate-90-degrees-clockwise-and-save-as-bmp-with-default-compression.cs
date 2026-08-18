// HOW-TO: Rotate TIFF Image 90 Degrees Clockwise and Save as BMP in C# (Aspose.Imaging for .NET)
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
            string outputPath = @"C:\temp\sample_rotated.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image, rotate, and save as BMP
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;
                tiffImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                tiffImage.Save(outputPath, new BmpOptions());
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
 * 1. When a document management system receives scanned TIFF pages that need to be displayed in portrait orientation on Windows, you can rotate them 90° clockwise and convert them to BMP for fast rendering.
 * 2. When generating thumbnails for a legacy printing workflow that only accepts BMP files, you can rotate the original TIFF and save it as a BMP with default compression.
 * 3. When integrating with a GIS application that requires BMP images oriented correctly, you can use this code to reorient TIFF map tiles before import.
 * 4. When automating batch processing of scanned invoices stored as TIFF, rotating them to match the company’s standard layout and converting to BMP simplifies downstream OCR processing.
 * 5. When preparing medical imaging data for a diagnostic tool that only reads BMP format, rotating the TIFF scans ensures the images appear upright without losing quality.
 */
