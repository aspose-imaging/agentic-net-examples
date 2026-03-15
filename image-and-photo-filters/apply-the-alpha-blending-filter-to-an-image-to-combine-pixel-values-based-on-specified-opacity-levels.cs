using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the background, overlay, and output images
        string backgroundPath = "background.png";
        string overlayPath = "overlay.png";
        string outputPath = "blended.png";

        // Load background and overlay images as RasterImage instances
        using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
        using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
        {
            // Define opacity (0-255). 128 = 50% opacity.
            byte opacity = 128;

            // Blend the overlay onto the background at the top-left corner
            background.Blend(new Point(0, 0), overlay, opacity);

            // Prepare PNG save options with a file source
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions() { Source = outSource };

            // Save the blended image
            background.Save(outputPath, options);
        }
    }
}