using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

namespace WebPToPdfExample
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.webp";
            string outputPath = @"c:\temp\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save the image as PDF, preserving fidelity
                webPImage.Save(outputPath, new PdfOptions());
            }

            Console.WriteLine("Conversion completed successfully.");
        }
    }
}