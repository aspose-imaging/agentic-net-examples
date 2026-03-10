using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input APNG and output APNG
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to ApngImage
            ApngImage apng = (ApngImage)image;

            // Assume the first frame can be treated as a RasterImage
            RasterImage frame = (RasterImage)apng.Pages[0];

            // Create a mask defining the watermark region (example ellipse)
            GraphicsPath mask = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
            mask.AddFigure(figure);

            // Initialize watermark removal options (Telea algorithm)
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Remove the watermark from the frame
            RasterImage cleanedFrame = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(frame, options);

            // Replace the default image of the APNG with the cleaned frame
            apng.SetDefaultImage(cleanedFrame);

            // Save the modified APNG
            ApngOptions saveOptions = new ApngOptions();
            apng.Save(outputPath, saveOptions);
        }
    }
}