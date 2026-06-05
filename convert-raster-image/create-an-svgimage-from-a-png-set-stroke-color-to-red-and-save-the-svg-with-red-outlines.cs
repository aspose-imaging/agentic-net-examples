using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.svg";

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
            // Load the PNG as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96; // default DPI for SVG graphics

                // Create an SVG graphics context
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Draw a red outline around the image
                var redPen = new Pen(Color.Red, 1);
                graphics.DrawRectangle(redPen, 0, 0, width, height);

                // Finalize SVG and save
                using (SvgImage svg = graphics.EndRecording())
                {
                    svg.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}