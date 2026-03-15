using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the source APNG, overlay image, and output file
        string inputApngPath = "input.apng";
        string overlayImagePath = "overlay.png";
        string outputApngPath = "output.apng";

        // Load the APNG image and the overlay raster image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputApngPath))
        using (RasterImage overlay = (RasterImage)Image.Load(overlayImagePath))
        {
            // Iterate through each frame of the APNG
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Cast the page to ApngFrame to access blending functionality
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];

                // Blend the overlay onto the current frame using 50% opacity (128 out of 255)
                frame.Blend(new Point(0, 0), overlay, 128);
            }

            // Save the modified APNG using default APNG options
            apngImage.Save(outputApngPath, new ApngOptions());
        }
    }
}