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
        // Hardcoded paths
        string outputPath = @"C:\temp\highres_signed.tif";
        string inputPath = outputPath;

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create high‑resolution TIFF (e.g., 2000x2000)
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create image bound to the output file
        using (Image image = Image.Create(tiffOptions, 2000, 2000))
        {
            // Fill with a simple gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(image.Width, image.Height),
                Color.Blue,
                Color.Yellow))
            {
                Graphics graphics = new Graphics(image);
                graphics.FillRectangle(brush, image.Bounds);
            }

            // Embed digital signature
            RasterImage raster = (RasterImage)image;
            raster.EmbedDigitalSignature("mySecretPassword");

            // Save the bound image
            image.Save();
        }

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the TIFF and analyze signature confidence
        using (Image loadedImage = Image.Load(inputPath))
        {
            RasterImage loadedRaster = (RasterImage)loadedImage;
            double confidence = loadedRaster.AnalyzePercentageDigitalSignature("mySecretPassword");
            Console.WriteLine($"Signature confidence: {confidence}%");
        }
    }
}