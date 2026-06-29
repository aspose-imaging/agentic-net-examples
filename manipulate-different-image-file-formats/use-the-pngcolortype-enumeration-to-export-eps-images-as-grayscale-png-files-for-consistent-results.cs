using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/input.eps";
        string outputPath = "output/output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG export options to use grayscale color type
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale
                };

                // Save as PNG with the specified options
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to use Aspose.Imaging in C# to convert EPS vector graphics to a grayscale PNG (using PngColorType.Grayscale) for inclusion in a print‑ready PDF.
 * 2. When an e‑commerce site must programmatically export product logo EPS files as low‑size grayscale PNGs via PngOptions to reduce page load times.
 * 3. When a scientific reporting application requires consistent grayscale PNG output from EPS plots, using the PngColorType enumeration to meet journal image standards.
 * 4. When an automated CI/CD pipeline processes design assets by loading EPS images and saving them as grayscale PNGs with Aspose.Imaging to store in a documentation repository.
 * 5. When a mobile backend service receives EPS uploads and needs to convert them to grayscale PNGs in C# for uniform rendering on all devices.
 */