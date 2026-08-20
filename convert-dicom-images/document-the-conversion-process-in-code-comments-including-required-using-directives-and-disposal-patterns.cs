// HOW-TO: Convert JPEG to TIFF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Input image path (relative to the current directory)
            string inputPath = Path.Combine("Input", "sample.jpg");
            // Output TIFF path (relative to the current directory)
            string outputPath = Path.Combine("Output", "sample.tif");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF export options
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    // Save the image as TIFF using the configured options
                    image.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive high‑quality photos by converting JPEG files to lossless TIFF for printing or long‑term storage.
 * 2. When a desktop application must transform user‑uploaded JPEG images into TIFF before sending them to a document management system that only accepts TIFF.
 * 3. When automating a batch process that standardizes image formats by converting mixed JPEG assets to a single TIFF format for downstream processing.
 * 4. When integrating Aspose.Imaging into a C# service that receives JPEG images and must deliver them as TIFF to comply with medical imaging standards.
 * 5. When developing a migration tool that reads legacy JPEG assets and saves them as TIFF to preserve image fidelity during a platform upgrade.
 */
