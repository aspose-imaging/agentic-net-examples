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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output.jpg";

            // Paths to ICC profile files
            string rgbProfilePath = @"C:\Profiles\eciRGB_v2.icc";
            string cmykProfilePath = @"C:\Profiles\ISOcoated_v2_FullGamut4.icc";

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Open ICC profile streams
                using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
                using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
                {
                    // Set up JPEG save options with ICC profiles
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        VectorRasterizationOptions = otgOptions,
                        ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk,
                        RgbColorProfile = new StreamSource(rgbStream),
                        CmykColorProfile = new StreamSource(cmykStream)
                    };

                    // Save as JPEG with embedded profiles
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