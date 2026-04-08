using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input EMF file and output JPEG file
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.jpg";

        // Paths to custom ICC profiles (RGB and CMYK)
        string rgbProfilePath = @"C:\Profiles\eciRGB_v2.icc";
        string cmykProfilePath = @"C:\Profiles\ISOcoated_v2_FullGamut4.icc";

        // Verify that all required files exist
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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Open the ICC profile streams
            using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
            using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
            {
                // Configure JPEG save options with custom color profiles
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Use CMYK color mode so the profiles are applied
                    ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk,
                    RgbColorProfile = new StreamSource(rgbStream),
                    CmykColorProfile = new StreamSource(cmykStream)
                };

                // Save the image as JPEG using the configured options
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}