// HOW-TO: Create Multi‑Frame TIFF With Custom Photometric And LZW Compression In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.tif";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // First frame: RGB photometric
            TiffOptions frameOptions1 = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions1.BitsPerSample = new ushort[] { 8, 8, 8 };
            frameOptions1.Compression = TiffCompressions.Lzw;
            frameOptions1.Photometric = TiffPhotometrics.Rgb;
            frameOptions1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame1 = new TiffFrame(frameOptions1, 100, 100);
            LinearGradientBrush brush1 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame1.Width, frame1.Height),
                Color.Blue,
                Color.Yellow);
            Graphics graphics1 = new Graphics(frame1);
            graphics1.FillRectangle(brush1, frame1.Bounds);

            // Second frame: custom photometric (MinIsBlack)
            TiffOptions frameOptions2 = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions2.BitsPerSample = new ushort[] { 1 };
            frameOptions2.Compression = TiffCompressions.Lzw;
            frameOptions2.Photometric = TiffPhotometrics.MinIsBlack;
            frameOptions2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame2 = new TiffFrame(frameOptions2, 100, 100);
            LinearGradientBrush brush2 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame2.Width, frame2.Height),
                Color.Black,
                Color.White);
            Graphics graphics2 = new Graphics(frame2);
            graphics2.FillRectangle(brush2, frame2.Bounds);

            // Create multi‑frame TIFF image
            using (TiffImage tiffImage = new TiffImage(new TiffFrame[] { frame1, frame2 }))
            {
                // Save options for the TIFF file
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Lzw;
                saveOptions.Photometric = TiffPhotometrics.Rgb;
                saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                saveOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When you need to generate a multi‑page TIFF document where each page uses a different color interpretation, such as RGB for a color page and MinIsBlack for a monochrome page, and you want the file size reduced with LZW compression.
 * 2. When you are building a C# application that must export scanned images as a single TIFF file containing both color and black‑and‑white frames for archival or printing workflows.
 * 3. When you need to programmatically create a TIFF file with custom photometric settings to ensure compatibility with legacy imaging systems that expect specific TIFF tags.
 * 4. When you want to combine gradient graphics into separate TIFF frames and save them efficiently using lossless LZW compression for later processing or analysis.
 * 5. When you are automating the creation of multi‑frame medical or scientific images where each slice may require a different bit depth and photometric interpretation while keeping the file size manageable.
 */
