using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class ApplyMotionBlurToWebP
{
    static void Main()
    {
        // Path to the folder containing the source WebP image.
        string dir = @"c:\temp\";

        // Load the WebP image from file.
        using (Image image = Image.Load(dir + "input.webp"))
        {
            // Cast the generic Image to a WebPImage to access WebP‑specific members.
            WebPImage webpImage = (WebPImage)image;

            // Apply a motion blur (motion Wiener) filter to the whole image.
            // Parameters: length = 10, smooth = 1.0, angle = 45 degrees.
            webpImage.Filter(
                webpImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 45.0));

            // Save the processed image back to WebP format.
            webpImage.Save(dir + "output.webp", new WebPOptions());
        }
    }
}