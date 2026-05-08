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
            // Hard‑coded paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output.png";
            string rgbProfilePath = @"C:\Profiles\eciRGB_v2.icc";
            string cmykProfilePath = @"C:\Profiles\ISOcoated_v2_FullGamut4.icc";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Load ICC profile streams
                using (Stream rgbProfileStream = File.OpenRead(rgbProfilePath))
                using (Stream cmykProfileStream = File.OpenRead(cmykProfilePath))
                {
                    // Attempt to set ICC profiles via reflection (both JpegImage and OtgImage expose these properties)
                    var rgbProp = image.GetType().GetProperty("RgbColorProfile");
                    var cmykProp = image.GetType().GetProperty("CmykColorProfile");

                    if (rgbProp != null && cmykProp != null && rgbProp.CanWrite && cmykProp.CanWrite)
                    {
                        rgbProp.SetValue(image, new StreamSource(rgbProfileStream));
                        cmykProp.SetValue(image, new StreamSource(cmykProfileStream));
                    }
                }

                // Prepare PNG save options (no special ICC handling needed for PNG)
                PngOptions pngOptions = new PngOptions();

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}