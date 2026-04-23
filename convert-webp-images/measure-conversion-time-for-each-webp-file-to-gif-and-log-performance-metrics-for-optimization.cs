using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded directory containing the WebP files
        string dir = "c:\\temp\\";
        // List of WebP file names to convert
        string[] webpFiles = new string[]
        {
            "sample1.webp",
            "sample2.webp",
            "sample3.webp"
        };

        foreach (string fileName in webpFiles)
        {
            // Build full input and output paths
            string inputPath = dir + fileName;
            string outputPath = dir + Path.GetFileNameWithoutExtension(fileName) + ".gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Measure conversion time
            Stopwatch sw = Stopwatch.StartNew();

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save as GIF
                webPImage.Save(outputPath, new GifOptions());
            }

            sw.Stop();

            // Log performance metrics
            Console.WriteLine($"Converted '{fileName}' to GIF in {sw.ElapsedMilliseconds} ms. Output: {outputPath}");
        }
    }
}