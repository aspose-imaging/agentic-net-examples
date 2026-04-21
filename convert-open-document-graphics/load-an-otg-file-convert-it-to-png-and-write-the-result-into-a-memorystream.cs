using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.otg";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // MemoryStream to hold the PNG output
        using (MemoryStream outputStream = new MemoryStream())
        {
            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up PNG save options with OTG rasterization
                PngOptions pngOptions = new PngOptions();
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Save the image as PNG into the memory stream
                image.Save(outputStream, pngOptions);
            }

            // The MemoryStream now contains the PNG data
            Console.WriteLine($"PNG data length: {outputStream.Length} bytes");
        }
    }
}