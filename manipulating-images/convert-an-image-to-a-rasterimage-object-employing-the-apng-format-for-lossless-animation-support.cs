using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input raster image and output APNG file paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Load the source image as a RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG creation options
            ApngOptions options = new ApngOptions
            {
                // Bind the output file to the creation source
                Source = new FileCreateSource(outputPath, false),
                // Set default frame duration (in milliseconds)
                DefaultFrameTime = 100,
                // Use truecolor with alpha for lossless animation
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG image with the same dimensions as the source raster image
            using (ApngImage apngImage = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
            {
                // Remove the automatically added initial frame
                apngImage.RemoveAllFrames();

                // Add the source image as the sole frame of the animation
                apngImage.AddFrame(sourceImage);

                // Save the APNG; the output file is already bound via FileCreateSource
                apngImage.Save();
            }
        }
    }
}