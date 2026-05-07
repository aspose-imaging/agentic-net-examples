using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample_95.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure JPEG save options with 95% quality
            JpegOptions saveOptions = new JpegOptions
            {
                Quality = 95,
                BitsPerChannel = 8,
                CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive
            };

            // Load the source image and save as JPEG
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}