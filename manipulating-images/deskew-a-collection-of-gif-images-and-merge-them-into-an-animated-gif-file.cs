// HOW-TO: Deskew Multiple GIF Images and Create Animated GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input GIF paths
            string[] inputPaths = { "input1.gif", "input2.gif", "input3.gif" };
            // Hardcoded output GIF path
            string outputPath = "output.gif";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load first image to determine canvas size
            using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
            {
                if (!firstImage.IsCached) firstImage.CacheData();
                firstImage.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);
                int canvasWidth = firstImage.Width;
                int canvasHeight = firstImage.Height;

                GifOptions gifOptions = new GifOptions();

                using (GifImage outputGif = (GifImage)Image.Create(gifOptions, canvasWidth, canvasHeight))
                {
                    // Add first frame
                    outputGif.AddPage(firstImage);

                    // Process remaining images
                    for (int i = 1; i < inputPaths.Length; i++)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                        {
                            if (!img.IsCached) img.CacheData();
                            img.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);
                            outputGif.AddPage(img);
                        }
                    }

                    // Ensure output directory exists
                    string outputDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Save animated GIF
                    outputGif.Save(outputPath, gifOptions);
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
 * 1. When you need to correct the rotation of scanned GIF frames and combine them into a single animated GIF for a web slideshow.
 * 2. When building a C# application that processes user‑uploaded GIF photos, straightens each image, and outputs an animated preview.
 * 3. When automating the creation of animated GIF banners from a series of misaligned product images in an e‑commerce platform.
 * 4. When generating time‑lapse animations from security camera GIF snapshots that require deskewing before merging.
 * 5. When developing a reporting tool that consolidates multiple rotated GIF charts into a single animated GIF for easy distribution.
 */
