using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample_converted.jpg";

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
            // Prepare JPEG save options with progressive compression
            JpegOptions jpegOptions = new JpegOptions
            {
                CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                Quality = 90 // Adjust quality as needed (1-100)
            };

            // Configure vector rasterization for OTG
            OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
            {
                PageSize = image.Size // Preserve original size
            };
            jpegOptions.VectorRasterizationOptions = otgRasterization;

            // Save the image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}