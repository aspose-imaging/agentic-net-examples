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
            ApngImage apng = (ApngImage)image;

            // Define the watermark mask (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
            mask.AddFigure(figure);

            // Configure Telea algorithm options
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Remove the watermark
            using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(apng, options))
            {
                // Save the cleaned image as APNG
                result.Save(outputPath, new ApngOptions());
            }
        }
    }
}