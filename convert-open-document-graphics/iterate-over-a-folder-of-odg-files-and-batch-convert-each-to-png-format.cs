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
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputOdg";
            string outputFolder = @"C:\OutputPng";

            // Get all ODG files in the input folder
            string[] odgFiles = Directory.GetFiles(inputFolder, "*.odg");

            foreach (string inputPath in odgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PNG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load ODG image and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    // Set up PNG save options with ODG rasterization
                    var pngOptions = new PngOptions();
                    var rasterOptions = new OdgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to migrate a legacy collection of OpenDocument Graphics (ODG) drawings to web‑friendly PNG images for display in browsers or mobile apps.
 * 2. When an automated build pipeline must generate thumbnail previews of ODG files stored in a shared folder for a document management system.
 * 3. When a batch conversion tool is required to prepare ODG assets for inclusion in a PowerPoint presentation that only supports raster formats like PNG.
 * 4. When a server‑side C# service processes user‑uploaded ODG diagrams and converts them to PNG with a white background for consistent printing.
 * 5. When a Windows desktop utility needs to archive multiple ODG files by converting them to lossless PNG files to reduce storage size and simplify backup.
 */