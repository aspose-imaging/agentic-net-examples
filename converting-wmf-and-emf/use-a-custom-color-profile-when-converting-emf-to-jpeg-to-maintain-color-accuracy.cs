using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input, output, and ICC profile paths
        string inputPath = @"C:\Temp\sample.emf";
        string outputPath = @"C:\Temp\output.jpg";
        string rgbProfilePath = @"C:\Temp\eciRGB_v2.icc";
        string cmykProfilePath = @"C:\Temp\ISOcoated_v2_FullGamut4.icc";

        // Verify input EMF file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare JPEG save options with custom ICC profiles
            var jpegOptions = new JpegOptions
            {
                ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk
            };

            // Open ICC profile streams
            using (Stream rgbProfileStream = File.OpenRead(rgbProfilePath))
            using (Stream cmykProfileStream = File.OpenRead(cmykProfilePath))
            {
                jpegOptions.RgbColorProfile = new StreamSource(rgbProfileStream);
                jpegOptions.CmykColorProfile = new StreamSource(cmykProfileStream);

                // Save the image as JPEG using the custom profiles
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}