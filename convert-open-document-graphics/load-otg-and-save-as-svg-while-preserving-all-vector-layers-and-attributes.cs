// HOW-TO: Convert OTG File To SVG While Preserving Vector Layers In C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.svg";

            // Verify input file exists
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
                // Configure SVG rasterization options to preserve vector data
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = svgRasterOptions,
                    KeepMetadata = true // preserve original metadata
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
 * 1. When you need to export a multi‑layer OTG illustration to an SVG for web display without losing any vector shapes or metadata.
 * 2. When a graphics pipeline requires converting proprietary OTG assets into scalable SVG files for responsive UI rendering.
 * 3. When automating batch processing of OTG drawings to SVG format to maintain editability in vector editors like Inkscape.
 * 4. When integrating OTG to SVG conversion into a C# application that must keep original metadata for archival or compliance purposes.
 * 5. When generating SVG previews of OTG files for thumbnail generation while preserving the original vector information.
 */
