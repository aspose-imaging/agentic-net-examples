// HOW-TO: Resize EPS to 2000px Width and Save as PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output.png";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image
            using (var image = Image.Load(inputPath) as EpsImage)
            {
                if (image == null)
                {
                    Console.Error.WriteLine("Failed to load EPS image.");
                    return;
                }

                // Desired width while preserving aspect ratio
                int targetWidth = 2000;
                int targetHeight = (int)Math.Round((double)image.Height * targetWidth / image.Width);

                // Resize using a high‑quality interpolation method
                image.Resize(targetWidth, targetHeight, ResizeType.Mitchell);

                // Save the resized image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate web‑ready PNG thumbnails from vector EPS logos while keeping the original aspect ratio.
 * 2. When a printing workflow requires converting high‑resolution EPS artwork to a fixed 2000‑pixel width PNG for preview in a .NET application.
 * 3. When an e‑commerce platform must display product illustrations originally supplied as EPS files at a consistent width on product pages.
 * 4. When a batch‑processing tool has to downscale large EPS drawings to a manageable size before performing further image analysis in C#.
 * 5. When a content management system imports EPS files and must store them as PNGs with a specific width for faster loading on mobile devices.
 */
