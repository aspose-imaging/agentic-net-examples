// HOW-TO: Convert ODG to SVG with Vector Preservation Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded relative input and output paths
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.svg";

            // Validate input file existence
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
                // Prepare SVG save options with ODG rasterization settings
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    };

                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG preserving vector information
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
 * 1. When you need to display OpenDocument graphics on the web, you can convert ODG files to scalable SVG while keeping the original vector shapes intact.
 * 2. When integrating a document workflow that receives ODG drawings and must generate resolution‑independent graphics for mobile apps, this code transforms the files to SVG without rasterizing them.
 * 3. When building a batch processing tool that archives design assets, you can use the snippet to automatically convert multiple ODG files to SVG for easier storage and preview.
 * 4. When a reporting system requires vector‑based charts exported from ODG to be embedded in PDF or HTML reports, the conversion ensures the graphics remain crisp at any size.
 * 5. When migrating legacy OpenDocument graphics to a modern web‑friendly format, the example shows how to load ODG with Aspose.Imaging in C# and save it as SVG while preserving vector information.
 */
