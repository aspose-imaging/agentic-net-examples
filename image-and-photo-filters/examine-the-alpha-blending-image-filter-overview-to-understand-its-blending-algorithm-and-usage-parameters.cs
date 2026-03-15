using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the background and overlay images.
        string backgroundPath = "background.jpg";
        string overlayPath = "overlay.png";
        string outputPath = "blended_output.jpg";

        // Load the background image as a raster image.
        using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
        {
            // Load the overlay image as a raster image.
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Define the position where the overlay will be placed on the background.
                // Aspose.Imaging.Point represents the top‑left corner of the overlay.
                Aspose.Imaging.Point origin = new Aspose.Imaging.Point(50, 30);

                // Define the opacity of the overlay (0‑255). 128 means 50% transparency.
                byte overlayOpacity = 128;

                // Blend the overlay onto the background using the specified origin and opacity.
                // The Blend method performs per‑pixel alpha compositing.
                background.Blend(origin, overlay, overlayOpacity);
            }

            // Prepare JPEG save options with a file source bound to the output path.
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };

            // Save the blended image. Since the image was not created with a bound source,
            // we use the Save method that accepts the output path and options.
            background.Save(outputPath, jpegOptions);
        }
    }
}