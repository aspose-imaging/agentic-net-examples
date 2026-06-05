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
            // Hardcoded input OTG file path
            string inputPath = @"C:\Images\sample.otg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare PNG save options with OTG rasterization settings
                var pngOptions = new PngOptions();

                var otgRasterization = new OtgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = otgImage.Size
                };

                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Save the image to a memory stream in PNG format
                using (var memoryStream = new MemoryStream())
                {
                    otgImage.Save(memoryStream, pngOptions);

                    // Example usage of the resulting PNG data
                    Console.WriteLine($"PNG data size: {memoryStream.Length} bytes");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}