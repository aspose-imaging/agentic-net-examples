// HOW-TO: Benchmark Time to Create Magic Wand Masks on Different Resolution PNGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths for images of different resolutions
        string[] inputPaths = new string[]
        {
            @"C:\Benchmark\Images\low_res.png",
            @"C:\Benchmark\Images\medium_res.png",
            @"C:\Benchmark\Images\high_res.png"
        };

        string[] outputPaths = new string[]
        {
            @"C:\Benchmark\Results\low_res_masked.png",
            @"C:\Benchmark\Results\medium_res_masked.png",
            @"C:\Benchmark\Results\high_res_masked.png"
        };

        try
        {
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

                // Measure time to generate mask and save the image
                Stopwatch sw = Stopwatch.StartNew();

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Create a mask using MagicWandTool with a reference point (10,10) and a threshold
                    var mask = MagicWandTool.Select(image, new MagicWandSettings(10, 10) { Threshold = 100 });

                    // Apply the mask to the image
                    mask.Apply();

                    // Save the resulting image with alpha channel support
                    image.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }

                sw.Stop();
                Console.WriteLine($"Processed '{Path.GetFileName(inputPath)}' in {sw.ElapsedMilliseconds} ms");
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
 * 1. When you need to compare how quickly the MagicWandTool can generate masks for low, medium, and high‑resolution PNG images in a C# application.
 * 2. When you want to profile the performance impact of applying a mask with a threshold on large raster images before integrating the feature into a photo‑editing workflow.
 * 3. When you are optimizing batch image processing and need to ensure that mask creation and saving with alpha channel stays within acceptable time limits for different image sizes.
 * 4. When you are troubleshooting slow image‑masking operations and require precise timing data to identify bottlenecks in the Aspose.Imaging MagicWand implementation.
 * 5. When you are building a benchmark suite to demonstrate the scalability of Aspose.Imaging’s MagicWandTool across various resolutions for documentation or client presentations.
 */
