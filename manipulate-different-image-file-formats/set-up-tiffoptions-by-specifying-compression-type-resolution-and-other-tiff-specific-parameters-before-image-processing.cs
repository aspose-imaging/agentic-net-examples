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
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image to obtain dimensions
        using (Image sourceImage = Image.Load(inputPath))
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            // Configure TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;
            tiffOptions.Xresolution = new TiffRational(300); // 300 DPI horizontal
            tiffOptions.Yresolution = new TiffRational(300); // 300 DPI vertical

            // Create a new TIFF image with the specified options
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Draw a gradient background
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(width, height),
                    Color.Blue,
                    Color.Yellow);

                Graphics graphics = new Graphics(tiffImage);
                graphics.FillRectangle(gradientBrush, tiffImage.Bounds);

                // Save the TIFF image to the output path
                tiffImage.Save(outputPath);
            }
        }
    }
}