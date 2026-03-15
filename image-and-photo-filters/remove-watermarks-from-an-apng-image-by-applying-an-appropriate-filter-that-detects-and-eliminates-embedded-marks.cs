using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Define the watermark mask (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
            mask.AddFigure(figure);

            // Use Telea algorithm for watermark removal
            var options = new TeleaWatermarkOptions(mask);

            // Process each frame
            for (int i = 0; i < apng.PageCount; i++)
            {
                // Get the current frame as a raster image
                var frame = (RasterImage)apng.Pages[i];

                // Remove watermark from the frame
                RasterImage cleanedFrame = WatermarkRemover.PaintOver(frame, options);

                // Replace the original frame with the cleaned one
                apng.RemoveFrameAt(i);
                apng.InsertFrame(i, cleanedFrame);
            }

            // Save the processed APNG
            apng.Save(outputPath);
        }
    }
}