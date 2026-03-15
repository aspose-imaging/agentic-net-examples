using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input APNG file path
        string inputPath = "input.apng";
        // Output APNG file path
        string outputPath = "blended_output.apng";

        // Desired blend color (e.g., semi‑transparent red)
        Aspose.Imaging.Color blendColor = Aspose.Imaging.Color.FromArgb(128, 255, 0, 0);
        // Opacity of the overlay (0‑255)
        byte opacity = 128; // 50% opacity

        // Load the source APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Create an overlay raster image of the same size filled with the blend color
            PngOptions overlayOptions = new PngOptions();
            using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, apng.Width, apng.Height))
            {
                // Fill the overlay with the chosen color
                Graphics graphics = new Graphics(overlay);
                graphics.Clear(blendColor);

                // Prepare blending filter options
                ImageBlendingFilterOptions blendOptions = new ImageBlendingFilterOptions
                {
                    Image = overlay,
                    Opacity = opacity,
                    Position = new Point(0, 0)
                };

                // Apply the blending filter to the entire APNG image
                apng.Filter(apng.Bounds, blendOptions);
            }

            // Save the blended APNG image
            apng.Save(outputPath, new ApngOptions());
        }
    }
}