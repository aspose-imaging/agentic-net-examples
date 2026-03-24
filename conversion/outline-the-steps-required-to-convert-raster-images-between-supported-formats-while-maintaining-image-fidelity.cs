using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the raster image (any supported format)
        using (Image image = Image.Load(inputPath))
        {
            // Convert to PNG
            string pngOutput = @"C:\temp\output\sample.png";
            Directory.CreateDirectory(Path.GetDirectoryName(pngOutput));
            image.Save(pngOutput, new PngOptions());

            // Convert to JPEG with high quality to preserve fidelity
            string jpegOutput = @"C:\temp\output\sample.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(jpegOutput));
            var jpegOptions = new JpegOptions { Quality = 95 };
            image.Save(jpegOutput, jpegOptions);

            // Convert to TIFF (lossless)
            string tiffOutput = @"C:\temp\output\sample.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(tiffOutput));
            var tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
            image.Save(tiffOutput, tiffOptions);

            // Convert to GIF (if needed)
            string gifOutput = @"C:\temp\output\sample.gif";
            Directory.CreateDirectory(Path.GetDirectoryName(gifOutput));
            image.Save(gifOutput, new GifOptions());

            // Convert to BMP with specific bits per pixel
            string bmpOutput = @"C:\temp\output\sample_24bpp.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(bmpOutput));
            var bmpOptions = new BmpOptions { BitsPerPixel = 24 };
            image.Save(bmpOutput, bmpOptions);
        }
    }
}