using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // for creating a blank raster image if needed

class AlphaBlendExample
{
    static void Main()
    {
        // Paths to the source image and the result image
        string sourcePath = "input.jpg";
        string resultPath = "output.jpg";

        // Load the source image (any supported format)
        using (RasterImage sourceImage = (RasterImage)Image.Load(sourcePath))
        {
            // Create an overlay image of the same size and pixel format
            using (RasterImage overlay = new RasterImage(sourceImage.Width, sourceImage.Height, sourceImage.PixelFormat))
            {
                // Fill the overlay with a solid color (e.g., semi‑transparent red)
                // Since Aspose.Imaging does not provide a direct Fill method, set each pixel manually
                Color overlayColor = Color.FromArgb(255, 255, 0, 0); // opaque red
                for (int y = 0; y < overlay.Height; y++)
                {
                    for (int x = 0; x < overlay.Width; x++)
                    {
                        overlay.SetPixel(x, y, overlayColor);
                    }
                }

                // Apply alpha blending: blend the overlay onto the source image.
                // The third parameter is the alpha value (0‑255). 128 gives 50 % opacity.
                sourceImage.Blend(new Point(0, 0), overlay, 128);
            }

            // Save the blended image to the desired location
            sourceImage.Save(resultPath);
        }
    }
}