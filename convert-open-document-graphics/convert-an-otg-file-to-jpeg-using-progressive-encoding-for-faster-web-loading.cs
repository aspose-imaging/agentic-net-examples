using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output.jpg";

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
                // Prepare rasterization options for OTG
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure JPEG options with progressive compression
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 90,
                    VectorRasterizationOptions = otgRasterizationOptions
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}