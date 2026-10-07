// HOW-TO: Flip JPEG Images Horizontally and Merge into a Single PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputPath = "Output/merged.png";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<string> imagePaths = new List<string>();
            List<int> widths = new List<int>();
            List<int> heights = new List<int>();

            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                imagePaths.Add(file);
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int totalWidth = widths.Sum();
            int maxHeight = heights.Max();

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                for (int i = 0; i < imagePaths.Count; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(imagePaths[i]))
                    {
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                canvas.Save();
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
 * 1. When you need to create a panoramic view from a set of portrait‑oriented JPEG photos that must be mirrored before stitching, this code flips each image and joins them side‑by‑side into a PNG.
 * 2. When generating product catalogs where each product photo must be displayed as a mirrored thumbnail next to the original, the routine flips the JPEGs and composes them horizontally for a single PNG sprite sheet.
 * 3. When preparing assets for a web carousel that requires all images to face the opposite direction and be combined into one lightweight PNG file, this solution automates the flip and merge process in C#.
 * 4. When building a reporting tool that visualizes before‑and‑after comparisons by mirroring source JPEGs and aligning them in a single row, the code produces the combined PNG output ready for embedding.
 * 5. When creating printable banners that need a series of horizontally flipped JPEG graphics arranged in a continuous strip, this example flips each image and merges them into a high‑resolution PNG canvas.
 */
