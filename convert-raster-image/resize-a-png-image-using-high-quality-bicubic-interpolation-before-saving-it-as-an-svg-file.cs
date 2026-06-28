using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\resized.svg";

        try
        {
            // Verify that the input file exists
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
                // Determine new dimensions (example: reduce size by 50%)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize using high‑quality bicubic interpolation (CubicConvolution)
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Prepare SVG save options
                var svgOptions = new SvgOptions();

                // Save the resized image as SVG
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
 * 1. When a web application must generate lightweight vector thumbnails from user‑uploaded PNG logos, a developer can resize the PNG with high‑quality bicubic interpolation and save it as an SVG for fast scaling.
 * 2. When an e‑commerce platform needs to create responsive product icons that look crisp on retina displays, the code can shrink the original PNG by 50 % using CubicConvolution and output an SVG for CSS‑based scaling.
 * 3. When a desktop publishing tool wants to embed scalable graphics in PDF reports, a developer can convert high‑resolution PNG assets to smaller SVG files by resizing them with Aspose.Imaging’s bicubic algorithm.
 * 4. When a mobile app prepares offline assets and must reduce bandwidth, the code can resize PNG screenshots with high‑quality interpolation and store them as SVGs that occupy less space while remaining resolution‑independent.
 * 5. When an automated build pipeline processes UI mockups, a developer can use this snippet to batch‑resize PNG mockup images and export them as SVGs for designers to edit without loss of detail.
 */