using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Cache image data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Increase brightness by 30 units
            image.AdjustBrightness(30);

            // Increase contrast by a factor of 1.2
            image.AdjustContrast(1.2f);

            // Resize the image to half of its original dimensions
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;
            image.Resize(newWidth, newHeight); // Uses default NearestNeighbourResample

            // Rotate the image 90 degrees clockwise
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the processed image as PNG
            PngOptions options = new PngOptions();
            image.Save(outputPath, options);
        }
    }
}