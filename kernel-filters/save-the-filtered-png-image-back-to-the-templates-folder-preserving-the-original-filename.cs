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
        string inputPath = @"C:\Project\templates\sample.png";
        string outputPath = inputPath; // preserve original filename

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Example processing: apply adaptive binarization if the image is a PNG
                if (image is Aspose.Imaging.FileFormats.Png.PngImage pngImage)
                {
                    pngImage.BinarizeOtsu();
                }

                // Prepare PNG save options
                PngOptions saveOptions = new PngOptions
                {
                    // Use adaptive filtering for better compression
                    FilterType = PngFilterType.Adaptive,
                    // Enable progressive loading
                    Progressive = true,
                    // Set maximum compression level
                    CompressionLevel = 9,
                    // Preserve truecolor with alpha
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    // 8 bits per channel
                    BitDepth = 8
                };

                // Save the processed image back to the original location
                image.Save(outputPath, saveOptions);
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
 * 1. When a web application automatically enhances uploaded PNG logos by applying Otsu binarization and then overwrites the original template file with adaptive filtering and maximum compression.
 * 2. When a desktop publishing tool preprocesses PNG assets in a templates folder, converting them to truecolor with alpha and saving them back with the same filename to preserve existing references.
 * 3. When a batch script for a marketing campaign needs to make all PNG banner images progressively loadable and highly compressed before they are served from the same directory structure.
 * 4. When an e‑learning platform standardizes PNG screenshots by applying adaptive binarization and then saves the processed image back to the original path to keep the file name unchanged.
 * 5. When a CI/CD pipeline validates the presence of each PNG template, applies image processing, and overwrites it in place to ensure consistent image quality across environments.
 */