// HOW-TO: Convert ODG to JPEG with Embedded RGB and CMYK ICC Profiles in C# (Aspose.Imaging for .NET)
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
            // Hardcoded paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample.jpg";
            string rgbProfilePath = @"C:\Profiles\eciRGB_v2.icc";
            string cmykProfilePath = @"C:\Profiles\ISOcoated_v2_FullGamut4.icc";

            // Validate input ODG file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Validate ICC profile files
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

            // Load ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with ICC profiles
                var jpegOptions = new JpegOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk,
                    RgbColorProfile = new StreamSource(File.OpenRead(rgbProfilePath)),
                    CmykColorProfile = new StreamSource(File.OpenRead(cmykProfilePath))
                };

                // Save as JPEG with embedded profiles
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
 * 1. When a publishing workflow needs to convert OpenDocument graphics to web‑ready JPEGs while preserving color accuracy with both RGB and CMYK ICC profiles.
 * 2. When a print‑shop application must generate JPEG previews from ODG files and embed the correct color profiles for downstream RIP processing.
 * 3. When a digital asset management system imports ODG artwork and stores it as JPEGs with embedded ICC data to ensure consistent display across devices.
 * 4. When an automated batch job converts a folder of ODG diagrams to JPEG for email distribution, embedding the company’s standard RGB and CMYK profiles.
 * 5. When a C# service creates color‑managed JPEG thumbnails from ODG source files for a marketing portal that requires accurate brand colors.
 */
