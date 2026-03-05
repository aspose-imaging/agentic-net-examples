using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to specific format (PNG)
            PngImage pngImage = (PngImage)image;

            // Define the mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Ellipse covering a region; adjust coordinates as needed
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 220, 230)));
            mask.AddFigure(figure);

            // Create watermark removal options (Telea algorithm)
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Remove the watermark
            RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);

            // Save the resulting image
            result.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });

            // Inspect the result: print dimensions and a sample pixel ARGB value
            Console.WriteLine($"Result Width: {result.Width}");
            Console.WriteLine($"Result Height: {result.Height}");

            // Get ARGB value of the top-left pixel
            int argb = result.GetArgb32Pixel(0, 0);
            Console.WriteLine($"Top-left pixel ARGB: 0x{argb:X8}");

            // Dispose the result image
            result.Dispose();
        }
    }
}