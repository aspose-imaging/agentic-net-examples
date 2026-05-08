using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG as a raster image
            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                // Create an SVG graphics canvas
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Create a linear gradient brush (red to blue)
                var gradientBrush = new LinearGradientBrush(
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(width, height),
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Blue);

                // Pen for the rectangle outline
                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1);

                // Fill the entire canvas with the gradient
                graphics.FillRectangle(pen, gradientBrush, 0, 0, width, height);

                // Finalize and save the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
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