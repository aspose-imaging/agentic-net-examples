using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.odg";
            string jpegPath = @"C:\temp\temp.cmyk.jpg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Paths to ICC profile files (adjust as needed)
            string rgbIccPath = @"C:\temp\iccprofiles\eciRGB_v2.icc";
            string cmykIccPath = @"C:\temp\iccprofiles\ISOcoated_v2_FullGamut4.icc";

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Save ODG as CMYK JPEG using custom ICC profiles
                using (Stream rgbProfileStream = File.OpenRead(rgbIccPath))
                using (Stream cmykProfileStream = File.OpenRead(cmykIccPath))
                {
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk,
                        RgbColorProfile = new Aspose.Imaging.Sources.StreamSource(rgbProfileStream),
                        CmykColorProfile = new Aspose.Imaging.Sources.StreamSource(cmykProfileStream)
                    };

                    odgImage.Save(jpegPath, jpegOptions);
                }
            }

            // Load the CMYK JPEG and save it as PNG (ICC profiles are already applied)
            using (JpegImage jpegImage = (JpegImage)Image.Load(jpegPath))
            {
                // Re-assign ICC profiles to ensure they are retained (optional)
                using (Stream rgbProfileStream = File.OpenRead(rgbIccPath))
                using (Stream cmykProfileStream = File.OpenRead(cmykIccPath))
                {
                    jpegImage.RgbColorProfile = new Aspose.Imaging.Sources.StreamSource(rgbProfileStream);
                    jpegImage.CmykColorProfile = new Aspose.Imaging.Sources.StreamSource(cmykProfileStream);
                }

                PngOptions pngOptions = new PngOptions();
                jpegImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert an OpenDocument graphic (ODG) to a CMYK JPEG with custom ICC color profiles before generating a print‑ready PNG.
 * 2. When a workflow requires embedding specific RGB and CMYK ICC profiles during image conversion to maintain color consistency across devices.
 * 3. When an application must verify the existence of the source ODG file and automatically create output directories before processing images in C#.
 * 4. When a developer wants to use Aspose.Imaging to load an ODG, apply professional color management, and save an intermediate CMYK JPEG prior to final PNG export.
 * 5. When a .NET service automates batch conversion of ODG drawings to PNG while preserving color fidelity by applying industry‑standard ICC profiles.
 */