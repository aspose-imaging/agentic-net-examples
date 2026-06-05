using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths (relative)
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options for lossless archival storage
                using (PngOptions options = new PngOptions())
                {
                    // Maximum compression (still lossless)
                    options.CompressionLevel = 9;

                    // Preserve full color with alpha channel
                    options.ColorType = PngColorType.TruecolorWithAlpha;

                    // Save the image as PNG with the specified options
                    image.Save(outputPath, options);
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
 * 1. When a developer needs to convert JPEG photographs to lossless PNG files for long‑term archival in a document management system.
 * 2. When an application must generate PNG assets with maximum compression while preserving alpha transparency for use in web galleries.
 * 3. When a batch‑processing service has to ensure that uploaded images are stored in a consistent, lossless format before indexing them in a searchable repository.
 * 4. When a C# utility is required to create PNG copies of scanned PDFs to maintain image fidelity for legal evidence storage.
 * 5. When a developer wants to programmatically export processed images from an image‑editing workflow to PNG with Aspose.Imaging to meet regulatory compliance for medical imaging archives.
 */