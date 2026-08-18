// HOW-TO: Export TIFF Frame Clipping Paths To Separate SVG Files In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Shapes;

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

            string outputDir = "output_paths";

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                TiffFrame[] frames = tiff.Frames;
                for (int i = 0; i < frames.Length; i++)
                {
                    List<PathResource> pathResources = frames[i].PathResources;
                    if (pathResources == null || pathResources.Count == 0)
                        continue;

                    GraphicsPath graphicsPath = PathResourceConverter.ToGraphicsPath(
                        pathResources.ToArray(),
                        frames[i].Size);

                    SvgGraphics2D svgGraphics = new SvgGraphics2D(frames[i].Width, frames[i].Height, 96);
                    svgGraphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                    using (SvgImage svgImage = svgGraphics.EndRecording())
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.svg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        svgImage.Save(outputPath);
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
 * 1. When you need to extract vector clipping paths from each page of a multi‑page TIFF and save them as individual SVG files for further editing or web display.
 * 2. When a printing workflow requires converting TIFF spot‑color or vector cut‑out information into SVG to be used by cutting plotters or design software.
 * 3. When you want to preserve the exact coordinates of a TIFF image’s paths while generating scalable graphics for responsive UI components.
 * 4. When automating batch processing of scanned documents that contain embedded paths, and you must separate those paths per frame into reusable SVG assets.
 * 5. When integrating Aspose.Imaging in a C# application to convert proprietary TIFF path resources into standard SVG format for cross‑platform compatibility.
 */
