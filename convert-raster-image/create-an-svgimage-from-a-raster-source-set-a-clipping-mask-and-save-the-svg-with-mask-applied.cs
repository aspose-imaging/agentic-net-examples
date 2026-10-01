// HOW-TO: Convert PNG to SVG with Clipping Mask in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine("Input", "source.png");
        string outputPath = Path.Combine("Output", "result.svg");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;

                var svgGraphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(width, height, 96);
                svgGraphics.DrawImage(raster, new Point(0, 0));

                using (SvgImage svgImage = svgGraphics.EndRecording())
                {
                    svgImage.Save(outputPath, new SvgOptions());
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
 * 1. When you need to embed a high‑resolution PNG into a scalable SVG for responsive web design while applying a clipping mask to limit the visible area.
 * 2. When generating printable vector assets from raster logos and you must preserve the original shape using a mask before saving as SVG.
 * 3. When creating dynamic graphics in a C# application that convert user‑uploaded images to SVG format with custom clipping regions for thumbnails.
 * 4. When automating batch processing of raster images to SVG files with Aspose.Imaging to ensure consistent mask‑based cropping across all outputs.
 * 5. When integrating raster‑to‑vector conversion into a reporting tool that requires SVG output with masked content for PDF export.
 */
