// HOW-TO: Resize PNG with Bicubic Interpolation and Save as SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Example resize: reduce dimensions by half
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize using high‑quality bicubic interpolation
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Save the resized image as SVG
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to generate a smaller, high‑quality vector version of a PNG logo for responsive web design.
 * 2. When you must reduce the file size of a raster image before embedding it in an SVG‑based infographic.
 * 3. When an application requires converting user‑uploaded PNG thumbnails into scalable SVG icons while preserving visual fidelity.
 * 4. When automating batch processing of PNG assets to create resized SVG assets for print‑ready PDFs.
 * 5. When integrating Aspose.Imaging in a C# service that resizes product images and outputs them as SVG for cross‑platform rendering.
 */
