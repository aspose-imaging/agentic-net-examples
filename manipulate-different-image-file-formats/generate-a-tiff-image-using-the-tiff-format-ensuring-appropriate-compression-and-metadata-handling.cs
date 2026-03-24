using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = @"C:\temp\output.tif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure TIFF options with compression and metadata
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Artist = "John Doe";
        tiffOptions.ImageDescription = "Sample TIFF image with gradient";

        // Create a TIFF frame
        TiffFrame frame = new TiffFrame(tiffOptions, 200, 200);

        // Draw a blue‑yellow gradient on the frame
        Graphics graphics = new Graphics(frame);
        LinearGradientBrush gradientBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(frame.Width, frame.Height),
            Color.Blue,
            Color.Yellow);
        graphics.FillRectangle(gradientBrush, frame.Bounds);

        // Create the TIFF image and save it
        using (TiffImage tiffImage = new TiffImage(frame))
        {
            tiffImage.Save(outputPath);
        }
    }
}