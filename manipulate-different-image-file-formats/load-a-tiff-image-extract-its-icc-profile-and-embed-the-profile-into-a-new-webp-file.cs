using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Retrieve ICC profile from the TIFF image (if present)
                TiffOptions tiffOptions = (TiffOptions)tiffImage.GetOriginalOptions();
                MemoryStream iccProfile = tiffOptions.IccProfile;

                // Convert TIFF to WebP
                using (WebPImage webpImage = new WebPImage((RasterImage)tiffImage))
                {
                    WebPOptions webpOptions = new WebPOptions();

                    // Note: Direct embedding of ICC profile into WebP is not exposed via WebPOptions.
                    // If ICC profile handling is required, additional metadata APIs would be needed.

                    webpImage.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}