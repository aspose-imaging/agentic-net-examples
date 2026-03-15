using System;
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

        // Configure TIFF options with LZW compression and RGB photometric
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // Create a TIFF frame (200x200) using the configured options
        TiffFrame frame = new TiffFrame(tiffOptions, 200, 200);

        // Fill the frame with a blue‑yellow linear gradient
        LinearGradientBrush brush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(frame.Width, frame.Height),
            Color.Blue,
            Color.Yellow);

        Graphics graphics = new Graphics(frame);
        graphics.FillRectangle(brush, frame.Bounds);

        // Create a TIFF image from the frame and save it
        using (TiffImage tiffImage = new TiffImage(frame))
        {
            tiffImage.Save(outputPath);
        }
    }
}