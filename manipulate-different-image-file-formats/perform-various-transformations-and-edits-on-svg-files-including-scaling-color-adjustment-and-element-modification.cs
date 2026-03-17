using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output SVG file paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage for SVG-specific operations
            SvgImage svg = (SvgImage)image;

            // Scale the SVG (double its size)
            int newWidth = svg.Width * 2;
            int newHeight = svg.Height * 2;
            svg.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Adjust background color
            svg.BackgroundColor = Color.LightGray;
            svg.HasBackgroundColor = true;

            // Modify elements using SvgGraphics2D
            SvgGraphics2D graphics = new SvgGraphics2D(svg);

            // Draw a red rectangle border around the image
            graphics.DrawRectangle(new Pen(Color.Red, 2), 0, 0, svg.Width, svg.Height);

            // Fill a yellow rectangle inside the image
            graphics.FillRectangle(
                new Pen(Color.Black, 1),
                new SolidBrush(Color.Yellow),
                20, 20,
                svg.Width - 40,
                svg.Height - 40);

            // Finalize drawing and obtain the modified SVG image
            using (SvgImage finalSvg = graphics.EndRecording())
            {
                // Save the modified SVG
                finalSvg.Save(outputPath);
            }
        }
    }
}