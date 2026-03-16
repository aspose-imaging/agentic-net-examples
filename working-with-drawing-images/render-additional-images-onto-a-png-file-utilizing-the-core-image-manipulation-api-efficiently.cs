using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the base image, overlay images and the output PNG
        string baseImagePath = "base.png";
        string[] overlayPaths = { "overlay1.png", "overlay2.png" };
        string outputPath = "output.png";

        // Load the base image
        using (RasterImage baseImage = (RasterImage)Image.Load(baseImagePath))
        {
            // Prepare PNG options with a file create source (output is bound)
            Source fileSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = fileSource };

            // Create a canvas with the same dimensions as the base image
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, baseImage.Width, baseImage.Height))
            {
                // Copy the base image onto the canvas
                canvas.SaveArgb32Pixels(
                    new Rectangle(0, 0, baseImage.Width, baseImage.Height),
                    baseImage.LoadArgb32Pixels(baseImage.Bounds));

                // Draw each overlay image onto the canvas at a fixed offset (e.g., 50,50)
                foreach (string overlayPath in overlayPaths)
                {
                    using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                    {
                        // Destination rectangle where the overlay will be placed
                        Rectangle destRect = new Rectangle(50, 50, overlay.Width, overlay.Height);

                        // Load overlay pixels and paste them onto the canvas
                        canvas.SaveArgb32Pixels(destRect, overlay.LoadArgb32Pixels(overlay.Bounds));
                    }
                }

                // Save the final merged PNG (output is already bound to the source)
                canvas.Save();
            }
        }
    }
}