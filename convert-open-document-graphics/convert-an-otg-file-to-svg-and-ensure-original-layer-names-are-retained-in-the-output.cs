using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer names if stored there)
                    KeepMetadata = true,

                    // Set rasterization options specific to OTG
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
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
 * 1. When a design team needs to export OpenDocument graphics (OTG) created in LibreOffice Draw to scalable SVG files for web publishing while keeping the original layer names for later editing.
 * 2. When an automated build pipeline must convert batch‑processed OTG assets into SVG format for inclusion in a responsive UI, ensuring metadata such as layer identifiers is retained.
 * 3. When a C# application integrates with a digital asset management system and must transform client‑supplied OTG illustrations into SVG vectors without losing the hierarchical layer structure.
 * 4. When a GIS or CAD workflow requires converting technical diagrams stored as OTG into SVG for overlay on maps, preserving layer names to map features correctly.
 * 5. When a documentation generator needs to programmatically render OTG schematics as SVG diagrams in PDF manuals while maintaining layer names for searchable indexing.
 */