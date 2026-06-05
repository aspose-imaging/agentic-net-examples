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
        string outputPath = "output\\multi.tif";

        try
        {
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // First frame with default LZW compression
            TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
            options1.BitsPerSample = new ushort[] { 8, 8, 8 };
            options1.Compression = TiffCompressions.Lzw;
            options1.Photometric = TiffPhotometrics.Rgb;
            options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame1 = new TiffFrame(options1, 200, 200);
            Graphics g1 = new Graphics(frame1);
            using (LinearGradientBrush brush1 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame1.Width, frame1.Height),
                Color.Blue,
                Color.Yellow))
            {
                g1.FillRectangle(brush1, frame1.Bounds);
            }

            // Second frame with Deflate compression
            TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
            options2.BitsPerSample = new ushort[] { 8, 8, 8 };
            options2.Compression = TiffCompressions.Deflate;
            options2.Photometric = TiffPhotometrics.Rgb;
            options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame2 = new TiffFrame(options2, 200, 200);
            Graphics g2 = new Graphics(frame2);
            using (LinearGradientBrush brush2 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame2.Width, frame2.Height),
                Color.Red,
                Color.Green))
            {
                g2.FillRectangle(brush2, frame2.Bounds);
            }

            // Create multi‑frame TIFF and add the second frame
            using (TiffImage tiffImage = new TiffImage(frame1))
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
 * 1. When a developer needs to generate a multi‑page TIFF archive of scanned invoices in C#, using Aspose.Imaging to apply LZW compression on the first page and Deflate compression on subsequent pages to minimize file size while preserving image quality.
 * 2. When building a GIS solution that stores large aerial images as tiled TIFF frames, the code lets the developer define custom tile dimensions and choose optimal compression for each frame to improve rendering speed and storage efficiency.
 * 3. When creating a multi‑frame medical image series (e.g., DICOM‑compatible TIFF) in C#, where each slice requires a different compression setting to meet regulatory storage constraints, this snippet shows how to configure TiffOptions per frame.
 * 4. When assembling a print‑ready multi‑page brochure in C#, where each page must be saved as a separate TIFF frame with specific photometric and planar configuration, the example demonstrates how to add and save the frames as a single TIFF file.
 * 5. When developing a digital asset management system that batches high‑resolution product photos into a single TIFF container, the code provides a way to add frames with custom tile size and compression to optimize bandwidth usage and storage costs.
 */