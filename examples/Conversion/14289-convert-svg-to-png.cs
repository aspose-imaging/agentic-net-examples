using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Temp\input.svg";

        // Desired path for the output PNG file
        string outputPngPath = @"C:\Temp\output.png";

        // Load the SVG image using Aspose.Imaging's unified loader
        using (SvgImage svgImage = (SvgImage)Image.Load(inputSvgPath))
        {
            // Configure rasterization options – these control how the vector SVG is rasterized
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Use the original SVG size for the rasterized image
                PageSize = svgImage.Size,

                // Optional: set a background color (default is white)
                BackgroundColor = Color.White,

                // Optional: enable antialiasing for smoother edges
                SmoothingMode = SmoothingMode.AntiAlias,

                // Optional: improve text rendering quality
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Create PNG save options and attach the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPngPath, pngOptions);
        }
    }
}