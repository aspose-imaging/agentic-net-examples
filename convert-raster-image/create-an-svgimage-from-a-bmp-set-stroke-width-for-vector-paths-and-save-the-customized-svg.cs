using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.bmp";
        string outputPath = "output.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image
        using (Aspose.Imaging.Image bmpImage = Aspose.Imaging.Image.Load(inputPath))
        {
            int width = bmpImage.Width;
            int height = bmpImage.Height;

            // Create SVG graphics canvas
            var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(width, height, 96);

            // Set stroke width for vector paths (draw a rectangle border)
            var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 5);
            graphics.DrawRectangle(pen, 0, 0, width, height);

            // Draw the raster BMP onto the SVG canvas
            var raster = (Aspose.Imaging.RasterImage)bmpImage;
            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

            // Finalize SVG image and save
            using (Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}