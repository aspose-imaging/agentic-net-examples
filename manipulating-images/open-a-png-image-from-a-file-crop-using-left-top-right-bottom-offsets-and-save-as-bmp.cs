// HOW-TO: Crop PNG Image by Offsets and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.bmp";

        // Ensure any runtime exception is reported cleanly
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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Crop offsets: left, right, top, bottom
                int leftShift = 10;
                int rightShift = 10;
                int topShift = 20;
                int bottomShift = 20;

                // Perform cropping
                image.Crop(leftShift, rightShift, topShift, bottomShift);

                // Prepare BMP save options (default options are sufficient)
                BmpOptions bmpOptions = new BmpOptions();

                // Save the cropped image as BMP
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to trim unwanted borders from a PNG screenshot and store the result as a BMP for legacy Windows applications.
 * 2. When a batch process must convert PNG assets to BMP after removing a fixed number of pixels from each side for consistent dimensions.
 * 3. When generating BMP thumbnails from PNG files where a specific left, right, top, and bottom margin must be removed before resizing.
 * 4. When preparing images for a printer that only accepts BMP format and requires a precise crop to align the content.
 * 5. When integrating Aspose.Imaging in a C# service that extracts a region of a PNG logo and saves it as BMP for use in embedded systems.
 */
