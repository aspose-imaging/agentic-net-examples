using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = @"C:\temp\sample.emf";
        string outputPath = @"C:\temp\output.jpg";
        string rgbProfilePath = @"C:\temp\eciRGB_v2.icc";
        string cmykProfilePath = @"C:\temp\ISOcoated_v2_FullGamut4.icc";

        try
        {
            // Verify input files exist
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

            // Load EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Open ICC profile streams
                using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
                using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
                {
                    // Configure JPEG save options with custom color profiles
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        RgbColorProfile = new StreamSource(rgbStream),
                        CmykColorProfile = new StreamSource(cmykStream)
                    };

                    // Save as JPEG using the custom profiles
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