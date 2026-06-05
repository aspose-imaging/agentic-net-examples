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
            // Hardcoded collection of EPS input files
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.eps",
                @"C:\Images\Input2.eps",
                @"C:\Images\Input3.eps"
            };

            // Corresponding output PNG files
            string[] outputPaths = new string[]
            {
                @"C:\Images\Output1.png",
                @"C:\Images\Output2.png",
                @"C:\Images\Output3.png"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Calculate new dimensions with scaling factor 1.5
                    int newWidth = (int)Math.Round(image.Width * 1.5);
                    int newHeight = (int)Math.Round(image.Height * 1.5);

                    // Resize using default interpolation (NearestNeighbourResample)
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
 * 1. When a graphic designer needs to generate high‑resolution web‑ready PNG thumbnails from a batch of vector EPS logos while enlarging them by 150 % and keeping the transparent background intact.
 * 2. When an e‑commerce platform must automatically convert product illustration EPS files into PNG assets for mobile apps, applying a uniform 1.5 scaling factor to match the device’s pixel density and preserve alpha channel transparency.
 * 3. When a publishing workflow requires bulk conversion of EPS artwork into PNG images for print‑on‑demand PDFs, scaling each image proportionally by 1.5 and ensuring the background remains transparent for overlay use.
 * 4. When a GIS application imports EPS map symbols and needs to export them as scaled PNG icons with preserved transparency for use in interactive web maps.
 * 5. When a marketing automation script processes a collection of EPS banners, resizing them by 150 % and saving them as PNG files so they can be displayed on email newsletters without losing transparent areas.
 */