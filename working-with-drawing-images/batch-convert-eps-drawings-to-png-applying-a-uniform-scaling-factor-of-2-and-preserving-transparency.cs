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
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputEps";
            string outputFolder = @"C:\OutputPng";

            // Get all EPS files in the input folder
            string[] epsFiles = Directory.GetFiles(inputFolder, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Calculate new dimensions (scale factor 2)
                    int newWidth = image.Width * 2;
                    int newHeight = image.Height * 2;

                    // Resize using nearest neighbour (default) interpolation
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
 * 1. When a graphic designer needs to generate high‑resolution PNG previews of a folder of EPS logos for a web catalog, scaling each image by 2 while keeping the transparent background.
 * 2. When an e‑commerce platform must automatically convert vendor‑supplied EPS product illustrations into double‑size PNG thumbnails for mobile app display.
 * 3. When a publishing workflow requires batch processing of EPS artwork into PNG assets for print‑to‑digital conversion, ensuring the images are enlarged and retain alpha transparency.
 * 4. When a GIS application imports EPS map symbols and needs to upscale them to PNG format for overlay on high‑DPI maps without losing transparent regions.
 * 5. When a software build script prepares documentation assets by converting EPS diagrams to larger PNG files for inclusion in PDF manuals, preserving the transparent background.
 */