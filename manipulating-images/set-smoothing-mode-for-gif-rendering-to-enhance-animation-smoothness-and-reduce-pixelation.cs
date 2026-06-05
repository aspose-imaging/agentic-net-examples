using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF save options with vector rasterization smoothing
                GifOptions gifOptions = new GifOptions();

                // Set up vector rasterization options
                VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
                {
                    // Enable anti-aliasing to smooth lines and curves
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                };

                gifOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as GIF using the configured options
                image.Save(outputPath, gifOptions);
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
 * 1. When converting high‑resolution PNG screenshots to animated GIFs for web tutorials, a developer can enable AntiAlias smoothing to keep lines and text crisp and avoid jagged edges.
 * 2. When generating GIF previews of vector‑based diagrams from a CAD application, setting SmoothingMode to AntiAlias ensures the curves render smoothly in the final animation.
 * 3. When creating lightweight GIF avatars from user‑uploaded PNG images in a social‑media app, applying vector rasterization smoothing reduces pixelation while keeping file size low.
 * 4. When automating the production of GIF slideshows from a series of PNG assets for email newsletters, using Aspose.Imaging’s SmoothingMode improves visual quality on different email clients.
 * 5. When building a C# service that converts PNG icons to animated GIFs for mobile UI kits, enabling anti‑aliasing via VectorRasterizationOptions delivers smoother transitions between frames.
 */