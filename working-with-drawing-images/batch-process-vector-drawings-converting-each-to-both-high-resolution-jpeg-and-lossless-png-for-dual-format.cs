// HOW-TO: Batch Convert Vector Files to High‑Resolution JPEG and PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "input";
            string outputDirectory = "output";

            // Vector file extensions to process
            string[] vectorExtensions = new[] { ".eps", ".svg", ".pdf", ".wmf", ".emf" };

            // Ensure output base directory exists
            Directory.CreateDirectory(outputDirectory);

            // Enumerate files in the input directory
            foreach (string filePath in Directory.GetFiles(inputDirectory))
            {
                string extension = Path.GetExtension(filePath);
                if (!vectorExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                    continue;

                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Prepare output paths
                string baseFileName = Path.GetFileNameWithoutExtension(filePath);
                string jpegOutputPath = Path.Combine(outputDirectory, baseFileName + ".jpg");
                string pngOutputPath = Path.Combine(outputDirectory, baseFileName + ".png");

                // Ensure directories for each output file exist
                Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

                // Load the vector image
                using (Image image = Image.Load(filePath))
                {
                    // Save as high‑resolution JPEG
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100
                    };
                    image.Save(jpegOutputPath, jpegOptions);
                }

                // Load again for PNG (or reuse the same instance if desired)
                using (Image image = Image.Load(filePath))
                {
                    // Save as lossless PNG
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.Truecolor
                    };
                    image.Save(pngOutputPath, pngOptions);
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
 * 1. When you need to generate web‑ready high‑quality JPEG previews and print‑ready PNG assets from a folder of EPS, SVG, PDF, WMF, or EMF drawings.
 * 2. When an e‑commerce platform must automatically create both compressed JPEG thumbnails and lossless PNG versions of supplier vector logos for product listings.
 * 3. When a publishing workflow requires bulk conversion of source vector illustrations into dual formats for inclusion in both digital PDFs (JPEG) and print‑ready PDFs (PNG).
 * 4. When a marketing automation script has to prepare a set of vector icons for email campaigns, delivering fast‑loading JPEGs while preserving original detail in PNGs for high‑DPI displays.
 * 5. When a document management system needs to archive incoming vector files by converting each to a high‑resolution JPEG for quick preview and a PNG for archival quality without manual intervention.
 */
