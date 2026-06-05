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
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific members
                GifImage gifImage = (GifImage)image;

                // Apply Gaussian blur with radius 2 (sigma set to 1.0) to the whole image
                gifImage.Filter(gifImage.Bounds, new GaussianBlurFilterOptions(2, 1.0));

                // Save the blurred animation
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
 * 1. When creating a web banner that uses an animated GIF and the designer wants a subtle soft‑focus effect, a developer can use this C# code with Aspose.Imaging to apply a Gaussian blur of radius 2 and output a new GIF.
 * 2. When preprocessing user‑uploaded animated GIFs for a social‑media app to reduce visual noise before displaying them, a developer can run this code to blur each frame uniformly.
 * 3. When generating a privacy‑preserving preview of an animated GIF in a document management system, a developer can apply a radius‑2 Gaussian blur using Aspose.Imaging for .NET and save the softened animation.
 * 4. When converting a high‑contrast GIF animation into a background element for a mobile game UI, a developer can employ this snippet to soften the image while preserving the animation timing.
 * 5. When automating a batch job that adds a consistent blur effect to promotional GIFs before publishing them to an email campaign, a developer can integrate this code to process each file and write the blurred output GIF.
 */