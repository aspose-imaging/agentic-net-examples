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
        // Paths for the source TIFF and the result TIFF
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the existing TIFF image
        using (Image loadedImage = Image.Load(inputPath))
        {
            // Cast to TiffImage to access frame operations
            using (TiffImage tiffImage = (TiffImage)loadedImage)
            {
                // -------------------------------------------------
                // Create first additional frame (RGB, LZW compression)
                // -------------------------------------------------
                TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
                options1.BitsPerSample = new ushort[] { 8, 8, 8 };
                options1.Photometric = TiffPhotometrics.Rgb;
                options1.Compression = TiffCompressions.Lzw;
                options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                TiffFrame frame1 = new TiffFrame(options1, 200, 200);

                // Draw a blue‑yellow gradient on the first frame
                Graphics graphics1 = new Graphics(frame1);
                LinearGradientBrush brush1 = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(frame1.Width, frame1.Height),
                    Color.Blue,
                    Color.Yellow);
                graphics1.FillRectangle(brush1, frame1.Bounds);

                // Add the first frame to the TIFF image
                tiffImage.AddFrame(frame1);

                // -------------------------------------------------
                // Create second additional frame (1‑bit B/W, CCITT Fax3)
                // -------------------------------------------------
                TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
                options2.BitsPerSample = new ushort[] { 1 };
                options2.Photometric = TiffPhotometrics.MinIsBlack;
                options2.Compression = TiffCompressions.CcittFax3;
                options2.ByteOrder = TiffByteOrder.LittleEndian;
                options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                TiffFrame frame2 = new TiffFrame(options2, 150, 150);

                // Draw the same gradient; it will be converted to B/W automatically
                Graphics graphics2 = new Graphics(frame2);
                LinearGradientBrush brush2 = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(frame2.Width, frame2.Height),
                    Color.Blue,
                    Color.Yellow);
                graphics2.FillRectangle(brush2, frame2.Bounds);

                // Add the second frame
                tiffImage.AddFrame(frame2);

                // -------------------------------------------------
                // Create third additional frame (RGB, Deflate compression)
                // -------------------------------------------------
                TiffOptions options3 = new TiffOptions(TiffExpectedFormat.Default);
                options3.BitsPerSample = new ushort[] { 8, 8, 8 };
                options3.Photometric = TiffPhotometrics.Rgb;
                options3.Compression = TiffCompressions.Deflate;
                options3.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                TiffFrame frame3 = new TiffFrame(options3, 250, 250);

                // Draw a gradient with different colors
                Graphics graphics3 = new Graphics(frame3);
                LinearGradientBrush brush3 = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(frame3.Width, frame3.Height),
                    Color.Green,
                    Color.Red);
                graphics3.FillRectangle(brush3, frame3.Bounds);

                // Add the third frame
                tiffImage.AddFrame(frame3);

                // -------------------------------------------------
                // Save the updated TIFF image to a new file
                // -------------------------------------------------
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputPath, saveOptions);
            }
        }
    }
}