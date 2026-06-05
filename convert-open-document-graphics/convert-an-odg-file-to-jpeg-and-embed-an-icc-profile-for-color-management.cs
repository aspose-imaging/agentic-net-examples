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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.odg";
            string outputPath = @"C:\temp\output.jpg";

            // Hardcoded ICC profile file paths
            string rgbProfilePath = @"C:\temp\eciRGB_v2.icc";
            string cmykProfilePath = @"C:\temp\ISOcoated_v2_FullGamut4.icc";

            // Validate input files
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

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Open ICC profile streams
                using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
                using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
                {
                    // Configure JPEG options with embedded ICC profiles
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk,
                        RgbColorProfile = new StreamSource(rgbStream),
                        CmykColorProfile = new StreamSource(cmykStream)
                    };

                    // Save the image as JPEG with the specified options
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