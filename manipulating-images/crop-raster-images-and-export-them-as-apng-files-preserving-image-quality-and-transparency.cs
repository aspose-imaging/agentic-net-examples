using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";

        // Crop rectangle parameters (adjust as needed)
        int cropX = 50;
        int cropY = 50;
        int cropWidth = 200;
        int cropHeight = 200;

        // Load the raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Cache image data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Perform cropping
            var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            image.Crop(cropRect);

            // Prepare APNG save options preserving transparency
            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 500 // duration of the single frame in milliseconds
            };

            // Save the cropped image as an APNG file
            image.Save(outputPath, apngOptions);
        }
    }
}