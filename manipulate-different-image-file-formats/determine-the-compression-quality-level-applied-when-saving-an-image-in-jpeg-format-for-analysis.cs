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
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options
            JpegOptions jpegOptions = new JpegOptions
            {
                // Set desired compression quality (1-100)
                Quality = 85,

                // Optional: set progressive compression
                CompressionType = JpegCompressionMode.Progressive,

                // Optional: set bits per channel
                BitsPerChannel = 8
            };

            // Save the image as JPEG with the specified options
            image.Save(outputPath, jpegOptions);

            // Output the quality level used for analysis
            Console.WriteLine($"Image saved to '{outputPath}' with JPEG quality = {jpegOptions.Quality}");
        }
    }
}