using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Define input SVG and output BMP file paths
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        // User-defined conversion parameters
        int bitsPerPixel = 24; // Desired bits per pixel for BMP
        BitmapCompression compression = BitmapCompression.Rgb; // No compression
        double dpiX = 300; // Horizontal resolution
        double dpiY = 300; // Vertical resolution

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure BMP save options
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.BitsPerPixel = bitsPerPixel;
                bmpOptions.Compression = compression;
                bmpOptions.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);

                // Set vector rasterization options for proper SVG rendering
                VectorRasterizationOptions vectorOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                    new object[] { Color.White, image.Width, image.Height });
                vectorOptions.PageSize = image.Size;
                vectorOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                vectorOptions.SmoothingMode = SmoothingMode.None;

                bmpOptions.VectorRasterizationOptions = vectorOptions;

                // Save the rasterized image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}