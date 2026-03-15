using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Path to the source vector graphic (e.g., SVG, EMF, WMF)
        string inputPath = @"C:\Images\source.svg";

        // Desired output path for the fully‑transparent APNG
        string outputPath = @"C:\Images\result.apng";

        // Load the vector image using Aspose.Imaging's generic loader
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the loaded image is a vector type
            if (image is VectorImage vectorImage)
            {
                // Remove the background – this makes the background transparent
                vectorImage.RemoveBackground();

                // Configure rasterization options for converting the vector to raster
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Keep the original dimensions of the vector image
                    PageSize = image.Size,

                    // Explicitly set a transparent background for the rasterized result
                    BackgroundColor = Color.Transparent
                };

                // Set up APNG save options, linking the rasterization options
                var apngOptions = new ApngOptions
                {
                    // Use the rasterization settings defined above
                    VectorRasterizationOptions = rasterOptions,

                    // Preserve the alpha channel (required for transparency)
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save the processed image as a transparent APNG file
                image.Save(outputPath, apngOptions);
            }
            else
            {
                throw new InvalidOperationException("The loaded file is not a supported vector image.");
            }
        }
    }
}