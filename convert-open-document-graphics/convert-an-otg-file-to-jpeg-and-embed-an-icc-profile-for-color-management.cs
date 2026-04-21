using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input OTG file path
        string inputPath = @"C:\Images\sample.otg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output JPEG file path
        string outputPath = @"C:\Images\output.jpg";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Hardcoded ICC profile paths
        string rgbIccPath = @"C:\Profiles\eciRGB_v2.icc";
        string cmykIccPath = @"C:\Profiles\ISOcoated_v2_FullGamut4.icc";

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for vector to raster conversion
            OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size // Preserve original size
            };

            // Configure JPEG save options with ICC profiles
            JpegOptions jpegOptions = new JpegOptions
            {
                ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk,
                VectorRasterizationOptions = rasterOptions
            };

            // Attach ICC profiles
            using (Stream rgbProfileStream = File.OpenRead(rgbIccPath))
            using (Stream cmykProfileStream = File.OpenRead(cmykIccPath))
            {
                jpegOptions.RgbColorProfile = new StreamSource(rgbProfileStream);
                jpegOptions.CmykColorProfile = new StreamSource(cmykProfileStream);

                // Save the image as JPEG with embedded profiles
                otgImage.Save(outputPath, jpegOptions);
            }
        }
    }
}