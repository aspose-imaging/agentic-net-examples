using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Input APNG file path
        string inputPath = "input.apng";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the APNG image as a raster image (first frame)
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using Magic Wand at point (100, 50) and apply it to the image
            MagicWandTool
                .Select(image, new MagicWandSettings(100, 50))
                .Apply();

            // Save the processed image as APNG
            image.Save(outputPath, new ApngOptions());
        }
    }
}