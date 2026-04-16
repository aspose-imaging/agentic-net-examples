using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input, output, and ICC profile paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.jpg";
        string rgbProfilePath = @"C:\Profiles\eciRGB_v2.icc";
        string cmykProfilePath = @"C:\Profiles\ISOcoated_v2_FullGamut4.icc";

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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Configure JPEG options with custom ICC profiles
            var jpegOptions = new JpegOptions
            {
                ColorType = JpegCompressionColorMode.Cmyk
            };

            using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
            using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
            {
                jpegOptions.RgbColorProfile = new StreamSource(rgbStream);
                jpegOptions.CmykColorProfile = new StreamSource(cmykStream);

                // Save the image as JPEG using the custom profiles
                emfImage.Save(outputPath, jpegOptions);
            }
        }
    }
}