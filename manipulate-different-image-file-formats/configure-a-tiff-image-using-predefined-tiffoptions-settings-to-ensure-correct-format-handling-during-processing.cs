using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.tif";

        // Configure TiffOptions with predefined settings
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create a TIFF image canvas
        using (Image image = Image.Create(tiffOptions, 200, 200))
        {
            // Fill the canvas with a linear gradient
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(image.Width, image.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics = new Graphics(image);
            graphics.FillRectangle(brush, image.Bounds);

            // Save the image (output path is already bound)
            image.Save();
        }
    }
}