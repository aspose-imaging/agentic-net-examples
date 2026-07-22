using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var tasks = new List<(string input, string output, int pointX, int pointY)>
            {
                ("Images\\small.png", "Output\\small_masked.png", 10, 10),
                ("Images\\medium.png", "Output\\medium_masked.png", 50, 50),
                ("Images\\large.png", "Output\\large_masked.png", 100, 100)
            };

            foreach (var task in tasks)
            {
                string inputPath = task.input;
                string outputPath = task.output;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                DateTime start = DateTime.Now;

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool
                        .Select(image, new MagicWandSettings(task.pointX, task.pointY))
                        .Apply();

                    image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                DateTime end = DateTime.Now;
                TimeSpan duration = end - start;
                Console.WriteLine($"Processed {Path.GetFileName(inputPath)} in {duration.TotalMilliseconds} ms");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to benchmark how quickly the Aspose.Imaging MagicWandTool can generate PNG masks for small, medium, and large resolution images in a batch‑processing workflow.
 * 2. When a developer needs to measure the runtime impact of applying a Magic Wand selection on different image sizes before integrating the feature into a C# photo‑editing application.
 * 3. When a developer is evaluating the performance of MagicWandSettings‑based mask creation for PNG files with truecolor‑with‑alpha output in a cloud‑based image‑processing service.
 * 4. When a developer must compare processing times for Magic Wand mask generation across various image resolutions to optimize resource allocation on a server.
 * 5. When a developer is testing the end‑to‑end execution time of loading, selecting, applying, and saving masked images using Aspose.Imaging in a .NET automated test suite.
 */