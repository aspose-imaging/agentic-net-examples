using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Destination folder
        string dir = @"C:\temp\";

        // Create a simple BMP image (100x100) to be saved as TIFF
        using (Image bmp = new Aspose.Imaging.FileFormats.Bmp.BmpImage(100, 100))
        {
            // Fill the image with a blue‑yellow linear gradient
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(bmp.Width, bmp.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics = new Graphics(bmp);
            graphics.FillRectangle(gradientBrush, bmp.Bounds);

            // Configure TIFF save options with desired encoding/compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };               // 8 bits per color component
            tiffOptions.ByteOrder = TiffByteOrder.BigEndian;                  // Motorola byte order
            tiffOptions.Compression = TiffCompressions.Lzw;                   // LZW compression
            tiffOptions.Photometric = TiffPhotometrics.Rgb;                   // RGB color model
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous; // Single plane storage
            tiffOptions.Predictor = TiffPredictor.Horizontal;                // Predictor for LZW

            // Save the image as a TIFF file using the configured options
            bmp.Save(dir + "output.tif", tiffOptions);
        }
    }
}