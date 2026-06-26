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
            // Define relative input and output paths
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to specific OdgImage type
                var odgImage = (Aspose.Imaging.FileFormats.OpenDocument.OdgImage)image;

                // Configure PNG options to keep original metadata
                var pngOptions = new PngOptions
                {
                    KeepMetadata = true
                };

                // Save as PNG while preserving metadata
                odgImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert OpenDocument graphics (ODG) files to PNG for web display while preserving author, creation date, and custom metadata for compliance reporting.
 * 2. When an automated batch job must generate thumbnail PNGs from a library of ODG diagrams and retain the original metadata so downstream systems can still query image properties.
 * 3. When a document management system imports ODG illustrations and stores them as PNG assets, requiring the original metadata to be kept for search indexing and version tracking.
 * 4. When a C# application processes engineering schematics saved as ODG and exports them to PNG for inclusion in PDF reports, while ensuring the embedded metadata remains intact for audit trails.
 * 5. When a migration script moves legacy ODG artwork to a cloud storage bucket in PNG format and needs to maintain metadata such as copyright and creator information for legal compliance.
 */