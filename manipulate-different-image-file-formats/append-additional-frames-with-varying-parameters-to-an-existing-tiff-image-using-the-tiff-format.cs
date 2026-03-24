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
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load existing TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // ----- First new frame (RGB, 100x100) -----
            TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
            options1.BitsPerSample = new ushort[] { 8, 8, 8 };
            options1.Photometric = TiffPhotometrics.Rgb;
            options1.Compression = TiffCompressions.Lzw;
            options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame1 = new TiffFrame(options1, 100, 100);
            tiffImage.AddFrame(frame1);
            tiffImage.ActiveFrame = frame1;

            LinearGradientBrush gradient1 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame1.Width, frame1.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics1 = new Graphics(tiffImage);
            graphics1.FillRectangle(gradient1, frame1.Bounds);

            // ----- Second new frame (B/W, 200x200) -----
            TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
            options2.BitsPerSample = new ushort[] { 1 };
            options2.Photometric = TiffPhotometrics.MinIsBlack;
            options2.Compression = TiffCompressions.CcittFax3;
            options2.ByteOrder = TiffByteOrder.LittleEndian;
            options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame frame2 = new TiffFrame(options2, 200, 200);
            tiffImage.AddFrame(frame2);
            tiffImage.ActiveFrame = frame2;

            LinearGradientBrush gradient2 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame2.Width, frame2.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics2 = new Graphics(tiffImage);
            graphics2.FillRectangle(gradient2, frame2.Bounds);

            // Save the updated TIFF to the output path
            tiffImage.Save(outputPath);
        }
    }
}