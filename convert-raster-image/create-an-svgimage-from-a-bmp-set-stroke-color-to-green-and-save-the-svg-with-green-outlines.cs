// HOW-TO: Create SVG From BMP With Green Outline Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/sample.bmp";
        string outputPath = "output/result.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (RasterImage bmpImage = (RasterImage)Image.Load(inputPath))
            {
                // Create SVG graphics with the same dimensions as the BMP
                int width = bmpImage.Width;
                int height = bmpImage.Height;
                int dpi = 96; // standard screen DPI

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the BMP onto the SVG canvas
                graphics.DrawImage(bmpImage, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

                // Draw a green rectangle outline around the image to set the stroke color to green
                Pen greenPen = new Pen(Color.Green, 2);
                graphics.DrawRectangle(greenPen, 0, 0, width, height);

                // Finalize SVG image
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
 * 1. When you need to convert a legacy BMP graphic into a scalable SVG for web display while adding a green border to highlight the image.
 * 2. When generating vector assets from raster screenshots for documentation and you want the outlines colored green to match branding guidelines.
 * 3. When automating a batch process that creates SVG diagrams from BMP files and requires a consistent green stroke around each diagram for visual emphasis.
 * 4. When integrating image conversion into a C# application that must produce SVG files with custom stroke colors for downstream editing in vector editors.
 * 5. When preparing printable SVG assets from BMP sources and need a green rectangle outline to indicate cut lines or safety margins.
 */
