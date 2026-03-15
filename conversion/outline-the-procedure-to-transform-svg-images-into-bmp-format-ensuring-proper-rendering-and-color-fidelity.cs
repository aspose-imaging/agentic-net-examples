using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

namespace SvgToBmpConversion
{
    public static class Converter
    {
        /// <summary>
        /// Converts an SVG file to a BMP file while preserving rendering quality and colors.
        /// </summary>
        /// <param name="svgPath">Full path to the source SVG file.</param>
        /// <param name="bmpPath">Full path where the BMP file will be saved.</param>
        public static void ConvertSvgToBmp(string svgPath, string bmpPath)
        {
            // Load the SVG image using the unified Image.Load method.
            using (Image image = Image.Load(svgPath))
            {
                // Ensure the loaded image is a vector image (SVG is a VectorImage).
                if (image is VectorImage)
                {
                    // Prepare rasterization options for the SVG.
                    // PageSize is set to the original SVG dimensions to keep the aspect ratio.
                    // BackgroundColor can be set to white (or any desired color) to avoid transparency issues.
                    // TextRenderingHint and SmoothingMode are configured for high‑quality rasterization.
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Create BMP save options and attach the rasterization options.
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        // BitsPerPixel = 24 ensures true‑color output (no palette loss).
                        BitsPerPixel = 24,
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the rasterized image as BMP.
                    image.Save(bmpPath, bmpOptions);
                }
                else
                {
                    throw new InvalidOperationException("The loaded file is not a vector image.");
                }
            }
        }

        // Example usage
        public static void Main()
        {
            string inputSvg = @"C:\Images\example.svg";
            string outputBmp = @"C:\Images\example.bmp";

            ConvertSvgToBmp(inputSvg, outputBmp);

            Console.WriteLine("Conversion completed.");
        }
    }
}