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
            // Hard‑coded input and output file paths
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific functionality
                GifImage gifImage = (GifImage)image;

                // Apply a Gaussian blur with radius 2 (sigma set to 1.0) to the whole animation
                gifImage.Filter(gifImage.Bounds, new GaussianBlurFilterOptions(2, 1.0));

                // Save the blurred animation
                gifImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When creating a social media post that requires a subtle background blur on an animated GIF to highlight overlay text, a developer can use this code to apply a Gaussian blur with radius two and save the softened animation.
 * 2. When preparing an animated tutorial where the original GIF is too sharp and distracts from voice‑over instructions, a developer can blur the frames using Aspose.Imaging for .NET to produce a smoother visual.
 * 3. When generating a privacy‑compliant preview of an animated GIF that contains sensitive details, a developer can apply a radius‑2 Gaussian blur to obscure the content while preserving the animation.
 * 4. When optimizing an animated banner for a website that needs a gentle blur effect to match a design theme, a developer can load the GIF, apply the blur filter, and output a new GIF file.
 * 5. When building a desktop application that lets users apply quick visual effects to their GIFs, a developer can implement this code to provide a one‑click “soften” option that blurs the entire animation with a radius of two.
 */