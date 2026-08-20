// HOW-TO: Crop JPEG Image by Pixel Offsets and Save as PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Offsets to crop: left, right, top, bottom (in pixels)
                int leftShift = 50;   // remove 50 pixels from the left edge
                int rightShift = 30;  // remove 30 pixels from the right edge
                int topShift = 20;    // remove 20 pixels from the top edge
                int bottomShift = 40; // remove 40 pixels from the bottom edge

                // Perform cropping
                image.Crop(leftShift, rightShift, topShift, bottomShift);

                // Save the cropped image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to remove unwanted borders from a JPEG photo before uploading it to a web gallery, you can crop it with specific pixel offsets and convert it to PNG using C#.
 * 2. When generating thumbnails for an e‑commerce site, you may crop product photos to focus on the item and save the result as a lossless PNG for better quality.
 * 3. When preprocessing scanned documents that contain extra margins, you can programmatically trim the edges of the JPEG and store the cleaned image as PNG for archival.
 * 4. When preparing images for a mobile app that requires a transparent background, you can crop the original JPEG and save the cropped area as a PNG to preserve alpha channel support.
 * 5. When automating a batch workflow that standardizes image dimensions across a dataset, you can apply left, right, top, and bottom pixel shifts to each JPEG and output the uniform PNG files.
 */
