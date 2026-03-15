using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpegToSvgConverter
{
    static void Main()
    {
        // Input JPEG file path
        string inputJpegPath = @"C:\Images\sample.jpg";

        // Output SVG file path
        string outputSvgPath = @"C:\Images\sample_converted.svg";

        // Load the JPEG raster image
        using (Image rasterImage = Image.Load(inputJpegPath))
        {
            // Configure vector rasterization options.
            // PageSize is set to the original image size to preserve visual fidelity.
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = rasterImage.Size
            };

            // Create SVG save options and attach the rasterization settings.
            var svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save the image as SVG. The raster image will be embedded in the SVG,
            // maintaining the original appearance.
            rasterImage.Save(outputSvgPath, svgSaveOptions);
        }
    }
}