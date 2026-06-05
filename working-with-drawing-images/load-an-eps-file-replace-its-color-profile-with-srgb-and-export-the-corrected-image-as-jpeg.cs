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
            string inputPath = "input/input.eps";
            string outputPath = "output/output.jpg";
            string srgbProfilePath = "profiles/sRGB.icc";

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
            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Prepare JPEG save options with sRGB profile
                using (var srgbStream = File.OpenRead(srgbProfilePath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        // Use default RGB color type
                        ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Rgb,
                        // Assign the sRGB ICC profile
                        RgbColorProfile = new StreamSource(srgbStream)
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
 * 1. When a web application must display vector EPS logos on browsers that only support raster JPEG images with a standard sRGB color space, this code converts the EPS to a JPEG with an embedded sRGB ICC profile.
 * 2. When an e‑commerce platform receives product artwork in EPS format and needs to generate thumbnail JPEGs that match the site's color management workflow, the code loads the EPS, applies the sRGB profile, and saves the result as JPEG.
 * 3. When a digital asset management system imports EPS files from designers and must store them as JPEGs for quick preview while ensuring consistent colors across devices, the code replaces the original profile with sRGB before saving.
 * 4. When a print‑to‑web service has to convert customer‑submitted EPS files to web‑ready JPEGs and guarantee that the output uses the sRGB color space for accurate on‑screen rendering, this snippet performs the conversion.
 * 5. When an automated batch job processes a folder of EPS illustrations, embeds a standard sRGB ICC profile, and outputs JPEG files for use in email newsletters, the code provides the necessary loading, profiling, and saving steps.
 */