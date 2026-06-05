using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define image dimensions and DPI
            int width = 800;
            int height = 600;
            int dpi = 300;

            // Create an SVG canvas
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);
            // Draw a simple diagonal line
            graphics.DrawLine(new Pen(Color.Black, 2), 0, 0, width, height);

            // Finalize SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Configure rasterization to produce a transparent background
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = new Size(width, height)
                };

                // Set PNG options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Output path (hard‑coded)
                string outputPath = "Output/output.png";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the rendered PNG
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate high‑resolution product thumbnails from SVG logos for an e‑commerce catalog, rendering the vector at 300 DPI and saving it as a lossless PNG with a transparent background ensures crisp visuals on any device.
 * 2. When creating printable marketing materials programmatically, a developer can rasterize SVG illustrations at 300 DPI to meet print quality standards while preserving transparency for seamless overlay on PDFs.
 * 3. When building a web application that dynamically produces icons from SVG assets for UI themes, rendering them at 300 DPI and exporting to PNG guarantees sharp, scalable icons with no background artifacts.
 * 4. When automating the conversion of SVG diagrams into high‑definition PNGs for inclusion in technical documentation, using Aspose.Imaging’s rasterization options provides lossless output with exact dimensions and transparent background.
 * 5. When developing a desktop tool that extracts vector graphics from CAD files and needs to display them on high‑DPI monitors, rendering the SVG at 300 DPI and saving as a transparent PNG delivers pixel‑perfect previews without loss of detail.
 */