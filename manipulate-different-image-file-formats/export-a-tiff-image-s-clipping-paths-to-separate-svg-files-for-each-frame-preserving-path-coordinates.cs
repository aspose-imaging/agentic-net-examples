using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputBaseDir = "output_paths";

            using (var tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int frameIndex = 0;
                foreach (var frame in tiffImage.Frames)
                {
                    tiffImage.ActiveFrame = frame;
                    var pathResources = tiffImage.ActiveFrame.PathResources;
                    if (pathResources == null || pathResources.Count == 0)
                    {
                        frameIndex++;
                        continue;
                    }

                    int pathIndex = 0;
                    foreach (var resource in pathResources)
                    {
                        var graphicsPath = PathResourceConverter.ToGraphicsPath(
                            new[] { resource },
                            tiffImage.ActiveFrame.Size);

                        var svgGraphics = new SvgGraphics2D(
                            tiffImage.ActiveFrame.Width,
                            tiffImage.ActiveFrame.Height,
                            96);

                        svgGraphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                        using (var svgImage = svgGraphics.EndRecording())
                        {
                            string outputPath = Path.Combine(
                                outputBaseDir,
                                $"frame{frameIndex}_path{pathIndex}.svg");

                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            svgImage.Save(outputPath);
                        }

                        pathIndex++;
                    }

                    frameIndex++;
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
 * 1. When a developer needs to extract vector clipping paths from a multi‑page TIFF document and save them as separate SVG files for scalable web or print layouts.
 * 2. When an image‑processing workflow must convert each frame’s clipping path in a scanned TIFF into individual SVG assets for further editing in design tools.
 * 3. When a GIS application requires preserving geographic vector outlines stored as TIFF path resources and exporting them to SVG for integration with mapping libraries.
 * 4. When an e‑commerce platform wants to generate SVG cut‑out masks from product photos saved as multi‑frame TIFFs to apply dynamic overlays in a browser.
 * 5. When a digital‑archiving system must isolate and archive each frame’s clipping paths from high‑resolution TIFF scans as independent SVG files for future metadata analysis.
 */