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
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
        {
            // Create an SVG graphics canvas with the same size as the bitmap
            SvgGraphics2D graphics = new SvgGraphics2D(bmp.Width, bmp.Height, 96);

            // Draw the bitmap onto the SVG canvas
            graphics.DrawImage(bmp, new Point(0, 0), new Size(bmp.Width, bmp.Height));

            // Create a pen with a dash pattern (stroke dash array)
            Pen dashPen = new Pen(Color.Black, 2);
            dashPen.DashPattern = new float[] { 5, 3 }; // 5 units dash, 3 units gap

            // Draw a rectangle using the dash pen to demonstrate the dash array
            graphics.DrawRectangle(dashPen, 0, 0, bmp.Width, bmp.Height);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}