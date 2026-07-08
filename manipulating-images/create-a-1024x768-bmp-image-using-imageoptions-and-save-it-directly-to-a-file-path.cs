using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                // Define where the image will be created
                Source = new FileCreateSource(outputPath, false)
                // BitsPerPixel defaults to 24, which is fine for a standard BMP
            };

            // Create a 1024x768 BMP image and save it directly to the specified path
            using (Image image = Image.Create(bmpOptions, 1024, 768))
            {
                // No additional drawing is required; just save the blank image
                image.Save();
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
 * 1. When a developer needs to generate a blank 1024x768 BMP placeholder image for a legacy Windows application that only accepts BMP files.
 * 2. When an automated report generator must create a fixed‑size bitmap canvas before drawing charts or adding watermarks using Aspose.Imaging in C#.
 * 3. When a batch image‑processing pipeline requires a temporary 24‑bit BMP file as a staging surface for pixel‑level manipulations.
 * 4. When a unit test for image‑handling code needs a known‑size BMP file on disk without relying on external resources.
 * 5. When a desktop utility must export a screenshot‑sized bitmap to a specific folder, ensuring the output directory exists and the file is saved directly via FileCreateSource.
 */