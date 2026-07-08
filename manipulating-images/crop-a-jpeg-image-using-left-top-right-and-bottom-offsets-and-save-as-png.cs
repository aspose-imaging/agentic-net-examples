using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Define cropping offsets (pixels to remove from each side)
                int leftShift = 50;   // pixels to remove from the left
                int rightShift = 50;  // pixels to remove from the right
                int topShift = 30;    // pixels to remove from the top
                int bottomShift = 30; // pixels to remove from the bottom

                // Perform the crop operation
                image.Crop(leftShift, rightShift, topShift, bottomShift);

                // Save the cropped image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to trim fixed‑size borders from a JPEG receipt image and save the cleaned result as a lossless PNG using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must generate PNG thumbnails from high‑resolution JPEG product photos by cropping equal margins on the left, right, top, and bottom.
 * 3. When a mobile‑app backend processes user‑uploaded JPEG selfies, removes unwanted edges with a C# crop operation, and stores the final image as a PNG for profile pictures.
 * 4. When a document‑management system automatically extracts the central content of scanned JPEG pages by applying pixel offsets and converts the cropped output to PNG for archival.
 * 5. When a batch‑processing script prepares JPEG screenshots for a PDF report by cropping UI chrome and saving the result as a PNG to preserve transparency.
 */