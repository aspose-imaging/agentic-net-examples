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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\Result\sample.jpg";

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
                // Configure OTG rasterization options
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size
                };

                // Configure JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Set JPEG quality (compression level) between 1 and 100
                    Quality = 80,
                    // Assign the vector rasterization options for proper OTG rendering
                    VectorRasterizationOptions = otgOptions
                };

                // Save the image as JPEG using the defined options
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}