using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.cmx";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image with default load options
            using (Image image = Image.Load(inputPath, new CmxLoadOptions()))
            {
                // Configure JPEG save options for progressive encoding
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 90 // optional quality setting
                };

                // Save as progressive JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}