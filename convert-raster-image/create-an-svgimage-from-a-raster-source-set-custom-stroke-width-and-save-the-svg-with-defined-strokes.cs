using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0));

                // Draw a border with custom stroke width
                Pen borderPen = new Pen(Color.Black, 5);
                graphics.DrawRectangle(borderPen, 0, 0, width, height);

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