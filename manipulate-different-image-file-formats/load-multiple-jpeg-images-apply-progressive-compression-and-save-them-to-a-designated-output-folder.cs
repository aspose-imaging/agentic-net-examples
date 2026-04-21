using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        // List of JPEG files to process
        string[] files = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        foreach (var fileName in files)
        {
            // Build full input path and verify existence
            string inputPath = Path.Combine(inputDir, fileName);
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build full output path and ensure its directory exists
            string outputPath = Path.Combine(outputDir, fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure progressive JPEG save options
                JpegOptions saveOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 100 // optional quality setting
                };

                // Save the image with progressive compression
                image.Save(outputPath, saveOptions);
            }
        }
    }
}