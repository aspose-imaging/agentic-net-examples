using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        string outputPath = "output.tif";

        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Predictor = TiffPredictor.Horizontal;
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;
        tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);

        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
        {
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(tiffImage.Width, tiffImage.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics = new Graphics(tiffImage.ActiveFrame);
            graphics.FillRectangle(brush, tiffImage.Bounds);

            tiffImage.Save(outputPath);
        }
    }
}