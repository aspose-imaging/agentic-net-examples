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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP save options
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    // Set 300 DPI resolution
                    bmpOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                    // Set vector rasterization options for proper rendering
                    bmpOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    // Save as BMP with the specified options
                    image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to generate high‑resolution bitmap thumbnails from scalable vector graphics for printing or archival purposes, they can use this C# code to convert SVG files to 300 DPI BMP images with Aspose.Imaging.
 * 2. When a Windows desktop application must embed vector icons into legacy components that only accept BMP format, the code enables conversion of SVG icons to 300 DPI BMP while preserving visual fidelity.
 * 3. When an automated build pipeline creates documentation PDFs and requires rasterized BMP assets at print‑ready resolution, this snippet converts source SVG diagrams to 300 DPI BMP files using Aspose.Imaging in C#.
 * 4. When a GIS system exports map layers as SVG and the downstream analysis tool only reads BMP at a specific DPI, developers can employ this example to rasterize the SVG to a 300 DPI BMP with proper background handling.
 * 5. When a game development pipeline needs to pre‑process SVG UI elements into BMP textures for older engines that lack SVG support, the code provides a straightforward way to produce 300 DPI BMP assets in C#.
 */