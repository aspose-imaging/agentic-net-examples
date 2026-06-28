using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";
            string iccProfilePath = "sRGB.icc";

            // Validate input EPS file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Validate ICC profile file
            if (!File.Exists(iccProfilePath))
            {
                Console.Error.WriteLine($"File not found: {iccProfilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Load sRGB ICC profile
                using (FileStream iccStream = File.OpenRead(iccProfilePath))
                {
                    // Configure JPEG save options with the sRGB profile
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        RgbColorProfile = new StreamSource(iccStream)
                    };

                    // Save as JPEG
                    epsImage.Save(outputPath, jpegOptions);
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
 * 1. When a print shop receives EPS artwork with an unknown or non‑standard ICC profile and must deliver web‑ready JPEGs in the universal sRGB color space.
 * 2. When a digital asset management system needs to ingest vector EPS files, normalize their color profiles to sRGB, and generate thumbnail JPEG previews for quick browsing.
 * 3. When an e‑commerce platform converts supplier‑provided EPS logos to sRGB JPEG images to ensure consistent color rendering across browsers and mobile devices.
 * 4. When a marketing automation tool batch‑processes EPS banners, replaces their embedded color profiles with the sRGB profile, and saves them as JPEGs for email campaigns.
 * 5. When a scientific visualization pipeline exports EPS charts, applies the sRGB ICC profile for accurate on‑screen colors, and outputs JPEG files for inclusion in reports.
 */