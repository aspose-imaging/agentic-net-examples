using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the source AVIF image, the SVG vector graphic, and the output raster image.
        string avifPath = "input.avif";
        string svgPath = "input.svg";
        string outputPath = "output.png";

        // Load the AVIF image to obtain its dimensions.
        using (Image avifImage = Image.Load(avifPath))
        {
            // Retrieve the size (width and height) of the AVIF image.
            var size = avifImage.Size;

            // Load the SVG image from a file stream.
            using (Stream svgStream = File.OpenRead(svgPath))
            using (Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = new Aspose.Imaging.FileFormats.Svg.SvgImage(svgStream))
            {
                // Configure rasterization options to match the AVIF image size.
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = size,
                    // Optional: set background color, smoothing, etc., if needed.
                    // BackgroundColor = Aspose.Imaging.Color.White,
                    // SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    // TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
                };

                // Set PNG save options and attach the rasterization options.
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize the SVG and save it as a PNG image.
                svgImage.Save(outputPath, pngOptions);
            }
        }
    }
}