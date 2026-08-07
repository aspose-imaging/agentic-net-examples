using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";
        string srgbProfilePath = "sRGB.icc";

        try
        {
            // Verify input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify sRGB ICC profile exists
            if (!File.Exists(srgbProfilePath))
            {
                Console.Error.WriteLine($"File not found: {srgbProfilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Prepare JPEG save options with sRGB profile
                var jpegOptions = new JpegOptions();

                using (var srgbStream = File.OpenRead(srgbProfilePath))
                {
                    jpegOptions.RgbColorProfile = new StreamSource(srgbStream);

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
 * 1. When a web developer needs to convert a print‑ready EPS logo to a web‑friendly JPEG while ensuring the colors match the sRGB profile for consistent display across browsers.
 * 2. When a digital asset manager must batch‑process EPS artwork from a designer, replace its embedded color profile with the standard sRGB ICC profile, and save the results as JPEGs for inclusion in a product catalog.
 * 3. When an e‑commerce platform requires converting vendor‑supplied EPS product illustrations to JPEG thumbnails with accurate sRGB colors to prevent color shifts on consumer devices.
 * 4. When a publishing workflow automates the preparation of EPS cover art for online preview, applying an sRGB profile before exporting to JPEG to maintain color fidelity on mobile readers.
 * 5. When a software engineer integrates a C# service that validates the existence of an EPS file and an sRGB ICC file, then replaces the EPS’s color profile and outputs a JPEG for archival or sharing purposes.
 */