using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.svg";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Increase canvas size by 10%
                int newWidth = (int)(wmfImage.Width * 1.10);
                int newHeight = (int)(wmfImage.Height * 1.10);
                wmfImage.ResizeCanvas(new Rectangle(0, 0, newWidth, newHeight));

                // Prepare SVG save options with rasterization settings
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = wmfImage.Size,
                    RenderMode = WmfRenderMode.Auto
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save the enlarged image as SVG
                wmfImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert legacy WMF vector drawings into scalable SVG files while adding a 10% margin for printing or UI layout.
 * 2. When an application must automatically enlarge the canvas of a WMF logo by 10% before exporting it as an SVG for responsive web design.
 * 3. When a batch processing tool has to ensure that WMF icons fit within a larger viewport by resizing the canvas and saving them as SVG for cross‑platform compatibility.
 * 4. When a reporting system requires converting WMF charts to SVG with a white‑smoke background and a slight canvas increase to avoid clipping in PDF exports.
 * 5. When a C# service integrates Aspose.Imaging to prepare WMF artwork for vector‑based editing tools by expanding its size and exporting it as an SVG with rasterization options.
 */