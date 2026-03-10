using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input image paths
        string backgroundPath = "background.jpg";
        string overlayPath = "overlay.png";
        string outputPath = "blended.png";

        // Load background and overlay images as RasterImage
        using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
        using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
        {
            // Blend overlay onto background at (0,0) with 50% opacity
            background.Blend(new Point(0, 0), overlay, 128);
        }

        // Save the blended image as PNG
        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions { Source = outputSource };
        using (RasterImage result = (RasterImage)Image.Load(backgroundPath)) // reload to apply saved changes
        {
            result.Save(outputPath, pngOptions);
        }
    }
}