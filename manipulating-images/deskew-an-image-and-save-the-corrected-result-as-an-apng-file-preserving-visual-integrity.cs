using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png; // for Color definition

class DeskewToApng
{
    static void Main()
    {
        // Paths to the source (skewed) image and the destination APNG file
        string inputFilePath = @"C:\Images\skewed.png";
        string outputFilePath = @"C:\Images\deskewed.apng";

        // Load the image as a RasterImage (required for NormalizeAngle)
        using (RasterImage image = (RasterImage)Image.Load(inputFilePath))
        {
            // Deskew the image.
            // resizeProportionally = false (keep original canvas size)
            // backgroundColor = LightGray (fills empty areas after rotation)
            image.NormalizeAngle(false, Color.LightGray);

            // Save the corrected image as an APNG.
            // ApngOptions tells Aspose.Imaging to use the APNG format.
            var apngOptions = new ApngOptions();
            image.Save(outputFilePath, apngOptions);
        }
    }
}