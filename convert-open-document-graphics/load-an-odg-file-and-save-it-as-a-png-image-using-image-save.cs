using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.odg";
        string outputPath = "sample.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG using PngOptions
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert OpenDocument graphics (ODG) diagrams created in LibreOffice into web‑ready PNG files for embedding in HTML pages.
 * 2. When an automated build script must batch‑process ODG assets from a design repository and generate PNG thumbnails for a content management system.
 * 3. When a Windows desktop application imports user‑provided ODG illustrations and saves them as PNG to ensure compatibility with third‑party image viewers.
 * 4. When a server‑side service receives ODG files via an API and uses Aspose.Imaging to render them as PNG for downstream image analysis or OCR.
 * 5. When a migration tool extracts legacy ODG graphics from an archive and converts them to PNG to preserve visual fidelity in a new .NET‑based platform.
 */