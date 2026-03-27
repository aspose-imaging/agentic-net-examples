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
        // Hardcoded output path
        string outputPath = "output\\multi.tif";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Options for the first frame (RGB photometric)
        TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
        options1.BitsPerSample = new ushort[] { 8, 8, 8 };
        options1.Compression = TiffCompressions.Lzw;
        options1.Photometric = TiffPhotometrics.Rgb;
        options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // Options for the second frame (custom photometric: MinIsBlack)
        TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
        options2.BitsPerSample = new ushort[] { 1 };
        options2.Compression = TiffCompressions.Lzw;
        options2.Photometric = TiffPhotometrics.MinIsBlack;
        options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // Create the first frame
        using (TiffFrame frame1 = new TiffFrame(options1, 100, 100))
        {
            // Fill the first frame with a blue‑yellow gradient
            using (LinearGradientBrush brush1 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame1.Width, frame1.Height),
                Color.Blue,
                Color.Yellow))
            {
                Graphics graphics1 = new Graphics(frame1);
                graphics1.FillRectangle(brush1, frame1.Bounds);
            }

            // Create the second frame
            using (TiffFrame frame2 = new TiffFrame(options2, 100, 100))
            {
                // Fill the second frame with a black‑white gradient (1‑bit)
                using (LinearGradientBrush brush2 = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(frame2.Width, frame2.Height),
                    Color.Black,
                    Color.White))
                {
                    Graphics graphics2 = new Graphics(frame2);
                    graphics2.FillRectangle(brush2, frame2.Bounds);
                }

                // Create a multi‑frame TIFF image starting with the first frame
                using (TiffImage tiffImage = new TiffImage(frame1))
                {
                    // Add the second frame
                    tiffImage.AddFrame(frame2);

                    // Save the multi‑frame TIFF
                    tiffImage.Save(outputPath);
                }
            }
        }
    }
}