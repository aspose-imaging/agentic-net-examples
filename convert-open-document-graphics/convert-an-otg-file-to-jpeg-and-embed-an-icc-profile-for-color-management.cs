// HOW-TO: Convert OTG to JPEG with Embedded ICC Profile in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input OTG file path
            string inputPath = @"C:\Images\sample.otg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output JPEG file path
            string outputPath = @"C:\Images\output.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Hardcoded ICC profile (RGB) path
            string rgbProfilePath = @"C:\Profiles\eciRGB_v2.icc";

            // Verify ICC profile file exists
            if (!File.Exists(rgbProfilePath))
            {
                Console.Error.WriteLine($"File not found: {rgbProfilePath}");
                return;
            }

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with ICC profile
                JpegOptions jpegOptions = new JpegOptions();

                // Set the RGB ICC profile for color management
                using (Stream rgbProfileStream = File.OpenRead(rgbProfilePath))
                {
                    jpegOptions.RgbColorProfile = new StreamSource(rgbProfileStream);

                    // Configure rasterization to convert vector OTG to raster JPEG
                    OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size // preserve original size
                    };
                    jpegOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the image as JPEG with embedded ICC profile
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
 * 1. When you need to display vector OTG graphics on the web as JPEGs while preserving accurate colors across devices.
 * 2. When a printing workflow requires converting OTG files to JPEG and embedding an ICC profile to ensure color consistency in the final print.
 * 3. When an application must batch‑process OTG drawings into JPEG thumbnails that include the source color profile for correct rendering in image viewers.
 * 4. When integrating Aspose.Imaging into a C# service that receives OTG uploads and returns JPEG images with embedded RGB ICC profiles for downstream color‑managed pipelines.
 * 5. When migrating legacy OTG assets to a JPEG archive and you must retain the original color space information by embedding the appropriate ICC profile during conversion.
 */
