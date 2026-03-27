using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"input\sample.otg";
        string outputPath = @"output\converted.jpg";
        string rgbProfilePath = @"profiles\rgb.icc";
        string cmykProfilePath = @"profiles\cmyk.icc";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Verify ICC profile files exist
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

        // Load OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare JPEG save options with ICC profiles
            var jpegOptions = new JpegOptions
            {
                ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk
            };

            // Set rasterization options for OTG vector content
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };
            jpegOptions.VectorRasterizationOptions = otgRasterOptions;

            // Load ICC profiles into streams and assign to options
            using (Stream rgbStream = File.OpenRead(rgbProfilePath))
            using (Stream cmykStream = File.OpenRead(cmykProfilePath))
            {
                jpegOptions.RgbColorProfile = new StreamSource(rgbStream);
                jpegOptions.CmykColorProfile = new StreamSource(cmykStream);

                // Save as JPEG with embedded ICC profiles
                otgImage.Save(outputPath, jpegOptions);
            }
        }
    }
}