using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;

class BigTiffProcessor
{
    static void Main()
    {
        // Paths for source BIGTIFF and destination PNG
        string sourcePath = "source_big.tif";
        string destinationPath = "processed_image.png";

        // Load the BIGTIFF image (lifecycle: load)
        using (BigTiffImage bigTiff = (BigTiffImage)Image.Load(sourcePath))
        {
            // Example edit: increase brightness by 20 units
            bigTiff.AdjustBrightness(20);

            // Example edit: rotate the image 90 degrees clockwise
            bigTiff.Rotate(90);

            // Example edit: resize to 50% of original dimensions
            int newWidth = bigTiff.Width / 2;
            int newHeight = bigTiff.Height / 2;
            bigTiff.Resize(newWidth, newHeight);

            // Convert and save to PNG format (lifecycle: save)
            var pngOptions = new PngOptions();
            bigTiff.Save(destinationPath, pngOptions);
        }
    }
}