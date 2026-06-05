using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
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

            string outputDirectory = "output_paths";
            Directory.CreateDirectory(outputDirectory);

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                var frames = tiffImage.Frames.ToArray();
                for (int frameIndex = 0; frameIndex < frames.Length; frameIndex++)
                {
                    tiffImage.ActiveFrame = frames[frameIndex];
                    List<PathResource> pathResources = tiffImage.ActiveFrame.PathResources;
                    if (pathResources == null || pathResources.Count == 0)
                        continue;

                    for (int pathIndex = 0; pathIndex < pathResources.Count; pathIndex++)
                    {
                        var pathResource = pathResources[pathIndex];
                        var graphicsPath = PathResourceConverter.ToGraphicsPath(
                            new[] { pathResource }, tiffImage.ActiveFrame.Size);

                        var svgGraphics = new SvgGraphics2D(tiffImage.ActiveFrame.Width, tiffImage.ActiveFrame.Height, 96);
                        svgGraphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                        using (SvgImage svgImage = svgGraphics.EndRecording())
                        {
                            string outputPath = Path.Combine(outputDirectory,
                                $"frame{frameIndex}_path{pathIndex}.svg");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
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
 * 1. When a publishing workflow requires converting multi‑page TIFF artwork with embedded clipping paths into scalable SVG outlines for each page, this code can extract and save them as separate SVG files.
 * 2. When a GIS application needs to reuse vector boundaries stored as TIFF clipping paths for different map layers, the code enables exporting those paths to SVG for further manipulation.
 * 3. When a print‑to‑web service must provide vector cut‑lines from high‑resolution TIFF proofs to web designers, the snippet extracts each frame’s clipping path and writes it as an SVG file.
 * 4. When an e‑learning platform wants to animate individual frames of a scanned diagram by using its original clipping paths as SVG masks, this code supplies the necessary SVG assets.
 * 5. When a quality‑control tool audits scanned documents by comparing the original TIFF clipping paths against regenerated SVG vectors, the example automates the extraction of those paths per frame.
 */