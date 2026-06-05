using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output.gif";

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
                GifImage gif = (GifImage)image;

                // Apply Gaussian blur to the entire GIF
                gif.Filter(gif.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Configure lossy GIF compression
                GifOptions options = new GifOptions
                {
                    MaxDiff = 80 // Enable lossy compression with recommended value
                };

                // Save the blurred GIF with compression
                gif.Save(outputPath, options);
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
 * 1. When a web developer wants to reduce the file size of an animated GIF for faster page loads while applying a softening effect to hide sensitive details, they can use this code to blur and compress the GIF.
 * 2. When a mobile app needs to generate low‑bandwidth preview animations from user‑uploaded GIFs, the code can apply a Gaussian blur and lossy GIF compression to create lightweight previews.
 * 3. When an e‑learning platform wants to obscure copyrighted text in animated diagrams before sharing them publicly, the code can blur the frames and compress the result to meet size limits.
 * 4. When a marketing team needs to create stylized, smaller‑sized GIF banners for email campaigns, developers can use this snippet to soften the animation and apply lossy compression for better deliverability.
 * 5. When a game developer must package animated UI elements as GIFs with reduced storage footprint while maintaining a smooth visual effect, this code provides the necessary blur and compression steps.
 */