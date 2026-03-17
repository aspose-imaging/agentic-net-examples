using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Input and output BMP file paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Load the BMP image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!image.IsCached)
            {
                image.CacheData();
            }

            // Increase brightness by 30 (range -255 to 255)
            image.AdjustBrightness(30);

            // Increase contrast by 20%
            image.AdjustContrast(1.2f);

            // Apply gamma correction (value less than 1 darkens the image)
            image.AdjustGamma(0.9f);

            // Crop a rectangle starting at (50,50) with width=200 and height=150
            var cropRect = new Rectangle(50, 50, 200, 150);
            image.Crop(cropRect);

            // Resize the image to 400x300 using the default NearestNeighbourResample
            image.Resize(400, 300);

            // Save the processed image as BMP
            BmpOptions bmpOptions = new BmpOptions();
            image.Save(outputPath, bmpOptions);
        }
    }
}