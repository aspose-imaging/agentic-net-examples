// HOW-TO: Convert OTG File to SVG with Layer Names Preserved in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer names if supported)
                    KeepMetadata = true,
                    // Configure rasterization to match source size
                    VectorRasterizationOptions = new SvgRasterizationOptions
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
 * 1. When you need to export a multi‑layer OTG design to a scalable SVG for web display while keeping the original layer names for later editing.
 * 2. When an automated pipeline must convert batch OTG files to SVG format and retain metadata so downstream tools can identify each layer.
 * 3. When a CAD or GIS application stores drawings as OTG and you want to generate SVG maps that preserve layer information for styling in vector editors.
 * 4. When integrating Aspose.Imaging into a C# service that receives OTG uploads and returns SVGs with intact layer hierarchy for client‑side manipulation.
 * 5. When creating documentation that requires high‑resolution vector graphics from OTG sources, and you need the SVG to include the original layer names for accurate legends.
 */
