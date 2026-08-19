// HOW-TO: Convert ODG to SVG With Layer Names Preserved in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.svg";

        // Ensure any runtime exception is reported without crashing
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

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer names) in the SVG
                    KeepMetadata = true,

                    // Configure rasterization options based on the source image size
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    }
                };

                // Save the image as SVG
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
 * 1. When a designer needs to export an OpenDocument graphics file to a web‑friendly SVG while keeping the original layer structure for further editing.
 * 2. When an automated build process must convert batch ODG assets to SVG for inclusion in a responsive UI without losing metadata such as layer names.
 * 3. When a reporting tool generates diagrams in ODG format and the downstream system requires SVG with identifiable layers for interactive highlighting.
 * 4. When a migration script moves legacy ODG illustrations to an SVG‑based asset library, preserving layer names to maintain naming conventions.
 * 5. When a C# application integrates with a vector‑graphics editor that reads SVG layer names to apply custom styling or animations.
 */
