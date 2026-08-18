// HOW-TO: Recover Corrupted TIFF Using Consistent Recovery Mode in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "corrupted.tif";
        string outputPath = "recovered.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var loadOptions = new Aspose.Imaging.LoadOptions
            {
                DataRecoveryMode = Aspose.Imaging.DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Aspose.Imaging.Color.White
            };

            using (TiffImage image = (TiffImage)Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                // Example processing: output image dimensions
                Console.WriteLine($"Recovered image size: {image.Width}x{image.Height}");

                image.Save(outputPath);
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
 * 1. When a batch of scanned documents in TIFF format becomes partially corrupted and you need to automatically restore them before further analysis.
 * 2. When you need to load a damaged TIFF into memory to read its dimensions for validation or reporting purposes.
 * 3. When an archival system must recover and re‑save TIFF images with a white background to ensure consistent display across viewers.
 * 4. When a document processing pipeline encounters a broken TIFF and requires a programmatic way to salvage the image without manual intervention.
 * 5. When you want to integrate Aspose.Imaging’s ConsistentRecover mode into a C# application to fix TIFF files before applying additional image‑processing operations.
 */
