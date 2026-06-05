using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image loadedImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)loadedImage;

                // Create SVG graphics canvas with same dimensions as raster image
                var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(raster.Width, raster.Height, 96);

                // Fill background with white
                var whitePen = new Pen(Color.White, 0);
                var whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whitePen, whiteBrush, 0, 0, raster.Width, raster.Height);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0));

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