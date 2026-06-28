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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.emf";
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
                    ColorType = JpegCompressionColorMode.Rgb
                };

                // Load ICC profile streams
                using (Stream rgbProfileStream = File.OpenRead(rgbProfilePath))
                using (Stream cmykProfileStream = File.OpenRead(cmykProfilePath))
                {
                    jpegOptions.RgbColorProfile = new StreamSource(rgbProfileStream);
                    jpegOptions.CmykColorProfile = new StreamSource(cmykProfileStream);

                    // Save as JPEG using the configured options
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert vector EMF graphics to JPEG for web display while preserving the original brand colors using a custom ICC profile.
 * 2. When a printing workflow requires accurate color reproduction from EMF source files to JPEG previews, and the developer must embed specific RGB and CMYK profiles during conversion.
 * 3. When an application generates reports that include EMF charts and must export them as JPEG images that match the corporate color standards defined in external ICC files.
 * 4. When a digital asset management system ingests EMF logos and needs to create JPEG thumbnails with exact color fidelity by applying custom color profiles via Aspose.Imaging in C#.
 * 5. When a developer is building a batch conversion tool that processes multiple EMF files into JPEGs for archival, ensuring each output image uses the correct ICC profile to maintain consistency across devices.
 */