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
            // Configure JPEG options for progressive encoding
            var jpegOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Progressive,
                Quality = 90 // Adjust quality as needed (1-100)
            };

            // Save the image as JPEG with the specified options
            image.Save(outputPath, jpegOptions);
        }
    }
}