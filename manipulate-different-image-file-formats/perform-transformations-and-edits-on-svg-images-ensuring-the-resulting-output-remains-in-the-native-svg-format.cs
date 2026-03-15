using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

namespace SvgTransformationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output SVG file paths
            string inputSvgPath = "input.svg";
            string outputSvgPath = "output.svg";

            // Load the existing SVG image
            using (Image image = Image.Load(inputSvgPath))
            {
                // Cast to SvgImage for vector operations
                SvgImage svgImage = (SvgImage)image;

                // Create a graphics object bound to the loaded SVG
                SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

                // Draw a blue rectangle border
                graphics.DrawRectangle(new Pen(Color.Blue, 2), 10, 10, 200, 100);

                // Fill the rectangle with yellow color
                graphics.FillRectangle(
                    new Pen(Color.Transparent, 0),
                    new SolidBrush(Color.Yellow),
                    10, 10, 200, 100);

                // Add a text label inside the rectangle
                graphics.DrawString(
                    new Font("Arial", 24, FontStyle.Regular),
                    "Edited",
                    new Point(20, 50),
                    Color.Red);

                // Finalize drawing and obtain the modified SVG image
                using (SvgImage resultImage = graphics.EndRecording())
                {
                    // Save the edited SVG, preserving native format
                    resultImage.Save(outputSvgPath);
                }
            }
        }
    }
}