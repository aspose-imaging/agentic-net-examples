// HOW-TO: Convert EPS to JPEG with sRGB Color Profile in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input, output and ICC profile paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";
            string iccPath = "sRGB.icc";

            // Verify input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify ICC profile file exists
            if (!File.Exists(iccPath))
            {
                Console.Error.WriteLine($"File not found: {iccPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Load sRGB ICC profile and set it for JPEG saving
                using (Stream iccStream = File.OpenRead(iccPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        // Assign the sRGB profile as the destination RGB profile
                        RgbColorProfile = new StreamSource(iccStream)
                    };

                    // Save the image as JPEG with the specified color profile
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
 * 1. When you need to generate web‑ready JPEG thumbnails from EPS artwork while ensuring the colors match the sRGB standard.
 * 2. When a printing workflow requires converting EPS logos to JPEG for email previews and must embed an sRGB ICC profile to avoid color shifts.
 * 3. When an e‑commerce platform imports vector product designs in EPS and must store them as JPEG images with consistent color across browsers.
 * 4. When a digital asset management system processes incoming EPS files and needs to replace their embedded color profile with sRGB before archiving as JPEG.
 * 5. When a batch script converts EPS files to JPEG for mobile apps and must guarantee the output uses the sRGB profile for accurate display on consumer devices.
 */
