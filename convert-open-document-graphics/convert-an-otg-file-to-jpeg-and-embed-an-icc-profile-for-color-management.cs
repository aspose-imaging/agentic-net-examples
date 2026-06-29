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
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.jpg";
        string rgbProfilePath = @"C:\Profiles\rgb.icc";
        string cmykProfilePath = @"C:\Profiles\cmyk.icc";

        try
        {
            // Verify input OTG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify ICC profile files exist
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

            // Load OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with ICC profiles
                var jpegOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Cmyk
                };

                // Load ICC profiles into streams and assign to options
                using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
                using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
                {
                    jpegOptions.RgbColorProfile = new StreamSource(rgbStream);
                    jpegOptions.CmykColorProfile = new StreamSource(cmykStream);
                }

                // Set rasterization options for OTG conversion
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save as JPEG with embedded ICC profiles
                image.Save(outputPath, jpegOptions);
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
 * 1. When a printing workflow requires converting proprietary OTG artwork files to JPEG for web preview while preserving accurate colors via embedded RGB and CMYK ICC profiles.
 * 2. When a digital asset management system needs to ingest OTG images and store them as JPEGs with embedded color profiles to ensure consistent display across devices.
 * 3. When a batch processing script must automate the conversion of OTG files to JPEG in a C# application, embedding ICC profiles for color‑managed output in marketing materials.
 * 4. When a desktop publishing tool integrates Aspose.Imaging to allow users to export OTG graphics to JPEG with embedded ICC profiles for accurate color reproduction in proofs.
 * 5. When a cloud‑based image service processes uploaded OTG files and returns JPEG thumbnails that include embedded RGB and CMYK ICC profiles for downstream color‑critical applications.
 */