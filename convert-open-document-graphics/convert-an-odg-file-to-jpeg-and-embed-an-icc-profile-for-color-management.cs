using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.jpg";

        // Paths to ICC profile files
        string rgbProfilePath = @"C:\Images\eciRGB_v2.icc";
        string cmykProfilePath = @"C:\Images\ISOcoated_v2_FullGamut4.icc";

        // Verify input files exist
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }
        if (!File.Exists(rgbProfilePath))
        {
            Console.Error.WriteLine($"File not found: {rgbProfilePath}");
            return;
        }
        if (!File.Exists(cmykProfilePath))
        {
            Console.Error.WriteLine($"File not found: {cmykProfilePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG options with ICC profiles
            JpegOptions jpegOptions = new JpegOptions
            {
                ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk
            };

            // Open ICC profile streams and assign to options
            using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
            using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
            {
                jpegOptions.RgbColorProfile = new StreamSource(rgbStream);
                jpegOptions.CmykColorProfile = new StreamSource(cmykStream);
            }

            // Save as JPEG with embedded profiles
            image.Save(outputPath, jpegOptions);
        }
    }
}