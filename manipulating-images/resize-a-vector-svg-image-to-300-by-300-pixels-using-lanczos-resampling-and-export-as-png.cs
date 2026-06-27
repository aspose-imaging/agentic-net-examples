using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 300x300 using Lanczos resampling
                image.Resize(300, 300, ResizeType.LanczosResample);

                // Save as PNG
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG icons as 300 × 300 PNG files with high‑quality Lanczos resampling.
 * 2. When an e‑commerce platform must convert scalable product vector graphics into fixed‑size PNG images for email newsletters.
 * 3. When a desktop tool automates batch processing of SVG logos to create uniformly sized PNG assets for mobile app splash screens.
 * 4. When a reporting service resizes SVG charts to a 300 px square PNG to embed them in PDF documents without losing detail.
 * 5. When a content management system prepares SVG illustrations for social‑media sharing by resizing them to 300 × 300 pixels and exporting as PNG using C# and Aspose.Imaging.
 */