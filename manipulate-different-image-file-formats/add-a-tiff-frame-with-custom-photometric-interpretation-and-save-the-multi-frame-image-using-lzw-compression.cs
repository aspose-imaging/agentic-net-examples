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
        string outputPath = "C:\\temp\\multipage.tif";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Options for the first frame (RGB photometric)
            TiffOptions frameOptions1 = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions1.Compression = TiffCompressions.Lzw;
            frameOptions1.Photometric = TiffPhotometrics.Rgb;
            frameOptions1.BitsPerSample = new ushort[] { 8, 8, 8 };
            frameOptions1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create first frame
            TiffFrame frame1 = new TiffFrame(frameOptions1, 100, 100);
            Graphics graphics1 = new Graphics(frame1);
            LinearGradientBrush brush1 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame1.Width, frame1.Height),
                Color.Blue,
                Color.Yellow);
            graphics1.FillRectangle(brush1, frame1.Bounds);

            // Options for the second frame (MinIsBlack photometric)
            TiffOptions frameOptions2 = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions2.Compression = TiffCompressions.Lzw;
            frameOptions2.Photometric = TiffPhotometrics.MinIsBlack;
            frameOptions2.BitsPerSample = new ushort[] { 1 };
            frameOptions2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create second frame
            TiffFrame frame2 = new TiffFrame(frameOptions2, 100, 100);
            Graphics graphics2 = new Graphics(frame2);
            LinearGradientBrush brush2 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame2.Width, frame2.Height),
                Color.Black,
                Color.White);
            graphics2.FillRectangle(brush2, frame2.Bounds);

            // Create multi‑frame TIFF image and add the second frame
            using (TiffImage tiffImage = new TiffImage(frame1))
            {
                tiffImage.AddFrame(frame2);
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}