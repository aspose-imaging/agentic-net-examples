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
            // Hardcoded input EPS files and corresponding output PNG files
            string[] inputPaths = {
                @"C:\Images\Input1.eps",
                @"C:\Images\Input2.eps"
            };

            string[] outputPaths = {
                @"C:\Images\Output1.png",
                @"C:\Images\Output2.png"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Calculate new dimensions with a scaling factor of 1.5
                    int newWidth = (int)(image.Width * 1.5);
                    int newHeight = (int)(image.Height * 1.5);

                    // Resize the image (using Lanczos resampling for quality)
                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

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
 * 1. When a graphic designer needs to generate high‑resolution PNG previews of EPS logos for a web‑based brand guide, scaling them by 1.5 while keeping transparent backgrounds.
 * 2. When an e‑commerce platform must convert product vector illustrations stored as EPS files into PNG thumbnails that are larger than the original and retain transparency for overlay on product pages.
 * 3. When a publishing workflow requires batch processing of EPS artwork into PNG assets for digital magazines, applying a uniform 150 % size increase to match the layout grid.
 * 4. When a mobile app development team wants to pre‑scale EPS icons to PNG format for retina displays, ensuring the images stay crisp and preserve alpha channels.
 * 5. When an automated CI/CD pipeline needs to validate that EPS assets can be rendered as PNG files at a larger size with transparency before they are deployed to a content delivery network.
 */