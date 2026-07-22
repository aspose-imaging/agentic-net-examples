using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions();
                options.KeepMetadata = true;
                // Preserve original resolution if needed:
                // options.ResolutionSettings = image.ResolutionSettings;

                image.Save(outputPath, options);
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
 * 1. When a developer needs to convert WebP images received from a web service into BMP files for legacy Windows applications while preserving the original color profile and resolution.
 * 2. When an e‑learning platform must batch‑process user‑uploaded WebP graphics into BMP format for compatibility with older PDF generation tools that only accept BMP inputs.
 * 3. When a medical imaging system stores scans as WebP to save bandwidth but requires BMP output for integration with third‑party diagnostic software that expects uncompressed bitmap data.
 * 4. When a game development pipeline receives texture assets in WebP and must export them as BMP with metadata intact for use in a legacy engine that reads BMP resolution settings.
 * 5. When an automated document conversion service needs to transform WebP icons into BMP thumbnails for inclusion in reports, ensuring the original DPI and color information are retained.
 */