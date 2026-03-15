using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png; // Required for APNG support

class BradleyThresholdToApng
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string inputPath = @"C:\Images\source.png";

        // Desired output path for the APNG file
        string outputPath = @"C:\Images\result.apng";

        // Load the image using Aspose.Imaging's Load method (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the BinarizeBradley method
            RasterImage rasterImage = (RasterImage)image;

            // Apply Bradley's adaptive thresholding
            // brightnessDifference: 5 (pixel vs. local average)
            // windowSize: 10 (10x10 pixel neighborhood)
            rasterImage.BinarizeBradley(5, 10);

            // Prepare APNG saving options (preserves visual fidelity)
            ApngOptions apngOptions = new ApngOptions();

            // Save the binarized image as an APNG file (save rule)
            rasterImage.Save(outputPath, apngOptions);
        }
    }
}