using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input image path
        string inputPath = "input.png";
        // Output APNG path
        string outputPath = "output.apng";

        // Define crop rectangle (x, y, width, height)
        int x = 50;
        int y = 30;
        int width = 200;
        int height = 150;

        // Load source image as RasterImage
        using (Aspose.Imaging.RasterImage sourceImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Crop the image to the specified rectangle
            sourceImage.Crop(new Aspose.Imaging.Rectangle(x, y, width, height));

            // Prepare APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 100 // default frame duration in ms (optional)
            };

            // Create APNG image with the cropped dimensions
            using (ApngImage apngImage = (ApngImage)Aspose.Imaging.Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Ensure no default frame remains
                apngImage.RemoveAllFrames();

                // Add the cropped raster image as the sole frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG file
                apngImage.Save();
            }
        }
    }
}