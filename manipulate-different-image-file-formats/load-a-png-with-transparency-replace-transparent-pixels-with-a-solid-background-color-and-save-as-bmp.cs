using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // If the image is a PNG, set a solid background color for transparent pixels
                if (image is PngImage pngImage)
                {
                    pngImage.HasBackgroundColor = true;
                    pngImage.BackgroundColor = Color.Blue; // solid background color

                    // Save as BMP
                    pngImage.Save(outputPath, new BmpOptions());
                }
                else
                {
                    // Fallback: save any loaded image as BMP
                    image.Save(outputPath, new BmpOptions());
                }
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
 * 1. When a developer needs to convert a PNG with transparent areas into a BMP for legacy Windows applications that do not support alpha channels, they can use this code to replace transparency with a solid background color.
 * 2. When preparing product screenshots for printing, a developer can load the PNG, set a background color to eliminate transparency, and save as BMP to ensure consistent color rendering on print devices.
 * 3. When integrating images into a game engine that only accepts BMP files, a developer can use this snippet to flatten transparent PNG layers onto a chosen background before importing.
 * 4. When automating batch processing of icons for a desktop application, a developer can apply a uniform background to transparent PNG icons and output BMP files for faster loading.
 * 5. When migrating a digital asset library from web formats to a Windows‑only environment, a developer can employ this code to replace PNG transparency with a solid color and store the assets as BMP files for compatibility.
 */