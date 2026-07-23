using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

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

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Define cropping offsets (left, right, top, bottom)
                int leftShift = 10;   // pixels to remove from the left
                int rightShift = 10;  // pixels to remove from the right
                int topShift = 20;    // pixels to remove from the top
                int bottomShift = 20; // pixels to remove from the bottom

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
 * 1. When a web application needs to generate thumbnail previews from user‑uploaded JPEG photos by removing unwanted borders before displaying them as PNG images.
 * 2. When an e‑commerce platform must automatically trim scanner‑generated product photos (left/right/top/bottom margins) and store the cleaned images in lossless PNG format for catalog listings.
 * 3. When a desktop utility processes batches of scanned documents, cropping fixed pixel offsets from each JPEG page and saving the result as PNG for archival purposes.
 * 4. When a mobile backend service receives JPEG screenshots, needs to cut out UI elements using specific pixel offsets, and returns the cropped image as a PNG to the client.
 * 5. When a reporting tool extracts a region of a JPEG chart by applying left, right, top, and bottom offsets and saves the cropped section as a PNG for inclusion in PDF reports.
 */