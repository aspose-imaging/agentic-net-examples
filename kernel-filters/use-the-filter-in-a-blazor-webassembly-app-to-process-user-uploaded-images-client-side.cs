using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

namespace AsposeImagingBlazorFilter
{
    public class Program
    {
        // Entry point for the processing logic
        public static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.webp";
            string outputPath = @"c:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image using Aspose.Imaging's constructor (load rule)
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save the image as PNG using Aspose.Imaging's Save method (save rule)
                webPImage.Save(outputPath, new PngOptions());
            }
        }
    }
}