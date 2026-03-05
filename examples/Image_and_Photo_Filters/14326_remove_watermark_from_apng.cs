using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the source APNG image
        using (ApngImage sourceApng = (ApngImage)Image.Load(inputPath))
        {
            // Prepare options for creating the output APNG
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = sourceApng.DefaultFrameTime,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the output APNG with the same dimensions as the source
            using (ApngImage outputApng = (ApngImage)Image.Create(createOptions, sourceApng.Width, sourceApng.Height))
            {
                // Ensure the frame collection is empty before adding processed frames
                outputApng.RemoveAllFrames();

                // Process each frame of the source APNG
                foreach (var page in sourceApng.Pages)
                {
                    // Cast the page to RasterImage for watermark removal
                    RasterImage frame = (RasterImage)page;

                    // Define a mask for the watermark region (example rectangle)
                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(10, 10, 100, 50)));
                    mask.AddFigure(figure);

                    // Create watermark removal options using the Telea algorithm
                    var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                    // Remove the watermark from the current frame
                    RasterImage cleanedFrame = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(frame, options);

                    // Add the cleaned frame to the output APNG
                    outputApng.AddFrame(cleanedFrame);

                    // Dispose the temporary cleaned frame
                    cleanedFrame.Dispose();
                }

                // Save the resulting APNG
                outputApng.Save();
            }
        }
    }
}