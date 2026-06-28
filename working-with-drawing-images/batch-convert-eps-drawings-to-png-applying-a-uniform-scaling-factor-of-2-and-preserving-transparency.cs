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
            string inputDir = "input_eps";
            string outputDir = "output_png";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDir, "*.eps");
            foreach (string inputPath in epsFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the corresponding PNG output path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image, resize by a factor of 2, and save as PNG preserving transparency
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    int newWidth = image.Width * 2;
                    int newHeight = image.Height * 2;

                    // Resize using nearest neighbour resampling (any suitable ResizeType can be used)
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

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
 * 1. When a graphic designer needs to generate high‑resolution PNG previews of a large collection of EPS vector logos for a web catalog, scaling each image by 2 while keeping the transparent background.
 * 2. When an e‑learning platform must automatically convert uploaded EPS diagrams into PNG assets for responsive HTML5 lessons, ensuring the images are twice as large for retina displays and retain their alpha channel.
 * 3. When a print‑to‑digital workflow requires batch processing of EPS artwork files into PNG thumbnails for a content management system, applying a uniform scaling factor of 2 to improve clarity without losing transparency.
 * 4. When a GIS application needs to transform EPS map overlays into PNG layers for overlaying on raster tiles, using C# and Aspose.Imaging to resize each layer by 200 % while preserving its transparent regions.
 * 5. When a marketing automation script must prepare EPS banner assets for email campaigns by converting them to PNG, doubling their dimensions for modern email clients and keeping the background transparent.
 */