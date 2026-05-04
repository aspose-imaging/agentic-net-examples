using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

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
                @"C:\Images\Output\sample1.gif",
                @"C:\Images\Output\sample2.gif"
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

                // Measure conversion time
                Stopwatch sw = Stopwatch.StartNew();

                // Load WebP image and save as GIF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new GifOptions());
                }

                sw.Stop();

                // Log performance metrics
                Console.WriteLine($"Converted '{Path.GetFileName(inputPath)}' to GIF in {sw.ElapsedMilliseconds} ms.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}