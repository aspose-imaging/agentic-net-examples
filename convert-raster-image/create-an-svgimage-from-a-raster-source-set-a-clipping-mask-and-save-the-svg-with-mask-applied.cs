using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96;

            // Create an SVG canvas
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Point(0, 0));

            // Define a clipping mask (ellipse in the center)
            GraphicsPath maskPath = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(width / 4, height / 4, width / 2, height / 2)));
            maskPath.AddFigure(figure);

            // Visualize the mask: draw its outline
            graphics.DrawPath(new Pen(Color.Red, 2), maskPath);
            // Optionally fill the mask area with a transparent brush (no visual effect but demonstrates usage)
            graphics.FillPath(new Pen(Color.Black, 1), new SolidBrush(Color.Transparent), maskPath);

            // Finalize and save the SVG
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}