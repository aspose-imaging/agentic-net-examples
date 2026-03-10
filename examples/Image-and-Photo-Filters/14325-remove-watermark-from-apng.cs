using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

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
            // Cast to ApngImage (multi-frame image)
            ApngImage apngImage = (ApngImage)image;

            // Cast to RasterImage for watermark removal
            RasterImage raster = (RasterImage)apngImage;

            // Define the mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
            mask.AddFigure(figure);

            // Create watermark removal options (Telea algorithm)
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Remove the watermark; result is a new RasterImage
            RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options);

            // Prepare save options for APNG output
            var saveOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new APNG image with the same dimensions as the result
            using (ApngImage newApng = (ApngImage)Image.Create(saveOptions, result.Width, result.Height))
            {
                // Ensure no default frames exist
                newApng.RemoveAllFrames();

                // Add the processed frame
                newApng.AddFrame(result);

                // Save the APNG image
                newApng.Save();
            }

            // Dispose the result raster image
            result.Dispose();
        }
    }
}