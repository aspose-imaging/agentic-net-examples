using System;
using System.IO;
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

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP raster image
            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                // Create an SVG graphics context with the same dimensions as the BMP
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96; // standard screen DPI

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(bmp, new Point(0, 0));

                // Create a pen with a dash style for drawing lines
                Pen dashedPen = new Pen(Color.Black, 2);
                dashedPen.DashStyle = DashStyle.Dash; // set dash pattern

                // Draw a diagonal dashed line across the image
                graphics.DrawLine(dashedPen, 0, 0, width, height);

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the SVG file
                    svgImage.Save(outputPath);
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
 * 1. When a developer needs to convert a legacy BMP diagram into a scalable SVG file while overlaying a dashed guideline for alignment, they can use this C# Aspose.Imaging code to raster‑to‑vector convert and add a dash‑styled line.
 * 2. When generating printable technical documentation that requires embedding a bitmap logo inside an SVG illustration with a decorative dashed border, this snippet provides the necessary BMP loading, SVG graphics context, and dash pattern handling.
 * 3. When creating web‑ready graphics for responsive UI components, a developer can transform a BMP asset into an SVG and programmatically draw a dashed separator line to maintain visual consistency across screen sizes.
 * 4. When automating batch processing of scanned BMP schematics and needing to highlight specific paths using dashed strokes in the resulting SVG, the code demonstrates how to load each image, draw dash‑styled lines, and save the output.
 * 5. When building a C# application that annotates medical BMP scans with dashed markers before exporting them as SVG for integration with vector‑based reporting tools, this example shows the required image loading, pen configuration, and SVG saving steps.
 */