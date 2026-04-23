using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "rotated.tif");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
            {
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(tiffImage.Width, tiffImage.Height),
                    Color.Red,
                    Color.Blue);

                Graphics graphics = new Graphics(tiffImage);
                graphics.FillRectangle(brush, tiffImage.Bounds);

                tiffImage.EmbedDigitalSignature("secure123");
                tiffImage.Rotate(45f, true, Color.Gray);
                tiffImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}