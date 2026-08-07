using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";

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
                // Configure PNG export options for lossless compression
                var pngOptions = new PngOptions
                {
                    // Compression level 0 = no compression (still lossless)
                    PngCompressionLevel = 0
                };

                // Save the image as PNG
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
 * 1. When a C# application must archive scanned JPEG documents by converting them to lossless PNG using Aspose.Imaging’s PngOptions for reliable long‑term storage.
 * 2. When a web service receives user‑uploaded JPEG images and needs to preserve every pixel by saving them as PNG with zero compression via Aspose.Imaging before adding them to a digital asset library.
 * 3. When building a forensic evidence system that requires immutable image files, developers can use this code to transform JPEG evidence into lossless PNG format with Aspose.Imaging for courtroom admissibility.
 * 4. When generating high‑quality thumbnails in a .NET application, the code lets developers convert the source JPEG to a PNG with no compression, ensuring the thumbnail retains the original detail.
 * 5. When a company’s compliance policy mandates all archived graphics be stored as lossless PNG, developers can employ this snippet to batch‑convert existing JPEG files using Aspose.Imaging in C#.
 */