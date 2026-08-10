// HOW-TO: Add Caption to EPS and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    // Rasterize EPS to PNG in memory
                    epsImage.Save(memoryStream, new PngOptions());
                    memoryStream.Position = 0;

                    using (var rasterImage = (RasterImage)Image.Load(memoryStream))
                    {
                        int width = epsImage.Width;
                        int height = epsImage.Height;
                        int dpi = 96;

                        var graphics = new SvgGraphics2D(width, height, dpi);

                        // Draw the rasterized EPS image onto the SVG canvas
                        graphics.DrawImage(rasterImage, new Point(0, 0));

                        // Add caption text at the bottom
                        string caption = "Sample Caption";
                        var font = new Font("Arial", 24, FontStyle.Regular);
                        int textX = 10;
                        int textY = height - 30; // 30 pixels above the bottom edge
                        graphics.DrawString(font, caption, new Point(textX, textY), Color.Black);

                        // Finalize SVG and save
                        using (var svgImage = graphics.EndRecording())
                        {
                            svgImage.Save(outputPath);
                        }
                    }
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
 * 1. When you need to annotate a vector EPS logo with a product name and export it as scalable SVG for web use.
 * 2. When generating printable marketing materials that require adding dynamic text to EPS artwork before converting to SVG for responsive layouts.
 * 3. When automating batch processing of EPS diagrams to include footnotes or timestamps and saving them as lightweight SVG files.
 * 4. When integrating EPS drawings into a C# application that must display them with custom captions in browsers supporting SVG.
 * 5. When converting legacy EPS illustrations to SVG while preserving visual fidelity and adding descriptive labels for accessibility.
 */
