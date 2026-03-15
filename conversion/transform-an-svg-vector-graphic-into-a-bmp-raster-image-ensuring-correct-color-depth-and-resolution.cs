using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Output BMP file path
        string outputPath = "output.bmp";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = image.Size;               // Preserve original dimensions
            rasterOptions.BackgroundColor = Color.White;       // Set background color

            // Configure BMP output options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;                      // 24‑bit color depth
            bmpOptions.VectorRasterizationOptions = rasterOptions;
            bmpOptions.ResolutionSettings = new ResolutionSetting(300, 300); // Desired DPI

            // Save the rasterized image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}