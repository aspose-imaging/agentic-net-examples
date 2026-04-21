using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input ODG file and output JPEG file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.jpg";

        // Hard‑coded ICC profile to embed in the JPEG
        string iccProfilePath = @"C:\Images\profile.icc";

        // Verify that the input ODG file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Verify that the ICC profile file exists
        if (!File.Exists(iccProfilePath))
        {
            Console.Error.WriteLine($"ICC profile not found: {iccProfilePath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Prepare JPEG save options with the ICC profile
            JpegOptions jpegOptions = new JpegOptions
            {
                // Use the RGB ICC profile for color management
                RgbColorProfile = new StreamSource(File.OpenRead(iccProfilePath))
            };

            // Save the image as JPEG with the embedded ICC profile
            odgImage.Save(outputPath, jpegOptions);
        }
    }
}