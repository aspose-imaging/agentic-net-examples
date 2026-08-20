// HOW-TO: Batch Convert PNG Images to SVG with Original Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Retrieve all PNG files from the input directory
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Construct the output SVG file path, preserving the original filename
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure SVG export options with appropriate rasterization settings
                    var vectorOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    var svgOptions = new SvgOptions { VectorRasterizationOptions = vectorOptions };

                    // Save the image as SVG
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
 * 1. When you need to generate scalable vector versions of a large set of PNG icons for responsive web design while keeping the original file names.
 * 2. When an automated build process must convert product screenshots from PNG to SVG for inclusion in documentation that requires resolution‑independent graphics.
 * 3. When a desktop application has to export user‑uploaded PNG artwork to SVG format for printing or editing in vector‑based tools without manual file handling.
 * 4. When a migration script must move legacy PNG assets to an SVG folder structure, preserving naming consistency for downstream systems.
 * 5. When a batch image‑processing job has to create SVG equivalents of PNG logos and store them in a separate output directory for a branding pipeline.
 */
