using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.svg";
        string outputPath = @"C:\Temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage
            SvgImage svgImage = (SvgImage)image;

            // Create graphics object for modification
            SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

            // Draw a red rectangle border
            Pen rectPen = new Pen(Color.Red, 2);
            graphics.DrawRectangle(rectPen, 10, 10, svgImage.Width - 20, svgImage.Height - 20);

            // Fill a semi-transparent blue rectangle
            Pen fillPen = new Pen(Color.Blue, 1);
            SolidBrush fillBrush = new SolidBrush(Color.FromArgb(128, Color.Blue));
            graphics.FillRectangle(fillPen, fillBrush, 20, 20, svgImage.Width - 40, svgImage.Height - 40);

            // Draw a diagonal green line
            Pen linePen = new Pen(Color.Green, 3);
            graphics.DrawLine(linePen, 0, 0, svgImage.Width, svgImage.Height);

            // Add some text
            Font textFont = new Font("Arial", 36, FontStyle.Regular);
            graphics.DrawString(textFont, "Modified SVG", new Point(50, 50), Color.Black);

            // Finalize and save the modified SVG
            using (SvgImage resultImage = graphics.EndRecording())
            {
                resultImage.Save(outputPath);
            }
        }
    }
}