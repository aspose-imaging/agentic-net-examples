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
        try
        {
            string outputPath = "output_multi.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // First frame with default LZW compression
            TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
            options1.BitsPerSample = new ushort[] { 8, 8, 8 };
            options1.Compression = TiffCompressions.Lzw;
            options1.Photometric = TiffPhotometrics.Rgb;
            options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame1 = new TiffFrame(options1, 200, 200);
            LinearGradientBrush brush1 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame1.Width, frame1.Height),
                Color.Blue,
                Color.Yellow);
            Graphics graphics1 = new Graphics(frame1);
            graphics1.FillRectangle(brush1, frame1.Bounds);

            // Second frame with Deflate compression
            TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
            options2.BitsPerSample = new ushort[] { 8, 8, 8 };
            options2.Compression = TiffCompressions.Deflate;
            options2.Photometric = TiffPhotometrics.Rgb;
            options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame2 = new TiffFrame(options2, 200, 200);
            LinearGradientBrush brush2 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame2.Width, frame2.Height),
                Color.Green,
                Color.Red);
            Graphics graphics2 = new Graphics(frame2);
            graphics2.FillRectangle(brush2, frame2.Bounds);

            // Create a multi‑frame TIFF image and save it
            using (TiffImage tiffImage = new TiffImage(new TiffFrame[] { frame1, frame2 }))
            {
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}