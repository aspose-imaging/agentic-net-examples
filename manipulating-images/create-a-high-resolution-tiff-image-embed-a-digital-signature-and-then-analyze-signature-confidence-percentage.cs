using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\Temp\highres.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.ByteOrder = TiffByteOrder.BigEndian;
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            int width = 2000;
            int height = 2000;

            // Create a TIFF frame
            TiffFrame frame = new TiffFrame(tiffOptions, width, height);

            // Fill frame with gradient
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame.Width, frame.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics = new Graphics(frame);
            graphics.FillRectangle(gradientBrush, frame.Bounds);

            // Create TIFF image from frame
            using (TiffImage tiffImage = new TiffImage(frame))
            {
                // Embed digital signature
                string password = "secure123";
                tiffImage.ActiveFrame.EmbedDigitalSignature(password);

                // Analyze signature confidence
                double confidence = tiffImage.ActiveFrame.AnalyzePercentageDigitalSignature(password);
                Console.WriteLine($"Signature confidence: {confidence}%");

                // Save the TIFF image
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}