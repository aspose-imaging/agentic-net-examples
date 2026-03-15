using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output images
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to the specific format (PNG in this example)
            var pngImage = (PngImage)image;

            // Define the mask region for watermark removal
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Example ellipse mask; adjust coordinates as needed
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Create watermark removal options (using Telea algorithm)
            var options = new TeleaWatermarkOptions(mask);

            // Perform watermark removal
            var result = WatermarkRemover.PaintOver(pngImage, options);

            // Validate that the resulting image retains the original dimensions
            if (result.Width != pngImage.Width || result.Height != pngImage.Height)
            {
                throw new InvalidOperationException("Result dimensions do not match the original image.");
            }

            // Save the processed image
            using (result)
            {
                result.Save(outputPath);
            }

            Console.WriteLine("Watermark removal completed and dimensions validated successfully.");
        }
    }
}