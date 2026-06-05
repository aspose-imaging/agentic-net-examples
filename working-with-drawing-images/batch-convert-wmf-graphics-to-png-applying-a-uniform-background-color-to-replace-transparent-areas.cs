using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\WMF";
            string outputFolder = @"C:\Images\PNG";

            // List of WMF files to convert
            string[] files = new[]
            {
                "sample1.wmf",
                "sample2.wmf",
                "sample3.wmf"
            };

            // Desired background color for transparent areas
            Aspose.Imaging.Color backgroundColor = Aspose.Imaging.Color.White;

            foreach (string fileName in files)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputFolder, fileName);
                string outputPath = Path.Combine(outputFolder, Path.ChangeExtension(fileName, ".png"));

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options with background color
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = backgroundColor
                    };

                    // Set PNG save options
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to migrate legacy Windows Metafile (WMF) icons used in a desktop application to web‑friendly PNG assets while ensuring transparent regions are filled with a solid color for consistent display across browsers.
 * 2. When an automated build pipeline must generate printable PNG versions of WMF diagrams for inclusion in PDF reports, applying a white background to avoid unwanted transparency on printed pages.
 * 3. When a content management system imports a batch of vendor‑supplied WMF logos and converts them to PNG thumbnails with a uniform background to match the site’s visual theme.
 * 4. When a migration script replaces WMF watermarks in a batch of marketing materials with PNG overlays, needing to set a specific background color to preserve contrast on varied backgrounds.
 * 5. When a Windows service processes incoming WMF files from a file‑share, converts them to PNG for downstream image‑processing APIs, and forces a background color to meet the API’s non‑transparent image requirement.
 */