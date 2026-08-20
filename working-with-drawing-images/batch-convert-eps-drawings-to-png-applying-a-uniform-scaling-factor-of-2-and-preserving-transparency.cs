// HOW-TO: Batch Convert EPS Files to PNG with Double Size and Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of EPS files to process
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.eps",
                @"C:\Images\Input2.eps"
            };

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Calculate new dimensions (scale factor 2)
                    int newWidth = image.Width * 2;
                    int newHeight = image.Height * 2;

                    // Resize using default interpolation
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                    // Save as PNG preserving transparency
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate high‑resolution PNG thumbnails from a set of vector EPS logos while keeping their transparent background.
 * 2. When an automated build process must export EPS artwork to PNG for web preview, scaling each image by a factor of two.
 * 3. When a desktop application imports EPS drawings and must save them as PNG files that retain the alpha channel for later compositing.
 * 4. When a batch script processes multiple EPS files to create larger PNG assets for print‑ready PDFs without losing transparency.
 * 5. When a migration tool converts legacy EPS assets to PNG format, enlarging them for modern UI screens while preserving transparent regions.
 */
