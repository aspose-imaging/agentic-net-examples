using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

namespace WebPToPngConverter
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\test.webp";
            string outputPath = @"C:\temp\test.output.png";

            // Verify that the input WebP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image and save it as PNG
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save only the active frame to PNG
                webPImage.Save(outputPath, new PngOptions());
            }
        }
    }
}