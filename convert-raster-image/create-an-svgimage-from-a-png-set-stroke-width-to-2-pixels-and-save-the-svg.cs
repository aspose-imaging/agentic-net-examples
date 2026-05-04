using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG image as RasterImage
            using (Aspose.Imaging.RasterImage pngImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = pngImage.Width;
                int height = pngImage.Height;

                // Create SVG graphics canvas
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, 96);

                // Draw the PNG onto the SVG
                graphics.DrawImage(pngImage, new Aspose.Imaging.Point(0, 0));

                // Set stroke width to 2 pixels by drawing a rectangle border
                graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), 0, 0, width, height);

                // Finalize SVG image
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