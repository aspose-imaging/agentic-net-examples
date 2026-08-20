// HOW-TO: Create Multi‑Frame TIFF With LZW Compression And Gradient Frames In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
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
            // Output file path
            string outputPath = @"C:\Temp\output.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Options for the first frame
            var options1 = new TiffOptions(TiffExpectedFormat.Default);
            options1.BitsPerSample = new ushort[] { 8, 8, 8 };
            options1.Compression = TiffCompressions.Lzw;
            options1.Photometric = TiffPhotometrics.Rgb;
            options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create first frame
            var frame1 = new TiffFrame(options1, 200, 200);
            var graphics1 = new Graphics(frame1);
            var brush1 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame1.Width, frame1.Height),
                Color.Blue,
                Color.Yellow);
            graphics1.FillRectangle(brush1, frame1.Bounds);

            // Options for the second frame
            var options2 = new TiffOptions(TiffExpectedFormat.Default);
            options2.BitsPerSample = new ushort[] { 8, 8, 8 };
            options2.Compression = TiffCompressions.Lzw;
            options2.Photometric = TiffPhotometrics.Rgb;
            options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create second frame
            var frame2 = new TiffFrame(options2, 200, 200);
            var graphics2 = new Graphics(frame2);
            var brush2 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame2.Width, frame2.Height),
                Color.Green,
                Color.Red);
            graphics2.FillRectangle(brush2, frame2.Bounds);

            // Create multi‑frame TIFF image and add the second frame
            using (var tiffImage = new TiffImage(frame1))
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

/*
 * Real-World Use Cases:
 * 1. When you need to generate a multi‑page TIFF document where each page has a different gradient background and must be compressed with LZW to reduce file size.
 * 2. When you are building a C# application that creates scanned‑like TIFF files with multiple frames for archival or printing workflows.
 * 3. When you want to programmatically add custom TIFF frames with specific bits‑per‑sample and planar configuration for compatibility with legacy imaging systems.
 * 4. When you need to export chart or map images as tiled TIFF frames that preserve color fidelity and use lossless compression.
 * 5. When you are automating the creation of multi‑frame medical or satellite imagery files that require consistent compression and photometric settings across all frames.
 */
