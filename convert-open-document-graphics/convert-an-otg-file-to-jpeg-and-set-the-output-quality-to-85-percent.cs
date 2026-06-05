using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.otg";
        string outputPath = "output/output.jpg";

        try
        {
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
                var jpegOptions = new JpegOptions
                {
                    Quality = 85
                };

                // Configure rasterization options for OTG conversion
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRasterOptions;

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