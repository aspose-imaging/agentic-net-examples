using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

namespace SvgToPngConversion
{
    class Program
    {
        static void Main()
        {
            // Input SVG file path
            string inputSvgPath = @"C:\Temp\input.svg";

            // Output PNG file path
            string outputPngPath = @"C:\Temp\output.png";

            // Load the SVG image using the generic Image.Load method
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                // Prepare rasterization options required for vector to raster conversion
                // The default options are obtained via GetDefaultOptions, providing background color,
                // and the desired width and height (same as source to preserve fidelity).
                var rasterizationOptions = (SvgRasterizationOptions)svgImage.GetDefaultOptions(
                    new object[] { Color.White, svgImage.Width, svgImage.Height });

                // Optionally fine‑tune rendering quality (e.g., anti‑aliasing, smoothing)
                rasterizationOptions.TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias;
                rasterizationOptions.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                // Configure PNG save options and attach the rasterization options
                var pngSaveOptions = new PngOptions
                {
                    // Preserve original resolution if needed
                    ResolutionSettings = new ResolutionSetting(svgImage.Width, svgImage.Height),

                    // Use truecolor with alpha for full color fidelity
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,

                    // Enable progressive loading (optional)
                    Progressive = true,

                    // Attach vector rasterization options so the SVG is rasterized during save
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as PNG
                svgImage.Save(outputPngPath, pngSaveOptions);
            }

            Console.WriteLine("SVG has been successfully converted to PNG.");
        }
    }
}