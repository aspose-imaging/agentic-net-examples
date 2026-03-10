using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path and output PNG file path
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage for vector-specific properties
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = svgImage.Size;                     // Preserve original size
            rasterOptions.BackgroundColor = Color.White;               // Set background color
            rasterOptions.SmoothingMode = SmoothingMode.AntiAlias;     // Enable antialiasing
            rasterOptions.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Configure PNG export options with 300 DPI resolution
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;
            pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);

            // Save the rasterized PNG image
            svgImage.Save(outputPath, pngOptions);
        }
    }
}