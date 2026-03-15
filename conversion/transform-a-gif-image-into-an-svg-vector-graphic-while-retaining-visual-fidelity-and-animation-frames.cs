using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class GifToSvgConverter
{
    static void Main()
    {
        // Path to the source GIF file
        string gifPath = @"C:\Images\animation.gif";

        // Desired output SVG file path
        string svgPath = @"C:\Images\animation_converted.svg";

        // Load the GIF image (multi‑frame raster image)
        using (Image gifImage = Image.Load(gifPath))
        {
            // Prepare vector rasterization options – this tells Aspose.Imaging how to handle each frame
            // when converting to SVG. The PageSize is set to the original image size to preserve fidelity.
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = gifImage.Size,
                // Preserve each frame as a separate <image> element inside the SVG animation.
                // The default settings already keep the original colors and dimensions.
            };

            // Create SVG save options and attach the rasterization options.
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Enable compression if you want a smaller SVGZ file (optional)
                // Compress = true
            };

            // Save the GIF as an SVG file. Aspose.Imaging will generate an SVG that contains
            // the raster frames, preserving the animation timing.
            gifImage.Save(svgPath, svgOptions);
        }

        Console.WriteLine("GIF has been converted to SVG successfully.");
    }
}