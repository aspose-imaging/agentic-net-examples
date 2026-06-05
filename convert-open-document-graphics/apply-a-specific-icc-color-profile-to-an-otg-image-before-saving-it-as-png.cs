using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.otg";
            string rgbProfilePath = "Input/rgb.icc";
            string cmykProfilePath = "Input/cmyk.icc";
            string tempJpegPath = "Output/temp.jpg";
            string outputPngPath = "Output/output.png";

            // Validate input files
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

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

            // Load OTG image and rasterize to JPEG with ICC profiles
            using (Image otgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for OTG
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };

                // Configure JPEG options with ICC profiles
                JpegOptions jpegOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Cmyk,
                    VectorRasterizationOptions = otgRasterOptions
                };

                using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
                using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
                {
                    jpegOptions.RgbColorProfile = new StreamSource(rgbStream);
                    jpegOptions.CmykColorProfile = new StreamSource(cmykStream);
                }

                // Save intermediate JPEG
                otgImage.Save(tempJpegPath, jpegOptions);
            }

            // Load the JPEG and save as PNG (ICC profiles already applied)
            using (JpegImage jpegImage = (JpegImage)Image.Load(tempJpegPath))
            {
                // Re-assign ICC profiles to ensure they persist (optional)
                using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
                using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
                {
                    jpegImage.RgbColorProfile = new StreamSource(rgbStream);
                    jpegImage.CmykColorProfile = new StreamSource(cmykStream);
                }

                // Save as PNG
                PngOptions pngOptions = new PngOptions();
                jpegImage.Save(outputPngPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}