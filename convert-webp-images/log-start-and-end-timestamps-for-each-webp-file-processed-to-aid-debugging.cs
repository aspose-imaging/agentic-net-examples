using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\sample1.webp",
                @"C:\Images\sample2.webp"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Images\output1.png",
                @"C:\Images\output2.png"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Log start timestamp
                Console.WriteLine($"Processing started: {inputPath} at {DateTime.Now:O}");

                // Load WebP image and save as PNG
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new PngOptions());
                }

                // Log end timestamp
                Console.WriteLine($"Processing finished: {inputPath} at {DateTime.Now:O}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}