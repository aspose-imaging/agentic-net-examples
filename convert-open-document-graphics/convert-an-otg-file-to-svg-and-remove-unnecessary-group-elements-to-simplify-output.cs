using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
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
                    // Remove metadata to simplify the resulting SVG
                    KeepMetadata = false,
                    // No compression for plain SVG output
                    Compress = false
                };

                // Set rasterization options based on the source image size
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to convert legacy OTG (OpenType Graphics) files into web‑friendly SVG format while stripping metadata to reduce file size for faster page loads.
 * 2. When an application must batch‑process engineering diagrams stored as OTG and generate clean SVG assets for inclusion in responsive UI components.
 * 3. When a C# service integrates Aspose.Imaging to transform scanned vector graphics into scalable SVGs for printing workflows that require precise page dimensions.
 * 4. When a developer wants to automate the creation of SVG icons from OTG source files and ensure the output contains no unnecessary group elements that could complicate downstream editing.
 * 5. When a .NET desktop tool needs to read an OTG image, preserve its original dimensions, and export a plain SVG without compression for compatibility with vector‑editing software.
 */