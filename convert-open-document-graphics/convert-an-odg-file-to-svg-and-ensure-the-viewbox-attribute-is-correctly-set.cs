using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare SVG export options with proper viewBox (PageSize)
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        // Setting PageSize makes Aspose.Imaging generate a correct viewBox attribute
                        PageSize = odgImage.Size
                    }
                };

                // Save the image as SVG
                odgImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert OpenDocument Graphics (ODG) diagrams created in LibreOffice into scalable vector graphics (SVG) for web display while preserving the correct viewBox dimensions.
 * 2. When an application must batch‑process engineering drawings stored as ODG files and output SVG files that retain the original page size for accurate rendering in browsers.
 * 3. When a .NET service integrates with a document management system and must transform user‑uploaded ODG illustrations into SVG format so that downstream tools can manipulate the vector data with proper scaling.
 * 4. When a reporting tool generates charts in ODG format and the developer wants to embed them in HTML reports as SVG with a correctly set viewBox to ensure responsive layout.
 * 5. When a developer is building a cross‑platform design viewer that loads ODG assets and needs to export them as SVG with the viewBox attribute automatically calculated from the image size for consistent zoom and pan behavior.
 */