using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\Temp\gradient_demo.svg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions and DPI
            int width = 600;
            int height = 400;
            int dpi = 96;

            // Create an SVG graphics context
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw a black border rectangle
            graphics.DrawRectangle(new Pen(Color.Black, 2), 0, 0, width, height);

            // NOTE: Gradient fills are not supported with FillXXX methods in Aspose.Imaging.
            // Therefore, we use a solid brush as a fallback.
            // Fill the background with a solid light gray color.
            graphics.FillRectangle(
                new Pen(Color.LightGray, 1),
                new SolidBrush(Color.LightGray),
                0,
                0,
                width,
                height);

            // Create a path consisting of a rectangle and an ellipse
            Figure figure = new Figure { IsClosed = true };
            GraphicsPath path = new GraphicsPath();
            path.AddFigure(figure);
            figure.AddShapes(new Shape[]
            {
                new RectangleShape(new Rectangle(100, 100, 200, 150)),
                new EllipseShape(new Rectangle(350, 100, 200, 150))
            });

            // Fill the path with a solid blue brush and outline with a dark blue pen
            graphics.FillPath(
                new Pen(Color.DarkBlue, 2),
                new SolidBrush(Color.Blue),
                path);

            // Add some text
            Font font = new Font("Arial", 36, FontStyle.Regular);
            graphics.DrawString(font, "Gradient Demo", new Point(150, 300), Color.DarkRed);

            // Finalize and save the SVG image
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
 * 1. When a developer needs to create a scalable SVG logo with custom geometric shapes and programmatically apply solid or gradient‑like fills using Aspose.Imaging for .NET in C#, this code demonstrates how to draw rectangles, ellipses, and text and save the vector image as an SVG file.
 * 2. When an automated reporting tool must embed a vector‑based chart header that includes colored shapes and a background fill without relying on external image assets, the example shows how to generate the SVG on the fly with Aspose.Imaging’s SvgGraphics2D class.
 * 3. When a web application requires dynamic generation of SVG icons that match the site’s color scheme and DPI settings, developers can use this snippet to programmatically construct the icon, apply a solid brush as a fallback for gradient fills, and write the result to a .svg file.
 * 4. When a desktop utility needs to export a printable brochure section as a resolution‑independent vector file, the code illustrates how to set the image dimensions, draw a border, fill the background, and render shapes using C# and Aspose.Imaging’s vector drawing API.
 * 5. When a CI/CD pipeline must produce SVG assets for documentation or UI mockups as part of an automated build, this example provides a concise way to create the vector image, apply color fills, and store it in a known folder using standard .NET file‑system calls.
 */