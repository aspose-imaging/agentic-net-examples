using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.otg";
        string outputPath = @"C:\temp\output.jpg";

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
                // Configure OTG rasterization options
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size
                };

                // Configure JPEG save options with desired compression level
                JpegOptions jpegOptions = new JpegOptions
                {
                    // JPEG quality (1-100). Adjust as needed for compression.
                    Quality = 80,
                    // Attach the rasterization options so the vector OTG is rasterized correctly
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save the image as JPEG using the configured options
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}