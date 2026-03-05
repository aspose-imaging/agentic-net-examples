using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG file path
        string jpgPath = "input.jpg";
        // Output APNG file path (PNG extension)
        string outputPath = "output.png";

        // Load the JPG image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(jpgPath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 500, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG canvas with the same dimensions as the source JPG
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add the JPG as the first (and only) frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG file
                apngImage.Save();
            }
        }
    }
}