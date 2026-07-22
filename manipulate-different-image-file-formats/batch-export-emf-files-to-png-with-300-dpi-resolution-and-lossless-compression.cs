using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\sample_converted.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and save it as PNG
            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to programmatically convert user‑uploaded PNG files to a standardized PNG format using Aspose.Imaging before storing them in a cloud repository.
 * 2. When an automated build or deployment script must verify that a source image exists and then generate a lossless PNG copy in a predefined output folder.
 * 3. When a desktop application has to create the target directory on‑the‑fly with Directory.CreateDirectory to ensure saved images do not cause runtime errors.
 * 4. When a batch‑processing utility iterates over a list of image paths and uses Image.Load together with PngOptions to preserve full image quality while converting each file to PNG.
 * 5. When robust error handling is required to log missing files or conversion failures via try‑catch and Console.Error without crashing the entire application.
 */