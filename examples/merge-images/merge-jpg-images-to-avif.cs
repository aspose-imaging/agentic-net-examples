using System;
using System.Drawing;                     // For Point
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Avif;    // AvifImage class

class Program
{
    static void Main()
    {
        // Paths to source JPEG images
        string jpgPath1 = "image1.jpg";
        string jpgPath2 = "image2.jpg";

        // Load the first JPEG – this will be the base canvas
        using (RasterImage baseImage = (RasterImage)Image.Load(jpgPath1))
        // Load the second JPEG – this will be blended onto the base
        using (RasterImage overlayImage = (RasterImage)Image.Load(jpgPath2))
        {
            // Ensure both images have the same height for a side‑by‑side merge.
            // If they differ, resize the overlay to match the base height.
            if (overlayImage.Height != baseImage.Height)
            {
                overlayImage.Resize(baseImage.Width, baseImage.Height);
            }

            // Create a new empty AVIF image with the combined width.
            // The height is the maximum of the two images.
            int mergedWidth = baseImage.Width + overlayImage.Width;
            int mergedHeight = Math.Max(baseImage.Height, overlayImage.Height);

            // Initialize an AVIF image with the required dimensions.
            // The constructor creates an empty raster image; we then set its size
            // by creating a blank bitmap and drawing the base image onto it.
            using (AvifImage avifImage = new AvifImage())
            {
                // Create a temporary blank raster image to serve as the canvas.
                using (RasterImage canvas = (RasterImage)Image.Create(avifImage, mergedWidth, mergedHeight, Color.White))
                {
                    // Copy the base image onto the left side of the canvas.
                    canvas.Blend(new Point(0, 0), baseImage, 255); // 255 = fully opaque

                    // Blend the overlay image onto the right side of the canvas.
                    canvas.Blend(new Point(baseImage.Width, 0), overlayImage, 255);

                    // Save the canvas as AVIF using appropriate options.
                    var avifOptions = new AvifOptions
                    {
                        // Example: set quality (0‑100). Adjust as needed.
                        Quality = 90
                    };

                    // The canvas is a RasterImage; we can cast it to AvifImage by saving directly.
                    canvas.Save("merged.avif", avifOptions);
                }
            }
        }
    }
}