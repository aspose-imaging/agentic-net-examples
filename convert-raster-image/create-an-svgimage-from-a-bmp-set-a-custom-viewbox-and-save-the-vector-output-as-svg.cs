using System;
using System.IO;
using System.Xml;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image bmpImage = Image.Load(inputPath))
        {
            // Cast to RasterImage for drawing
            var raster = bmpImage as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Failed to load raster image.");
                return;
            }

            // Create an SVG graphics context with the same dimensions as the BMP
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96; // standard screen DPI

            var graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the BMP onto the SVG canvas
            graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

            // Finalize SVG recording and obtain the SvgImage instance
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG to a memory stream first
                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream);
                    memoryStream.Position = 0;

                    // Load the SVG XML for manipulation
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(memoryStream);

                    // Set a custom viewBox attribute (example values)
                    XmlElement root = xmlDoc.DocumentElement;
                    if (root != null)
                    {
                        root.SetAttribute("viewBox", "0 0 200 200");
                    }

                    // Write the modified SVG XML to the output file
                    using (var fileStream = File.Create(outputPath))
                    {
                        xmlDoc.Save(fileStream);
                    }
                }
            }
        }
    }
}