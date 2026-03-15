using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        // Output JPEG file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.jpg";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG export options with rasterization settings
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90, // Desired JPEG quality (0-100)
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                }
            };

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}