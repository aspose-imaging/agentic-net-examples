using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define input and output directories (relative to current directory)
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Ensure the directories exist
        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(outputDirectory);

        // Get all TIFF files in the input directory
        string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

        // Process each TIFF file in parallel
        System.Threading.Tasks.Parallel.ForEach(tiffFiles, inputPath =>
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output file path with .webp extension
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists (unconditional as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image with a memory usage hint (e.g., 50 MB)
            var loadOptions = new Aspose.Imaging.LoadOptions { BufferSizeHint = 50 };

            using (Aspose.Imaging.Image tiffImage = Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                // Configure WebP export options
                var webpOptions = new WebPOptions
                {
                    Lossless = false,   // Use lossy compression
                    Quality = 80        // Quality level (0-100)
                };

                // Save the image as WebP
                tiffImage.Save(outputPath, webpOptions);
            }
        });
    }
}