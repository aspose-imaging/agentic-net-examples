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
        string outputPath = "output.tif";

        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.ByteOrder = TiffByteOrder.BigEndian;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Artist = "Aspose.Imaging Example";
        tiffOptions.ImageDescription = "Sample TIFF image with LZW compression";
        tiffOptions.DateTime = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");

        int width = 200;
        int height = 200;
        TiffFrame frame = new TiffFrame(tiffOptions, width, height);

        LinearGradientBrush brush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(frame.Width, frame.Height),
            Color.Blue,
            Color.Yellow);

        Graphics graphics = new Graphics(frame);
        graphics.FillRectangle(brush, frame.Bounds);

        using (TiffImage tiffImage = new TiffImage(frame))
        {
            tiffImage.Save(outputPath);
        }
    }
}