// HOW-TO: Resize PNG with High Quality Bicubic Interpolation and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define desired dimensions for resizing
                int newWidth = 800;
                int newHeight = 600;

                // Perform high‑quality resize using LanczosResample (bicubic‑like quality)
                raster.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Save the resized image as SVG
                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a scalable SVG version of a large PNG thumbnail for responsive web design, preserving visual quality.
 * 2. When converting high‑resolution PNG assets to smaller dimensions for mobile apps while keeping crisp edges using bicubic‑like Lanczos resampling.
 * 3. When preparing print‑ready graphics that must be resized and exported to SVG for vector‑based editing in design tools.
 * 4. When automating batch processing of PNG logos to fit a fixed 800×600 layout before embedding them in SVG diagrams.
 * 5. When integrating Aspose.Imaging in a C# backend to dynamically resize user‑uploaded PNG images and serve them as lightweight SVG files.
 */
