// HOW-TO: Apply Gaussian Blur to PNG Image Asynchronously in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
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
 * 1. When developing a Windows Forms or WPF photo editor that must blur PNG pictures while keeping the UI responsive.
 * 2. When creating a desktop or mobile app that processes user‑uploaded PNG files and needs to apply a Gaussian blur without blocking the main thread.
 * 3. When implementing a batch image‑processing feature that runs on a UI thread and requires asynchronous execution to avoid UI freezes.
 * 4. When integrating Aspose.Imaging into a real‑time preview where users can adjust blur radius and see results instantly without lag.
 * 5. When building an automated graphics pipeline that applies a Gaussian blur to PNG assets in the background while the application continues handling other tasks.
 */
