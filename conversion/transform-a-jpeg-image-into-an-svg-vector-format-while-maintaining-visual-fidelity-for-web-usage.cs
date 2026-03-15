using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpegToSvgConverter
{
    static void Main()
    {
        // Path to the source JPEG image
        string jpegPath = @"C:\Images\source.jpg";

        // Desired output SVG file path
        string svgPath = @"C:\Images\converted.svg";

        // Load the JPEG image using Aspose.Imaging's Load method
        using (Image image = Image.Load(jpegPath))
        {
            // Configure rasterization options: set the page size to match the original image dimensions
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Create SVG save options, assign rasterization options, and disable compression for plain SVG
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Compress = false // set true if you need compressed SVGZ output
            };

            // Save the image as SVG using the configured options
            image.Save(svgPath, svgOptions);
        }
    }
}