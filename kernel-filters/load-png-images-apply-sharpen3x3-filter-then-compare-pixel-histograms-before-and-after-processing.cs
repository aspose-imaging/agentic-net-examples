using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

                int[] histR = new int[256];
                int[] histG = new int[256];
                int[] histB = new int[256];

                foreach (int pixel in pixels)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    histR[r]++;
                    histG[g]++;
                    histB[b]++;
                }

                Console.WriteLine("Original Histogram (Red channel):");
                for (int i = 0; i < 256; i++)
                {
                    if (histR[i] > 0)
                        Console.WriteLine($"{i}: {histR[i]}");
                }

                Console.WriteLine("Original Histogram (Green channel):");
                for (int i = 0; i < 256; i++)
                {
                    if (histG[i] > 0)
                        Console.WriteLine($"{i}: {histG[i]}");
                }

                Console.WriteLine("Original Histogram (Blue channel):");
                for (int i = 0; i < 256; i++)
                {
                    if (histB[i] > 0)
                        Console.WriteLine($"{i}: {histB[i]}");
                }

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to sharpen scanned PNG documents such as receipts or blueprints and verify that the visual enhancement does not alter the original color distribution by comparing pre‑ and post‑processing histograms.
 * 2. When building an automated quality‑control pipeline for a photo‑sharing app that applies a Sharpen3x3 filter to user‑uploaded PNG images and logs histogram changes to detect over‑sharpening artifacts.
 * 3. When creating a batch‑processing tool for e‑commerce product catalogs where each PNG is sharpened with a 3×3 kernel and the channel histograms are compared to ensure consistent color balance across all images.
 * 4. When developing a medical imaging viewer that sharpens PNG radiology scans and compares the original and sharpened histograms to confirm diagnostic details are enhanced without distorting intensity levels.
 * 5. When implementing a machine‑learning preprocessing step that sharpens PNG training samples and records original versus sharpened histograms to analyze the impact of sharpening on feature extraction.
 */