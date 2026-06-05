using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string? outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options to use grayscale color type
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale,
                    // Optional: set other options such as compression level if desired
                    // CompressionLevel = 9,
                    // Progressive = true
                };

                // Save the image as a grayscale PNG
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
 * 1. When a developer needs to convert vector EPS artwork into lightweight grayscale PNGs for inclusion in PDF reports that require consistent monochrome rendering.
 * 2. When an e‑commerce platform must generate thumbnail previews of EPS product logos as grayscale PNG images to reduce file size while preserving visual fidelity.
 * 3. When a document management system automates the archival of EPS diagrams by saving them as grayscale PNG files to ensure uniform appearance across different viewing applications.
 * 4. When a scientific publishing workflow converts EPS plots into grayscale PNGs for print‑ready manuscripts that demand consistent color depth and reproducibility.
 * 5. When a batch processing script uses Aspose.Imaging in C# to export multiple EPS files as grayscale PNGs for machine‑learning preprocessing that expects single‑channel image inputs.
 */