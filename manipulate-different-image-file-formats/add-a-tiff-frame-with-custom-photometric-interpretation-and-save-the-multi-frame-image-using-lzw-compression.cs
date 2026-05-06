using System;
using System.IO;
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
            // Output file path (hard‑coded)
            string outputPath = "output\\multi_frame.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // ----- First frame (RGB photometric) -----
            TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
            options1.BitsPerSample = new ushort[] { 8, 8, 8 };
            options1.ByteOrder = TiffByteOrder.BigEndian;
            options1.Compression = TiffCompressions.Lzw;
            options1.Photometric = TiffPhotometrics.Rgb;
            options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame1 = new TiffFrame(options1, 100, 100);

            // Fill first frame with a blue‑yellow gradient
            LinearGradientBrush brush1 = new LinearGradientBrush(
                new Aspose.Imaging.Point(0, 0),
                new Aspose.Imaging.Point(frame1.Width, frame1.Height),
                Aspose.Imaging.Color.Blue,
                Aspose.Imaging.Color.Yellow);
            Aspose.Imaging.Graphics graphics1 = new Aspose.Imaging.Graphics(frame1);
            graphics1.FillRectangle(brush1, frame1.Bounds);

            // ----- Second frame (custom photometric: MinIsBlack) -----
            TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
            options2.BitsPerSample = new ushort[] { 8 };
            options2.ByteOrder = TiffByteOrder.BigEndian;
            options2.Compression = TiffCompressions.Lzw;
            options2.Photometric = TiffPhotometrics.MinIsBlack; // custom photometric
            options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame2 = new TiffFrame(options2, 100, 100);

            // Fill second frame with a red‑green gradient
            LinearGradientBrush brush2 = new LinearGradientBrush(
                new Aspose.Imaging.Point(0, 0),
                new Aspose.Imaging.Point(frame2.Width, frame2.Height),
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green);
            Aspose.Imaging.Graphics graphics2 = new Aspose.Imaging.Graphics(frame2);
            graphics2.FillRectangle(brush2, frame2.Bounds);

            // Create a multi‑frame TIFF image and add the second frame
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