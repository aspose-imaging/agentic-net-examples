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
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.otg";
        string outputPath = @"C:\temp\output.png";

        // Paths to the ICC profile files
        string rgbProfilePath = @"C:\temp\iccprofiles\eciRGB_v2.icc";
        string cmykProfilePath = @"C:\temp\iccprofiles\ISOcoated_v2_FullGamut4.icc";

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

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Open ICC profile streams
            using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
            using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
            {
                // If the image is a JPEG, assign the ICC profiles directly
                if (image is JpegImage jpegImage)
                {
                    jpegImage.RgbColorProfile = new StreamSource(rgbStream);
                    jpegImage.CmykColorProfile = new StreamSource(cmykStream);
                }

                // Save the image as PNG
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
    }
}