using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                GraphicsPath clipPath = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                clipPath.AddFigure(figure);

                using (SvgImage svg = new SvgImage(raster.Width, raster.Height))
                {
                    Graphics graphics = new Graphics(svg);
                    graphics.Clip = new Region(clipPath);
                    graphics.DrawImage(raster, new Point(0, 0));

                    svg.Save(outputPath, new SvgOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to embed a PNG logo in an SVG web page but display it only inside a circular area, this code converts the raster image to SVG and applies an ellipse clipping mask.
 * 2. When generating printable vector graphics from user‑uploaded photos, the snippet creates an SVG with the photo clipped to a specific shape, providing resolution‑independent output for high‑quality prints.
 * 3. When building a responsive UI that swaps raster icons for scalable SVGs, this code converts PNG icons to SVGs with a mask so the icons retain their original shape while scaling smoothly on different screen sizes.
 * 4. When preparing assets for an HTML5 canvas animation where only a portion of a bitmap should be visible, the code produces an SVG with a clipping region that can be directly referenced in the animation markup.
 * 5. When creating custom map markers that require a raster image confined to a circular badge, developers can use this approach to generate SVG marker files with the image clipped to the badge shape for use in mapping libraries.
 */