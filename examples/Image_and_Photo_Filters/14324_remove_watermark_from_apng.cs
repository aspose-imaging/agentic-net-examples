using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage (inherits from RasterImage)
            ApngImage apngImage = (ApngImage)image;

            // Create a mask for the watermark region
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Example ellipse mask; adjust coordinates as needed
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
            mask.AddFigure(figure);

            // Configure watermark removal options (Telea algorithm)
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Apply watermark removal; returns a new RasterImage
            using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(apngImage, options))
            {
                // Save the processed image as APNG
                result.Save(outputPath, new ApngOptions());
            }
        }
    }
}