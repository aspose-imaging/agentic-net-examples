// HOW-TO: Measure Magic Wand Mask Generation Time for Different Image Sizes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] sizes = new int[] { 256, 512, 1024, 2048 };
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            foreach (int size in sizes)
            {
                string tempInputPath = Path.Combine(Path.GetTempPath(), $"temp_{size}.bmp");

                using (Image img = Image.Create(new BmpOptions { Source = new FileCreateSource(tempInputPath, false) }, size, size))
                {
                    img.Save();
                }

                if (!File.Exists(tempInputPath))
                {
                    Console.Error.WriteLine($"File not found: {tempInputPath}");
                    return;
                }

                using (RasterImage raster = (RasterImage)Image.Load(tempInputPath))
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    MagicWandTool.Select(raster, new MagicWandSettings(size / 2, size / 2))
                        .Apply();
                    sw.Stop();

                    string outputPath = Path.Combine(outputDir, $"masked_{size}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    raster.Save(outputPath, new BmpOptions());

                    Console.WriteLine($"Size {size}x{size}: {sw.ElapsedMilliseconds} ms");
                }

                if (File.Exists(tempInputPath))
                {
                    File.Delete(tempInputPath);
                }
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
 * 1. When you need to benchmark the performance of Aspose.Imaging's MagicWandTool on BMP images of various resolutions to ensure acceptable processing speed.
 * 2. When you want to automatically generate and save masks for dynamically created bitmap files in a temporary folder before further image analysis.
 * 3. When you are evaluating memory and CPU impact of mask creation on large raster images in a .NET application.
 * 4. When you need to compare processing times across multiple image sizes to decide the optimal resolution for a real‑time segmentation feature.
 * 5. When you are building a CI test that validates that MagicWandTool mask generation stays within a defined time threshold for different image dimensions.
 */
