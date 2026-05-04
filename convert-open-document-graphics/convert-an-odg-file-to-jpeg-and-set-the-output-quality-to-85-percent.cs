using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for the vector ODG image
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    // Use a white background and preserve the original page size
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Configure JPEG save options with quality 85%
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85,
                    // Attach the rasterization options so the vector image is rasterized correctly
                    VectorRasterizationOptions = rasterOptions
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