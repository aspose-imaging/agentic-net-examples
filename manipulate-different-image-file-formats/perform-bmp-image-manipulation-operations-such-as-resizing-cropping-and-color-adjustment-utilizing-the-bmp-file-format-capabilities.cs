using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output BMP file paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Load the BMP image
        using (BmpImage image = (BmpImage)Image.Load(inputPath))
        {
            // Cache image data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Adjust brightness (+30) and contrast (+0.2)
            image.AdjustBrightness(30);
            image.AdjustContrast(0.2f);

            // Resize the image to 800x600 (default NearestNeighbourResample)
            image.Resize(800, 600);

            // Crop a rectangle starting at (50,50) with size 400x300
            var cropRect = new Rectangle(50, 50, 400, 300);
            image.Crop(cropRect);

            // Save the processed image as BMP
            image.Save(outputPath, new BmpOptions());
        }
    }
}