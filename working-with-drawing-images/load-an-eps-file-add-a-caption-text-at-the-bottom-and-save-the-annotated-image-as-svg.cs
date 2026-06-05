using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Svg;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                int width = epsImage.Width;
                int height = epsImage.Height;
                int captionHeight = 50; // extra space for caption

                // Rasterize EPS to PNG in memory
                using (MemoryStream pngStream = new MemoryStream())
                {
                    epsImage.Save(pngStream, new PngOptions());
                    pngStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(pngStream))
                    {
                        // Create SVG canvas with extra height for caption
                        SvgGraphics2D graphics = new SvgGraphics2D(width, height + captionHeight, 96);

                        // Draw the rasterized EPS image onto the SVG canvas
                        graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                        // Draw caption text at the bottom
                        Font captionFont = new Font("Arial", 24, FontStyle.Regular);
                        string captionText = "Sample Caption";
                        graphics.DrawString(captionFont, captionText, new Point(10, height + 10), Color.Black);

                        // Finalize SVG and save
                        using (SvgImage svgImage = graphics.EndRecording())
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
 * 1. When a publishing workflow needs to convert a designer‑provided EPS logo into an SVG illustration with a descriptive caption for inclusion in responsive web pages.
 * 2. When an e‑learning platform automatically annotates EPS diagrams with lesson titles and saves them as SVG files for scalable display on different devices.
 * 3. When a branding tool programmatically adds product names beneath EPS artwork and outputs SVG assets that can be edited in vector editors.
 * 4. When a reporting system extracts EPS charts, rasterizes them to PNG, overlays a timestamp caption, and stores the result as an SVG for high‑quality printing.
 * 5. When a CAD integration script converts EPS technical drawings to SVG, appends a project identifier at the bottom, and delivers the annotated vector file to downstream GIS applications.
 */