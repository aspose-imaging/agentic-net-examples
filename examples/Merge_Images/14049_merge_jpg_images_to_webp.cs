using System;
using System.Drawing; // For Point
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class MergeJpgToWebp
{
    static void Main()
    {
        // Paths to the source JPEG images
        string jpgPath1 = @"C:\Images\image1.jpg";
        string jpgPath2 = @"C:\Images\image2.jpg";

        // Path for the resulting merged WebP image
        string outputWebpPath = @"C:\Images\merged.webp";

        // Load the first JPEG image – this will serve as the base canvas
        using (Image baseImage = Image.Load(jpgPath1))
        // Load the second JPEG image – this will be blended onto the base
        using (Image overlayImage = Image.Load(jpgPath2))
        // Create a WebPImage from the base JPEG (preserves dimensions and pixel data)
        using (WebPImage webpImage = new WebPImage((RasterImage)baseImage))
        {
            // Define the position where the overlay image will be placed.
            // Here we place it at (0,0) to completely cover the base image.
            // Adjust the Point as needed for side‑by‑side or other layouts.
            Point overlayPosition = new Point(0, 0);

            // Blend the overlay image onto the WebP canvas.
            // The third parameter is the opacity (0‑255). 255 = fully opaque.
            webpImage.Blend(overlayPosition, (RasterImage)overlayImage, 255);

            // Save the merged result as a WebP file.
            // WebPOptions can be customized (quality, lossless, etc.) if required.
            WebPOptions webpOptions = new WebPOptions();
            webpImage.Save(outputWebpPath, webpOptions);
        }
    }
}