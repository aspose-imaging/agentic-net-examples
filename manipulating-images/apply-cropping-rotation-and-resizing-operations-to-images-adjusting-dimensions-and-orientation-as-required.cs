using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Cropping rectangle parameters
        int cropX = 100;
        int cropY = 50;
        int cropWidth = 400;
        int cropHeight = 300;

        // Rotation angle (in degrees)
        float rotationAngle = 45f;

        // Desired size after resizing
        int newWidth = 200;
        int newHeight = 150;

        // Load the image as a raster image, apply operations, and save
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Ensure image data is cached for performance
            if (!image.IsCached)
                image.CacheData();

            // Crop the image
            image.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));

            // Rotate the image around its center, expanding canvas and filling background with white
            image.Rotate(rotationAngle, true, Color.White);

            // Resize the image
            image.Resize(newWidth, newHeight);

            // Save the processed image
            image.Save(outputPath);
        }
    }
}