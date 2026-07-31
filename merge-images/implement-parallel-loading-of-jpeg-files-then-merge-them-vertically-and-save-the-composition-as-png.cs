using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            var imageInfos = new List<(string Path, int Width, int Height)>();
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    continue;
                }

                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    imageInfos.Add((file, img.Width, img.Height));
                }
            }

            if (imageInfos.Count == 0)
            {
                Console.WriteLine("No valid JPEG images were loaded.");
                return;
            }

            int canvasWidth = imageInfos.Max(i => i.Width);
            int canvasHeight = imageInfos.Sum(i => i.Height);

            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (var info in imageInfos)
                {
                    using (RasterImage img = (RasterImage)Image.Load(info.Path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. When a web application needs to generate a single high‑resolution PNG sprite sheet from a collection of user‑uploaded JPEG photos for faster scrolling or printing, a developer can use this code to load the JPEGs in parallel, stack them vertically, and save the result as a PNG.
 * 2. When an e‑commerce platform wants to create a printable product catalog page by merging multiple product JPEG images into one vertically‑aligned PNG banner, the parallel loading and merging technique reduces processing time and ensures consistent output.
 * 3. When a digital signage system must combine several JPEG advertisements into a single vertical PNG slide that will be displayed on large screens, developers can employ this code to efficiently load the images concurrently and compose the final PNG.
 * 4. When a medical imaging workflow requires stitching a series of JPEG scan slices into a single PNG composite for analysis or archiving, the parallel image loading and vertical merge provided by Aspose.Imaging in C# speeds up the process.
 * 5. When a mobile app backend needs to batch‑process user‑submitted JPEG screenshots into a single PNG report image, using parallel loading and vertical composition helps handle many files quickly while preserving image quality.
 */