using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = Path.Combine("output", "result.svg");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing SVG image
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Create a graphics object bound to the loaded SVG
            using (SvgGraphics2D graphics = new SvgGraphics2D(svgImage))
            {
                // Example edit: draw a semi‑transparent red rectangle at (10,10) with size 100x50
                var pen = new Pen(Color.Black, 2);
                var brush = new Brushes.SolidBrush(Color.FromArgb(128, 255, 0, 0)); // 50% transparent red
                graphics.DrawRectangle(pen, 10, 10, 100, 50);
                graphics.FillRectangle(pen, brush, 10, 10, 100, 50);

                // Finalize drawing and obtain the modified SVG image
                using (SvgImage editedImage = graphics.EndRecording())
                {
                    // Save the edited SVG back to disk
                    editedImage.Save(outputPath);
                }
            }
        }
    }
}