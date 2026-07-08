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
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.odg";
            string outputPath = @"C:\Temp\sample.svg";

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
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer names) if possible
                    KeepMetadata = true
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to integrate automated conversion of OpenDocument Graphics (ODG) files to scalable vector graphics (SVG) in a C# application while preserving original layer names for downstream editing.
 * 2. When a document management system must batch‑process user‑uploaded ODG diagrams and store them as SVG files with metadata intact to support web rendering and searchable layer information.
 * 3. When a CAD or illustration tool built on .NET requires exporting designs created in ODG format to SVG so that web‑based viewers can display the artwork with the same layer hierarchy.
 * 4. When a migration script has to replace legacy ODG assets with SVG equivalents in a content repository, ensuring that layer names are kept for compatibility with existing style sheets.
 * 5. When an automated reporting service generates vector charts in ODG and needs to deliver them as SVG images to client browsers while retaining layer metadata for interactive features.
 */