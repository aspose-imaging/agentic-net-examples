using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SvgToBmpConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Images\source.svg";

        // Desired output BMP file path
        string outputBmpPath = @"C:\Images\converted.bmp";

        // Load the SVG image using the standard Image.Load method
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Configure rasterization options for the SVG.
            // PageSize is set to the original SVG size to preserve dimensions.
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                // Optional: set background color, smoothing, etc., if needed.
                // BackgroundColor = Color.White,
                // SmoothingMode = SmoothingMode.None,
                // TextRenderingHint = TextRenderingHint.SingleBitPerPixel
            };

            // Configure BMP save options.
            // BitsPerPixel = 24 ensures a true-color BMP (8 bits per channel).
            var bmpSaveOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as BMP using the configured options.
            svgImage.Save(outputBmpPath, bmpSaveOptions);
        }
    }
}