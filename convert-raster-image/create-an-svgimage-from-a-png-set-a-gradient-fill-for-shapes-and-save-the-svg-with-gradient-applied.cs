using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.png";
            string outputPath = "C:\\temp\\sample_with_gradient.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG to obtain dimensions
            using (PngImage png = (PngImage)Image.Load(inputPath))
            {
                int width = png.Width;
                int height = png.Height;
                int dpi = 96; // default DPI

                // Create SVG graphics context with same size as PNG
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Define a linear gradient brush (red to blue) covering the whole image
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new PointF(0, 0),
                    new PointF(width, height),
                    Color.Red,
                    Color.Blue);

                // Transparent pen for no outline
                Pen transparentPen = new Pen(Color.Transparent, 0);

                // Fill the entire SVG canvas with the gradient
                graphics.FillRectangle(transparentPen, gradientBrush, 0, 0, width, height);

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save SVG to output path
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