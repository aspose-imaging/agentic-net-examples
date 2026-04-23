using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "C:\\temp\\multiframe.tif";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Options for the first frame
            TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
            options1.BitsPerSample = new ushort[] { 8, 8, 8 };
            options1.Compression = TiffCompressions.Lzw;
            options1.Photometric = TiffPhotometrics.Rgb;
            options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create TIFF image with first frame
            using (TiffImage tiffImage = (TiffImage)Image.Create(options1, 200, 200))
            {
                // Draw gradient on first frame
                Graphics graphics1 = new Graphics(tiffImage);
                using (LinearGradientBrush brush1 = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(200, 200),
                    Color.Blue,
                    Color.Yellow))
                {
                    graphics1.FillRectangle(brush1, tiffImage.ActiveFrame.Bounds);
                }

                // Options for the second frame
                TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
                options2.BitsPerSample = new ushort[] { 8, 8, 8 };
                options2.Compression = TiffCompressions.Deflate;
                options2.Photometric = TiffPhotometrics.Rgb;
                options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Create second frame and add to image
                TiffFrame frame2 = new TiffFrame(options2, 200, 200);
                tiffImage.AddFrame(frame2);
                tiffImage.ActiveFrame = frame2;

                // Draw gradient on second frame
                Graphics graphics2 = new Graphics(tiffImage);
                using (LinearGradientBrush brush2 = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(200, 200),
                    Color.Red,
                    Color.Green))
                {
                    graphics2.FillRectangle(brush2, tiffImage.ActiveFrame.Bounds);
                }

                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}