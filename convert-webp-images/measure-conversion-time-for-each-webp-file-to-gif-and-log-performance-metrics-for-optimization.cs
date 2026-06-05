using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\temp\webp";
            string outputDir = @"C:\temp\gif";

            // List of WebP files to convert
            string[] webpFiles = new[]
            {
                "sample1.webp",
                "sample2.webp",
                "sample3.webp"
            };

            foreach (string fileName in webpFiles)
            {
                // Build full paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputFileName = Path.ChangeExtension(fileName, ".gif");
                string outputPath = Path.Combine(outputDir, outputFileName);

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

                // Load WebP image
                using (Image webpImage = Image.Load(inputPath))
                {
                    // Save as GIF
                    webpImage.Save(outputPath, new GifOptions());
                }

                sw.Stop();

                // Log performance metric
                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}' in {sw.ElapsedMilliseconds} ms.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}