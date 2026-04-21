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
            string outputPath = "output.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create a high‑resolution frame (2000x2000)
            int width = 2000;
            int height = 2000;
            TiffFrame frame = new TiffFrame(tiffOptions, width, height);

            // Fill the frame with a blue‑to‑yellow gradient
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(width, height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics = new Graphics(frame);
            graphics.FillRectangle(brush, frame.Bounds);

            // Create TIFF image from the frame
            using (TiffImage tiffImage = new TiffImage(frame))
            {
                // Save the initial image
                tiffImage.Save(outputPath);

                // Embed a digital signature with a valid password
                tiffImage.EmbedDigitalSignature("secure123");

                // Save after embedding the signature
                tiffImage.Save(outputPath);

                // Analyze signature confidence percentage
                double confidence = tiffImage.AnalyzePercentageDigitalSignature("secure123");
                Console.WriteLine($"Signature confidence: {confidence}%");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}