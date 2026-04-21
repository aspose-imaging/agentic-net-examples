using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify that the input file exists
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
            // Configure OTG rasterization options
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                // Preserve original size; adjust as needed
                PageSize = image.Size
            };

            // Configure JPEG save options, including compression quality
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 80, // Compression level (1-100)
                CompressionType = JpegCompressionMode.Progressive,
                VectorRasterizationOptions = otgOptions
            };

            // Save the image as JPEG using the configured options
            image.Save(outputPath, jpegOptions);
        }
    }
}