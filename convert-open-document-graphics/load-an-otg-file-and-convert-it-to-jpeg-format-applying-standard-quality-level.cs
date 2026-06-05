using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with a standard quality level
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 100 // standard high quality
                };

                // Configure vector rasterization for OTG to JPEG conversion
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    // Preserve the original image size
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRasterization;

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}