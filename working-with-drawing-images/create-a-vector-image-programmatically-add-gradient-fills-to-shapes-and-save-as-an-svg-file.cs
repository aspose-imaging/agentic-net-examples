using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output path for the SVG file
            string outputPath = "output\\vector.svg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define canvas size and DPI
            int width = 800;
            int height = 600;
            int dpi = 96;

            // Create an SVG graphics context
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Create a pen for the rectangle outline
            Pen rectPen = new Pen(Color.Blue, 2);
            // Gradient fills are not supported for FillRectangle; using solid fill as fallback
            SolidBrush rectBrush = new SolidBrush(Color.LightBlue);
            // Fill and draw the rectangle
            graphics.FillRectangle(rectPen, rectBrush, 50, 50, 300, 200);
            graphics.DrawRectangle(rectPen, 50, 50, 300, 200);

            // Finalize the SVG image and save it
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
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
 * 1. When a developer needs to generate a scalable vector graphic (SVG) on the fly in a C# web service, such as creating a custom chart thumbnail for a dashboard, they can use Aspose.Imaging to programmatically draw shapes and save the result as an SVG file.
 * 2. When an e‑commerce platform wants to produce product‑specific promotional banners with precise dimensions and DPI, the code can create a vector canvas, draw rectangles with solid or gradient fills, and export them as lightweight SVG images for responsive web pages.
 * 3. When a reporting tool must embed vector illustrations—like highlighted sections or call‑out boxes—directly into PDF or HTML reports, developers can employ this snippet to render the shapes in SVG and then embed the file without rasterization artifacts.
 * 4. When an automated testing framework needs to verify that UI components render correctly at different resolutions, the code can programmatically generate SVG placeholders with defined width, height, and DPI to compare against expected vector assets.
 * 5. When a desktop application offers users the ability to design simple vector logos or icons and then export them for print or web use, this example shows how to create the SVG file with Aspose.Imaging’s SvgGraphics2D and save it to a user‑specified folder.
 */