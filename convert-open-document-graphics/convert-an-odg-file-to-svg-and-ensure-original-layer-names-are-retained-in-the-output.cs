// HOW-TO: Convert ODG to SVG with Layer Names Preserved in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.svg";

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
                // Configure SVG export options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer names)
                    KeepMetadata = true,
                    // Set rasterization options such as page size and background
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    }
                };

                // Save as SVG while retaining layer information
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
 * 1. When you need to embed an OpenDocument graphic into a web page while keeping its original layer structure for interactive editing.
 * 2. When converting design assets from LibreOffice Draw to scalable SVG files for responsive UI components without losing layer information.
 * 3. When automating batch processing of ODG diagrams to SVG for inclusion in documentation pipelines that rely on layer names for indexing.
 * 4. When preserving layer metadata during format conversion to enable downstream tools to apply layer‑specific styling or animations.
 * 5. When integrating Aspose.Imaging into a C# application to transform ODG files to SVG while maintaining exact page size and background color.
 */
