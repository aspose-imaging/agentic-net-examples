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
        // Define output file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.tif");

        // Configure TIFF options with LZW compression and metadata
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Artist = "John Doe";
        tiffOptions.ImageDescription = "Sample TIFF image created with Aspose.Imaging";

        // Create a TIFF frame (200x200 pixels)
        TiffFrame frame = new TiffFrame(tiffOptions, 200, 200);

        // Fill the frame with a blue‑yellow gradient
        LinearGradientBrush gradientBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(frame.Width, frame.Height),
            Color.Blue,
            Color.Yellow);

        Graphics graphics = new Graphics(frame);
        graphics.FillRectangle(gradientBrush, frame.Bounds);

        // Create the TIFF image from the frame and save it
        using (TiffImage tiffImage = new TiffImage(frame))
        {
            tiffImage.Save(outputPath);
        }
    }
}