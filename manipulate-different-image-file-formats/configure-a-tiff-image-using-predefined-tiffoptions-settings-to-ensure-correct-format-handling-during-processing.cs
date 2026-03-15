using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.tif";

        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        using (Image image = Image.Create(tiffOptions, 200, 200))
        {
            var gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(image.Width, image.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics = new Graphics(image);
            graphics.FillRectangle(gradientBrush, image.Bounds);

            image.Save(outputPath, tiffOptions);
        }
    }
}