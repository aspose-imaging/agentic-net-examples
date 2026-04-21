using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output\sample.jpg";

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
            // Prepare JPEG save options with default quality
            JpegOptions jpegOptions = new JpegOptions();

            // Configure vector rasterization for OTG conversion
            OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
            {
                // Preserve original size
                PageSize = image.Size
            };
            jpegOptions.VectorRasterizationOptions = otgRasterization;

            // Save as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}