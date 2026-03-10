using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image and output APNG path
        string inputPath = "input.png";
        string outputPath = "output_apng.png";

        // Load the source raster image
        using (Aspose.Imaging.RasterImage source = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Set up APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas
            using (ApngImage apng = (ApngImage)Aspose.Imaging.Image.Create(apngOptions, source.Width, source.Height))
            {
                // Remove the default empty frame
                apng.RemoveAllFrames();

                // Add the source image as the first frame
                apng.AddFrame(source);

                // Create a solid color overlay image (same size as source)
                PngOptions overlayOpts = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (Aspose.Imaging.RasterImage colorOverlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(overlayOpts, source.Width, source.Height))
                {
                    // Fill the overlay with the desired color (e.g., semi‑transparent red)
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(colorOverlay);
                    graphics.Clear(Aspose.Imaging.Color.FromArgb(255, 255, 0, 0)); // opaque red

                    // Configure blending filter options
                    ImageBlendingFilterOptions blendOptions = new ImageBlendingFilterOptions
                    {
                        Image = colorOverlay,
                        Opacity = 128, // 0‑255 (50% opacity)
                        Position = new Aspose.Imaging.Point(0, 0)
                    };

                    // Apply the blending filter to the entire APNG canvas
                    apng.Filter(apng.Bounds, blendOptions);
                }

                // Save the APNG file (output path already bound via FileCreateSource)
                apng.Save();
            }
        }
    }
}