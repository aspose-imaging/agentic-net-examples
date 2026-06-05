using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Templates\example.svg";
        string outputPath = inputPath; // preserve original filename

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Example filter: remove all comments (optional, can be omitted)
                // This demonstrates a simple manipulation; actual filtering logic can vary.
                // Here we just re-save the image without modifications.

                // Save the filtered SVG back to the templates folder, preserving the filename
                svgImage.Save(outputPath, new SvgOptions());
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
 * 1. When a web application needs to clean up SVG templates by removing comments or unwanted metadata and then overwrite the original files in the Templates directory using C# and Aspose.Imaging.
 * 2. When an automated build pipeline processes design assets, applies SVG filters, and must save the modified images back to their original filenames to keep version control consistent.
 * 3. When a desktop tool allows users to edit vector graphics and must persist the changes directly to the source SVG files without creating duplicate copies.
 * 4. When a batch script iterates over a folder of SVG logos, applies a standard optimization, and overwrites each file to maintain the same file path for downstream services.
 * 5. When a content management system imports SVG templates, sanitizes them for security, and writes the sanitized version back to the same location to ensure downstream rendering uses the safe file.
 */