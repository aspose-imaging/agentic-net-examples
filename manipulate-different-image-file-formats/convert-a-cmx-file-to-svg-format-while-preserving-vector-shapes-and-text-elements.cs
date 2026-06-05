using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cmx";
        string outputPath = @"C:\temp\sample.svg";

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

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Set up SVG save options
                var svgOptions = new SvgOptions
                {
                    // Render text as vector shapes to preserve appearance
                    TextAsShapes = true
                };

                // Configure rasterization options specific to CMX
                var rasterOptions = new CmxRasterizationOptions
                {
                    // Use the source image size for the SVG page
                    PageSize = cmxImage.Size,
                    // Optional: set a background color if needed
                    BackgroundColor = Color.White
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as SVG
                cmxImage.Save(outputPath, svgOptions);
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
 * 1. When a CAD engineer needs to embed legacy CorelDRAW CMX drawings into a web page as scalable SVG graphics while preserving vector shapes and exact text appearance.
 * 2. When a document conversion service must batch‑process CMX files into SVG to enable resolution‑independent printing and editing in vector editors using C# image processing APIs.
 * 3. When a GIS application imports CMX map symbols and converts them to SVG so the symbols remain fully vectorized and text is rendered as shapes for responsive UI components.
 * 4. When an e‑learning platform transforms CMX illustrations into SVG to support interactive scaling, accessibility, and cross‑browser rendering without rasterizing the original text.
 * 5. When a legacy design workflow requires an automated C# script that preserves vector shapes and text while migrating CMX assets to modern SVG format for version control and collaborative editing.
 */