// HOW-TO: Insert a New Frame at Position Two in a Multi‑Page TIFF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the existing multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create options for the new frame
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.Rgb;

                // Create a blank frame (100x100 pixels)
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Insert the new frame at position two (zero‑based index 1)
                tiffImage.InsertFrame(1, newFrame);

                // Save the modified TIFF
                tiffImage.Save(outputPath);
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
 * 1. When you need to add a blank placeholder page to a scanned multi‑page TIFF document before the second page for later annotation.
 * 2. When generating a multi‑page TIFF report and you must insert a chart image as the second page without rewriting the whole file.
 * 3. When updating an existing TIFF archive of medical images by inserting a new image at a specific position to maintain chronological order.
 * 4. When creating a TIFF‑based e‑catalog and you want to programmatically add a product photo as the second page of the file.
 * 5. When processing batch TIFF files and you must insert a watermark page at index two to comply with branding guidelines.
 */
