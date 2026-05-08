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
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.emf";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Paths to custom ICC profiles
            string rgbProfilePath = @"C:\temp\eciRGB_v2.icc";
            string cmykProfilePath = @"C:\temp\ISOcoated_v2_FullGamut4.icc";

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with custom color profiles
                JpegOptions jpegOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Cmyk
                };

                // Load ICC profile streams and assign to options
                using (Stream rgbProfileStream = File.OpenRead(rgbProfilePath))
                using (Stream cmykProfileStream = File.OpenRead(cmykProfilePath))
                {
                    jpegOptions.RgbColorProfile = new StreamSource(rgbProfileStream);
                    jpegOptions.CmykColorProfile = new StreamSource(cmykProfileStream);

                    // Save the image as JPEG using the configured options
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