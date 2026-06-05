using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with 24 bits per pixel
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                // Create a non‑temporal file at the specified location
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new 500x500 image using the specified options
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Perform any image processing here if needed

                // Save the image to the file defined in bmpOptions.Source
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
 * 1. When a developer needs to programmatically create a blank 500 × 500 BMP image with a 24‑bit per pixel format using Image.Create and BmpOptions for subsequent vector rendering in a C# application.
 * 2. When an automated reporting system must generate a high‑resolution 24bpp bitmap canvas to draw charts and then save it directly to a file path with Image.Save.
 * 3. When a batch image‑processing workflow requires a temporary 24‑bit BMP surface as a staging area before applying filters, using FileCreateSource to define the output location.
 * 4. When a Windows desktop utility needs to export a screenshot‑style image in BMP format with a known pixel format for compatibility with legacy software, ensuring the output directory exists.
 * 5. When a server‑side service must create and persist a 24bpp BMP file in a specific folder, handling any I/O exceptions while using Aspose.Imaging's Image.Create method.
 */