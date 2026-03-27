using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory);

        foreach (string inputPath in files)
        {
            // Process only TIFF files
            string ext = Path.GetExtension(inputPath);
            if (!string.Equals(ext, ".tif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(ext, ".tiff", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output path preserving original filename
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure lossless WebP options
                using (WebPOptions options = new WebPOptions { Lossless = true })
                {
                    // Save as WebP
                    image.Save(outputPath, options);
                }
            }
        }
    }
}