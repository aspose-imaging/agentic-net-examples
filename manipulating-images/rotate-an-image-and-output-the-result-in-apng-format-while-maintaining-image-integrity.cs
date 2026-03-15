using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "rotated_output.png";

        // Rotation angle in degrees
        float angle = 45f;

        // Load the image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Ensure image data is cached for better performance
            if (!image.IsCached)
                image.CacheData();

            // Rotate the image around its center, resize canvas proportionally, and fill background with white
            image.Rotate(angle, true, Color.White);

            // Save the rotated image as an APNG file
            image.Save(outputPath, new ApngOptions());
        }
    }
}