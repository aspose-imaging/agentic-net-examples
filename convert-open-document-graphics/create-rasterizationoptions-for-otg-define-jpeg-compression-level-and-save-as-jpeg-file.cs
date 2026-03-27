using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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
            // Create OTG rasterization options
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                // Preserve original aspect ratio by using source size
                PageSize = image.Size
            };

            // Create JPEG save options and define compression level (Quality 1-100)
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 80, // Example compression level
                VectorRasterizationOptions = otgOptions
            };

            // Save the image as JPEG using the configured options
            image.Save(outputPath, jpegOptions);
        }
    }
}