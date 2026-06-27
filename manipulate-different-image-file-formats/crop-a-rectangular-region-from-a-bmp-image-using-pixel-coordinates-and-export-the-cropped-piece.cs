using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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
                // Example: crop a 200x150 region starting at (50,50)
                Rectangle cropArea = new Rectangle(50, 50, 200, 150);

                // Perform the cropping operation
                image.Crop(cropArea);

                // Save the cropped image to the output path
                image.Save(outputPath);
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
 * 1. When a developer needs to extract a specific portion of a scanned BMP document—such as a logo or signature—by specifying exact pixel coordinates before embedding it into a report.
 * 2. When building a Windows desktop application that generates thumbnails from large BMP screenshots, cropping a defined rectangle to create a smaller preview image.
 * 3. When processing legacy BMP assets for a game and isolating sprite frames by cropping fixed‑width and height regions using C# image processing.
 * 4. When creating an automated batch job that removes unwanted borders from BMP scans by cropping a known offset and size before archiving the files.
 * 5. When integrating with a printing workflow that requires sending only a selected area of a BMP blueprint to a printer, using pixel‑based cropping to meet the printer’s layout constraints.
 */