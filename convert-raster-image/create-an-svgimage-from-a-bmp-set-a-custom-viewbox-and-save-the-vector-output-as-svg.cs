using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP image
            using (RasterImage bmpImage = (RasterImage)Image.Load(inputPath))
            {
                int width = bmpImage.Width;
                int height = bmpImage.Height;

                // Create an SVG graphics context with the same dimensions
                var graphics = new SvgGraphics2D(width, height, 96);

                // Draw the BMP onto the SVG canvas
                graphics.DrawImage(bmpImage, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

                // Finalize SVG recording and obtain the SvgImage instance
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the SVG to a memory stream first
                    using (var tempStream = new MemoryStream())
                    {
                        svgImage.Save(tempStream);
                        tempStream.Position = 0;

                        // Load the SVG XML, set a custom viewBox, and save to the final file
                        XDocument xDoc = XDocument.Load(tempStream);
                        XElement root = xDoc.Root;
                        if (root != null)
                        {
                            // Example custom viewBox
                            root.SetAttributeValue("viewBox", "0 0 200 200");
                        }

                        using (var outFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            xDoc.Save(outFile);
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
 * 1. When a developer needs to convert legacy BMP icons into scalable SVG graphics for responsive web design, they can use this code to generate vector files with a custom viewBox.
 * 2. When an application must embed high‑resolution raster logos into PDF reports as vector objects, the BMP‑to‑SVG conversion with viewBox adjustment ensures crisp scaling on any device.
 * 3. When a GIS system imports bitmap map tiles and requires them as SVG overlays with precise coordinate framing, this snippet creates SVG images with a defined viewBox for accurate georeferencing.
 * 4. When an e‑learning platform wants to transform scanned BMP diagrams into scalable SVG illustrations that adapt to different screen sizes, the code provides an automated pipeline for the conversion.
 * 5. When a desktop utility needs to batch‑process user‑uploaded BMP screenshots into SVG assets for UI theming, the example demonstrates how to load, draw, set a custom viewBox, and save the vector output in C#.
 */