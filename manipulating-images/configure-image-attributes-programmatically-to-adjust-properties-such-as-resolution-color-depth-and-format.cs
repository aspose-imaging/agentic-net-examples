using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input image path
        string inputPath = @"C:\temp\input.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output path for JPEG with adjusted resolution
        string jpegOutputPath = @"C:\temp\output_resized.jpg";
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));

        // Output path for BMP with reduced color depth (8 bits per pixel)
        string bmpOutputPath = @"C:\temp\output_8bpp.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(bmpOutputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // ---------- Save as JPEG with custom resolution and quality ----------
            var jpegOptions = new JpegOptions
            {
                // Set resolution to 150 DPI
                ResolutionSettings = new ResolutionSetting(150.0, 150.0),
                ResolutionUnit = ResolutionUnit.Inch,
                // Highest quality
                Quality = 100,
                // Use progressive compression
                CompressionType = JpegCompressionMode.Progressive,
                // Preserve color (no grayscale conversion)
                ColorType = JpegCompressionColorMode.YCbCr
            };

            // Save the image as JPEG using the configured options
            image.Save(jpegOutputPath, jpegOptions);

            // ---------- Save as BMP with reduced color depth (8 bits per pixel) ----------
            var bmpOptions = new BmpOptions
            {
                // Reduce bits per pixel to 8 to lower file size
                BitsPerPixel = 8,
                // Use a standard 8‑bit grayscale palette (could also use a custom palette)
                Palette = ColorPaletteHelper.Create8BitGrayscale(false),
                // Set resolution to 96 DPI (common default)
                ResolutionSettings = new ResolutionSetting(96.0, 96.0)
            };

            // Save the image as BMP using the configured options
            image.Save(bmpOutputPath, bmpOptions);
        }
    }
}