using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output_grayscale.jpg";

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
                // Configure JPEG save options with Grayscale color type
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Grayscale
                };

                // Save the image as a grayscale JPEG
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
 * 1. When a developer needs to convert a color JPEG photo to a smaller grayscale JPEG for faster web page loading.
 * 2. When an image processing pipeline must generate black‑and‑white thumbnails from user‑uploaded JPEGs using C# and Aspose.Imaging.
 * 3. When a medical imaging application requires storing scanned documents as grayscale JPEGs to reduce file size while preserving diagnostic detail.
 * 4. When a batch job processes product catalog images and needs to standardize them to grayscale JPEG format for consistent printing output.
 * 5. When a developer wants to comply with a legacy system that only accepts grayscale JPEG files and must convert existing color images programmatically.
 */