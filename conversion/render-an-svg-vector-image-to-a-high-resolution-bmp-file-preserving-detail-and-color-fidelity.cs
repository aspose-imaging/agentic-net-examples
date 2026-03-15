using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path and output BMP file path
        string inputSvgPath = "input.svg";
        string outputBmpPath = "output.bmp";

        // Load the SVG image using the unified Image.Load method
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Configure BMP save options
            BmpOptions bmpOptions = new BmpOptions();

            // Set high resolution (e.g., 300 DPI) to preserve detail
            bmpOptions.ResolutionSettings = new ResolutionSetting(300, 300);

            // Configure vector rasterization options for the SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Preserve original size
                PageSize = svgImage.Size,
                // Optional: increase scale for higher pixel density
                ScaleX = 2.0f,
                ScaleY = 2.0f,
                // High-quality rendering settings
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                BackgroundColor = Color.White
            };

            // Assign rasterization options to BMP options
            bmpOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rendered image as a high‑resolution BMP
            svgImage.Save(outputBmpPath, bmpOptions);
        }
    }
}