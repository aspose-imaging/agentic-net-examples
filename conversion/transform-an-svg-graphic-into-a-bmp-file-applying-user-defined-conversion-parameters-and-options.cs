using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = @"C:\temp\input.svg";
        // Output BMP file path
        string outputPath = @"C:\temp\output.bmp";

        // User-defined conversion parameters
        int bitsPerPixel = 24; // 24-bit color depth
        BitmapCompression compression = BitmapCompression.Rgb; // No compression
        float scaleFactor = 0.5f; // Reduce size to 50%
        Color backgroundColor = Color.White;

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare BMP save options
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.BitsPerPixel = bitsPerPixel;
                bmpOptions.Compression = compression;
                bmpOptions.ResolutionSettings = new ResolutionSetting(96.0, 96.0);

                // Create SVG rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.BackgroundColor = backgroundColor;
                rasterOptions.PageWidth = (int)(image.Width * scaleFactor);
                rasterOptions.PageHeight = (int)(image.Height * scaleFactor);
                rasterOptions.SmoothingMode = SmoothingMode.None;
                rasterOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

                // Assign rasterization options to BMP options
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized BMP image
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}