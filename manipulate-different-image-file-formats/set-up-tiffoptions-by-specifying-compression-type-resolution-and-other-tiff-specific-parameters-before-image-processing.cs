using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.tif";

        // Configure TIFF options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };                     // 8 bits per channel
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;                     // Intel byte order
        tiffOptions.Compression = TiffCompressions.Lzw;                         // LZW compression
        tiffOptions.Photometric = TiffPhotometrics.Rgb;                         // RGB color model
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;        // Single plane
        tiffOptions.Predictor = TiffPredictor.Horizontal;                      // Predictor for LZW

        // Create a new TIFF image with the specified options
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
        {
            // Set resolution (DPI)
            tiffImage.HorizontalResolution = 300;
            tiffImage.VerticalResolution = 300;

            // Create a linear gradient brush
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(tiffImage.Width, tiffImage.Height),
                Color.Blue,
                Color.Yellow);

            // Draw the gradient onto the image
            Graphics graphics = new Graphics(tiffImage);
            graphics.FillRectangle(gradientBrush, tiffImage.Bounds);

            // Save the TIFF image to disk
            tiffImage.Save(outputPath);
        }
    }
}