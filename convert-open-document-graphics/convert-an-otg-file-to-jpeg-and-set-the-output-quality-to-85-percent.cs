using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
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
                // Prepare JPEG save options with quality 85
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85
                };

                // Configure vector rasterization options for OTG conversion
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRasterizationOptions;

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}