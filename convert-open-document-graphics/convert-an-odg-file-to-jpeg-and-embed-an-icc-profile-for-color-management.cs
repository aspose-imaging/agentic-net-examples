using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.odg";
            string outputPath = "sample.jpg";

            // Hardcoded ICC profile paths
            string rgbProfilePath = "eciRGB_v2.icc";
            string cmykProfilePath = "ISOcoated_v2_FullGamut4.icc";

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

            // Load ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Open ICC profile streams
                using (var rgbStream = File.OpenRead(rgbProfilePath))
                using (var cmykStream = File.OpenRead(cmykProfilePath))
                {
                    // Configure JPEG save options with embedded ICC profiles
                    var jpegOptions = new JpegOptions
                    {
                        ColorType = JpegCompressionColorMode.Cmyk,
                        RgbColorProfile = new Aspose.Imaging.Sources.StreamSource(rgbStream),
                        CmykColorProfile = new Aspose.Imaging.Sources.StreamSource(cmykStream)
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert OpenDocument graphics (ODG) drawings into JPEG files for web preview while preserving accurate colors across monitors and printers by embedding both RGB and CMYK ICC profiles.
 * 2. When an application must generate print‑ready JPEG assets from ODG source files and ensure the output complies with industry‑standard color spaces such as ISO Coated v2.
 * 3. When a document management system automates the creation of thumbnail JPEGs from ODG diagrams and requires embedded ICC profiles to maintain consistent visual fidelity in downstream workflows.
 * 4. When a digital asset pipeline extracts vector artwork from ODG files, converts them to JPEG, and embeds color profiles to guarantee that the resulting images match the original design intent on different devices.
 * 5. When a batch‑processing tool processes multiple ODG files, converts each to JPEG, and embeds the appropriate RGB and CMYK ICC profiles to support color‑critical publishing and archival.
 */