using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded file paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.jpg";
            string rgbProfilePath = @"C:\temp\eciRGB_v2.icc";
            string cmykProfilePath = @"C:\temp\ISOcoated_v2_FullGamut4.icc";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with ICC profiles
                var jpegOptions = new JpegOptions
                {
                    // Use CMYK color mode to demonstrate both profiles; change to Rgb if desired
                    ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk
                };

                // Open ICC profile streams
                using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
                using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
                {
                    jpegOptions.RgbColorProfile = new StreamSource(rgbStream);
                    jpegOptions.CmykColorProfile = new StreamSource(cmykStream);

                    // Save the image as JPEG with embedded profiles
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}