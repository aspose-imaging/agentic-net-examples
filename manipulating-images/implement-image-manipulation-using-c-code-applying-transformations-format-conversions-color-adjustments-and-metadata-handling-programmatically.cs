using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPngPath = "output/output.png";
        string outputTiffPath = "output/output_cmyk.tif";
        string outputJpegPath = "output/output_quality.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputJpegPath));

        // Load the image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Adjust brightness (+30), contrast (+0.2), and gamma (1.1)
            image.AdjustBrightness(30);
            image.AdjustContrast(0.2f);
            image.AdjustGamma(1.1f);

            // Convert to grayscale
            image.Grayscale();

            // Rotate 45 degrees, expand canvas, fill background with white
            image.Rotate(45f, true, Color.White);

            // Resize to 800x600
            image.Resize(800, 600);

            // Crop a rectangle (x=100, y=100, width=400, height=300)
            var cropRect = new Rectangle(100, 100, 400, 300);
            image.Crop(cropRect);

            // Remove all metadata
            image.RemoveMetadata();

            // Save as PNG
            var pngOptions = new PngOptions();
            image.Save(outputPngPath, pngOptions);

            // Save as CMYK TIFF (LZW compression)
            var tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwCmyk);
            image.Save(outputTiffPath, tiffOptions);

            // Save as JPEG with quality 80
            var jpegOptions = new JpegOptions { Quality = 80 };
            image.Save(outputJpegPath, jpegOptions);
        }
    }
}