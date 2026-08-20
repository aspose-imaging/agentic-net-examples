// HOW-TO: Convert ODG to SVG with Vector Layers Preserved in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.odg";
            string outputPath = "output\\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Preserve original metadata and vector information
                    KeepMetadata = true
                };

                // Save as SVG, preserving vector layers and attributes
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
 * 1. When you need to embed an OpenDocument graphics file into a web page without losing its editable vector structure.
 * 2. When converting design assets from ODG to SVG for use in responsive UI components while keeping metadata.
 * 3. When automating batch processing of ODG diagrams to SVG for integration with JavaScript chart libraries.
 * 4. When preserving layer information from ODG files for later editing in vector graphics editors after conversion.
 * 5. When migrating legacy ODG illustrations to SVG format for compatibility with modern browsers and mobile devices.
 */
