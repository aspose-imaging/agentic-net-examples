// HOW-TO: Batch Convert ODG and OTG Files to SVG Preserving Vectors in C# (Aspose.Imaging for .NET)
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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // Retrieve all files in the input directory
            string[] allFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in allFiles)
            {
                // Process only .odg and .otg files (case‑insensitive)
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".odg" && ext != ".otg")
                    continue;

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG file path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory for this file exists (unconditional per rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the vector image (ODG or OTG)
                using (Image image = Image.Load(inputPath))
                {
                    // Choose appropriate rasterization options based on file type
                    VectorRasterizationOptions rasterOptions;
                    if (ext == ".odg")
                    {
                        var odgOptions = new OdgRasterizationOptions();
                        odgOptions.PageSize = image.Size; // preserve original size
                        rasterOptions = odgOptions;
                    }
                    else // .otg
                    {
                        var otgOptions = new OtgRasterizationOptions();
                        otgOptions.PageSize = image.Size; // preserve original size
                        rasterOptions = otgOptions;
                    }

                    // Configure SVG save options with the vector rasterization options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the image as SVG, preserving vectors
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to migrate a collection of LibreOffice Draw (.odg) and OpenDocument Template (.otg) graphics to scalable SVG files for web display.
 * 2. When an automated build process must batch‑convert vector drawings from an assets folder into SVG to keep file sizes low while preserving editability.
 * 3. When a design team wants to generate SVG icons from existing ODG/OTG source files for inclusion in a responsive UI library.
 * 4. When a document‑conversion service has to transform mixed ODG and OTG diagrams into SVG to embed them in PDF reports without rasterizing.
 * 5. When you are archiving legacy vector artwork and require a script that iterates through a directory, converts each file to SVG, and maintains the original dimensions.
 */
