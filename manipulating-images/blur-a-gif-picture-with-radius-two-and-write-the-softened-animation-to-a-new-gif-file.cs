// HOW-TO: Apply Gaussian Blur Radius 2 to GIF Animation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output_blurred.gif";

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
                GifImage gif = image as GifImage;
                if (gif == null)
                {
                    Console.Error.WriteLine("The loaded file is not a GIF image.");
                    return;
                }

                // Apply Gaussian blur with radius 2 (sigma set to 1.0) to the whole animation
                gif.Filter(gif.Bounds, new GaussianBlurFilterOptions(2, 1.0));

                // Save the blurred animation
                gif.Save(outputPath);
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
 * 1. When you need to soften a noisy GIF animation before embedding it on a website.
 * 2. When creating a stylized transition effect by applying a subtle blur to each frame of an animated GIF in a C# application.
 * 3. When preprocessing user‑uploaded GIFs to reduce visual sharpness for privacy or aesthetic reasons using Aspose.Imaging.
 * 4. When generating a blurred preview thumbnail of an animated GIF for faster loading in mobile apps.
 * 5. When automating batch processing to apply a consistent Gaussian blur radius to multiple GIF files in a .NET workflow.
 */
