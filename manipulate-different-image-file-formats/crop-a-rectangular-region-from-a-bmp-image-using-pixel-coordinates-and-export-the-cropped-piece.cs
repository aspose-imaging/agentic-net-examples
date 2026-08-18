// HOW-TO: Crop a BMP Image by Pixel Coordinates and Save in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output_cropped.bmp";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Define the rectangle to crop (left, top, width, height)
                int left = 100;   // X coordinate of the left edge
                int top = 50;     // Y coordinate of the top edge
                int width = 200;  // Width of the cropped area
                int height = 150; // Height of the cropped area

                var cropArea = new Rectangle(left, top, width, height);

                // Perform the crop operation
                image.Crop(cropArea);

                // Save the cropped image to the output path
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a specific region from a large BMP file for a thumbnail or preview in a C# desktop application.
 * 2. When you want to isolate a portion of a scanned BMP document to focus on a particular form field before further analysis.
 * 3. When you are generating sprite sheets and must crop individual sprite frames from a master BMP image using exact pixel coordinates.
 * 4. When you need to remove unwanted borders or margins from BMP images automatically during a batch processing workflow.
 * 5. When you are preparing BMP assets for a game engine and must crop them to fit required texture dimensions without losing quality.
 */
