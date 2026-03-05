using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the source raster image
        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            // Create APNG options with bound output file
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG canvas
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, source.Width, source.Height))
            {
                // Remove the default frame that exists by default
                apng.RemoveAllFrames();

                // Add the source image as the first frame
                apng.AddFrame(source);

                // Create an overlay raster image of the same size
                using (RasterImage overlay = (RasterImage)Image.Create(new PngOptions(), source.Width, source.Height))
                {
                    // Fill the overlay with the desired blending color (e.g., semi‑transparent red)
                    Graphics graphics = new Graphics(overlay);
                    graphics.Clear(Color.FromArgb(255, 255, 0, 0)); // opaque red

                    // Blend the overlay onto the APNG with 50% opacity (128 out of 255)
                    apng.Blend(new Point(0, 0), overlay, 128);
                }

                // Save the APNG (bound to the FileCreateSource)
                apng.Save();
            }
        }
    }
}