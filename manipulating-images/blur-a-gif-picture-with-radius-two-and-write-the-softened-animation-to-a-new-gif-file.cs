using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.gif";
        string outputPath = @"C:\Images\output_blurred.gif";

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

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific functionality
                GifImage gifImage = (GifImage)image;

                // Apply Gaussian blur with radius 2 (kernel size) and sigma 1.0
                gifImage.Filter(gifImage.Bounds, new GaussianBlurFilterOptions(2, 1.0));

                // Save the blurred animation to a new GIF file
                gifImage.Save(outputPath);
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
 * 1. When a developer wants to create a softened version of an animated GIF for a website banner, they can use this code to apply a Gaussian blur with radius two and save the result as a new GIF file.
 * 2. When building a mobile app that displays user‑generated GIF stickers with a subtle background blur, this C# snippet shows how to load the GIF, apply a radius‑2 blur, and output the blurred animation.
 * 3. When preparing marketing email content that requires a low‑key, blurred GIF preview to reduce visual noise, the code demonstrates how to process the original GIF and generate a blurred copy using Aspose.Imaging.
 * 4. When implementing a server‑side image‑processing pipeline that automatically softens uploaded GIF avatars before storing them, the example illustrates loading the GIF, applying a Gaussian blur filter, and saving the softened animation.
 * 5. When creating a desktop utility that batch‑processes GIF files to add a gentle blur effect for artistic purposes, this program provides the core C# logic for loading, blurring with radius two, and writing the new GIF.
 */