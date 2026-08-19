// HOW-TO: Convert OTG to SVG with Layer Names Preserved in C# (Aspose.Imaging for .NET)
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
                    // Preserve original metadata (including layer names)
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
 * 1. When you need to export an OpenDocument Graphic (OTG) to a scalable SVG file while keeping the original layer structure for further editing.
 * 2. When a web application must dynamically convert uploaded OTG files to SVG for responsive rendering without losing layer identifiers.
 * 3. When generating printable vector assets from OTG sources and you require the layer names to map to CSS classes or scripts later.
 * 4. When automating a batch process that migrates legacy OTG diagrams to SVG format and you need to retain metadata for documentation purposes.
 * 5. When integrating Aspose.Imaging in a C# service to transform OTG images into SVG while preserving layer metadata for downstream analytics.
 */
