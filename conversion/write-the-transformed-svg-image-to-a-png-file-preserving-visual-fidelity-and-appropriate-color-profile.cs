using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class SvgToPngConverter
{
    static void Main()
    {
        // Input SVG file path
        string inputSvgPath = @"C:\Images\input.svg";

        // Output PNG file path
        string outputPngPath = @"C:\Images\output.png";

        // Open the SVG file as a stream and load it into a SvgImage instance
        using (Stream svgStream = File.OpenRead(inputSvgPath))
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Configure rasterization options – these control how the vector SVG is rasterized
            var rasterOptions = new SvgRasterizationOptions
            {
                // Preserve the original SVG dimensions
                PageSize = svgImage.Size,

                // Optional: set a white background to avoid transparency issues
                BackgroundColor = Color.White,

                // Preserve visual fidelity
                SmoothingMode = SmoothingMode.None,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Configure PNG save options
            var pngOptions = new PngOptions
            {
                // Attach the rasterization options so the SVG is rendered to raster before saving
                VectorRasterizationOptions = rasterOptions,

                // Preserve full color depth and alpha channel
                ColorType = PngColorType.TruecolorWithAlpha,
                BitDepth = 8,

                // Use maximum compression while keeping progressive loading
                CompressionLevel = 9,
                Progressive = true
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPngPath, pngOptions);
        }
    }
}