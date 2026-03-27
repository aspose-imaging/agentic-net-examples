using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.otg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG to PNG conversion
            var otgRasterOptions = new OtgRasterizationOptions
            {
                // Preserve the original image size
                PageSize = image.Size
            };

            // Set up PNG save options and attach the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the converted image into a memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, pngOptions);

                // The memory stream now contains the PNG data.
                // Reset position if further processing is needed.
                memoryStream.Position = 0;

                // Example: output the size of the generated PNG data
                Console.WriteLine($"PNG data length: {memoryStream.Length} bytes");
            }
        }
    }
}