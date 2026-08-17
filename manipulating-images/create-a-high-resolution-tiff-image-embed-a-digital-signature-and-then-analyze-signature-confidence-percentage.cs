// HOW-TO: Create High Resolution TIFF with Digital Signature and Confidence Analysis in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options
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

            // Fill the frame with a gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Aspose.Imaging.Point(0, 0),
                new Aspose.Imaging.Point(frame.Width, frame.Height),
                Aspose.Imaging.Color.Blue,
                Aspose.Imaging.Color.Yellow))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(frame);
                graphics.FillRectangle(brush, frame.Bounds);
            }

            // Create the TIFF image
            using (TiffImage tiffImage = new TiffImage(frame))
            {
                // Embed a digital signature
                tiffImage.EmbedDigitalSignature("secure123");

                // Analyze signature confidence
                double confidence = tiffImage.AnalyzePercentageDigitalSignature("secure123");
                Console.WriteLine($"Signature confidence: {confidence}%");

                // Save the image
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging system needs to generate a lossless TIFF scan and verify its authenticity with a digital signature.
 * 2. When a document management application must embed a secure watermark into high‑resolution TIFF files and later confirm the signature’s integrity.
 * 3. When a GIS platform creates large raster maps in TIFF format and wants to ensure the map data has not been tampered with by analyzing signature confidence.
 * 4. When a digital archiving solution stores scanned photographs as TIFF and requires a programmatic way to sign and validate each image for compliance audits.
 * 5. When a printing workflow produces high‑quality TIFF proofs and needs to embed a client’s approval code and check its confidence before sending to press.
 */
