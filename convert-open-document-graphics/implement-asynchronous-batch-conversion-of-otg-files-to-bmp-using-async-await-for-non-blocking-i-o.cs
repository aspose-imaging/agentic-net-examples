// HOW-TO: Asynchronously Convert Multiple OTG Files to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            string[] inputFiles = Directory.GetFiles(inputFolder, "*.otg");
            var tasks = new List<Task>();

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                tasks.Add(ProcessFileAsync(inputPath, outputPath));
            }

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ProcessFileAsync(string inputPath, string outputPath)
    {
        await Task.Run(() =>
        {
            using (Image image = Image.Load(inputPath))
            {
                var options = new BmpOptions();
                image.Save(outputPath, options);
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application must quickly convert a large batch of OTG vector graphics into BMP bitmaps without freezing the UI.
 * 2. When a server‑side service processes uploaded OTG files and needs to generate BMP thumbnails asynchronously to improve throughput.
 * 3. When an automated build pipeline includes image assets in OTG format and requires non‑blocking conversion to BMP for legacy tools.
 * 4. When a cloud function receives OTG files from a queue and must save them as BMP images while keeping the function responsive.
 * 5. When a background worker in a Windows service converts OTG diagrams to BMP for later printing or archival without blocking other tasks.
 */
