using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.tiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the scanned document image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for watermark removal
            var rasterImage = (RasterImage)image;

            // Define the mask covering the text watermark (placeholder coordinates)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 50)));
            mask.AddFigure(figure);

            // Configure Telea algorithm options with the mask
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Remove the watermark
            using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, options))
            {
                // Set high‑resolution TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.None,
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb
                };

                // Save the cleaned image as TIFF
                result.Save(outputPath, tiffOptions);
            }
        }
    }
}