using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output SVG file paths
        string dir = @"C:\temp\";
        string inputSvgPath = Path.Combine(dir, "input.svg");
        string outputSvgPath = Path.Combine(dir, "output.svg");

        // Load the existing SVG image
        using (Image image = Image.Load(inputSvgPath))
        {
            // Cast the loaded image to SvgImage
            SvgImage svgImage = (SvgImage)image;

            // Create a SvgGraphics2D object for drawing on the loaded SVG
            SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

            // Draw a red rectangle outline
            Pen redPen = new Pen(Color.Red, 2);
            graphics.DrawRectangle(redPen, 50, 50, 200, 100);

            // Fill the same rectangle with blue color using a SolidBrush
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillRectangle(redPen, blueBrush, 50, 50, 200, 100);
            }

            // Draw a green diagonal line across the entire image
            Pen greenPen = new Pen(Color.Green, 1);
            graphics.DrawLine(greenPen, 0, 0, svgImage.Width, svgImage.Height);

            // Draw a text string onto the SVG
            Font font = new Font("Arial", 24, FontStyle.Regular);
            graphics.DrawString(font, "Modified SVG", new Point(100, 200), Color.Black);

            // Finalize the drawing and obtain the modified SVG image
            using (SvgImage resultSvg = graphics.EndRecording())
            {
                // Save the modified SVG to the output path
                resultSvg.Save(outputSvgPath);
            }
        }
    }
}