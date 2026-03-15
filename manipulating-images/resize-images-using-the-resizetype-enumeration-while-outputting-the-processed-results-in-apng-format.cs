using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class ResizeToApng
{
    static void Main()
    {
        // Input image path (any supported format)
        string inputPath = @"C:\Images\sample.png";

        // Output APNG image path
        string outputPath = @"C:\Images\sample_resized.apng";

        // Desired dimensions
        int newWidth = 800;
        int newHeight = 600;

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Resize the image using a specific ResizeType (e.g., BilinearResample)
            image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Prepare APNG save options
            var apngOptions = new ApngOptions();

            // Save the resized image in APNG format
            image.Save(outputPath, apngOptions);
        }
    }
}