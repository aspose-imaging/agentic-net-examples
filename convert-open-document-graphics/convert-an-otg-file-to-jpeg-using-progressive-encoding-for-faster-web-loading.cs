using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for vector content
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure JPEG options with progressive compression
            JpegOptions jpegOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Progressive,
                Quality = 90, // Adjust quality as needed (1-100)
                VectorRasterizationOptions = otgRasterizationOptions
            };

            // Save the image as a progressive JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}