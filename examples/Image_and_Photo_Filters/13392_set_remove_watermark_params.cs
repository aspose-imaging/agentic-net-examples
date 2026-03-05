using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the source image
        using (var image = Image.Load(inputPath))
        {
            // Cast to the specific PNG image type
            var pngImage = (PngImage)image;

            // Create a mask that defines the watermark region (ellipse example)
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Adjust the rectangle values to match the actual watermark location
            figure.AddShape(new EllipseShape(new RectangleF(100, 50, 200, 100)));
            mask.AddFigure(figure);

            // Configure Telea algorithm options
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask)
            {
                // HalfPatchSize influences the inpainting radius; larger values act like a higher threshold
                HalfPatchSize = 4
                // Note: Direct watermark color configuration is not exposed; the algorithm works on pixel differences.
            };

            // Perform watermark removal
            var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);

            // Save the processed image
            result.Save(outputPath);
        }
    }
}