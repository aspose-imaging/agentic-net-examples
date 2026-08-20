// HOW-TO: Get BMP Image Width and Height in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and (optional) output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\dimensions.txt";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (required before any save operation)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image using Aspose.Imaging
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Retrieve pixel dimensions
                int width = bmpImage.Width;
                int height = bmpImage.Height;

                // Output dimensions to console
                Console.WriteLine($"Width: {width} px");
                Console.WriteLine($"Height: {height} px");

                // Optionally write dimensions to a file
                File.WriteAllText(outputPath, $"Width: {width} px{Environment.NewLine}Height: {height} px");
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
 * 1. When you need to validate that a BMP file meets specific size requirements before uploading it to a web service.
 * 2. When you want to calculate scaling factors for generating thumbnails from BMP images in a batch processing job.
 * 3. When you are logging image metadata for an inventory system that tracks the dimensions of BMP assets.
 * 4. When you must compare the dimensions of two BMP files to ensure they match for a side‑by‑side compositing operation.
 * 5. When you need to write the pixel width and height of a BMP image to a text file for downstream analytics or reporting.
 */
