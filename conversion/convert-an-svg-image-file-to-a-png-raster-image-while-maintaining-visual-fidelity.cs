using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class SvgToPngConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Images\source.svg";

        // Desired path for the output PNG file
        string outputPngPath = @"C:\Images\converted.png";

        // Load the SVG image using Aspose.Imaging's unified loader
        using (SvgImage svgImage = (SvgImage)Image.Load(inputSvgPath))
        {
            // Configure rasterization options – these control how the vector SVG is rasterized
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Use the original SVG size for the rasterized image
                PageSize = svgImage.Size,

                // Optional: improve visual fidelity
                // BackgroundColor = Color.White,
                // SmoothingMode = SmoothingMode.AntiAlias,
                // TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Set up PNG save options and attach the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPngPath, pngOptions);
        }
    }
}