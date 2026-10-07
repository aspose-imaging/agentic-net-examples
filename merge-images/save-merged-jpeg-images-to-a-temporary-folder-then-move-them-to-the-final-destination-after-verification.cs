// HOW-TO: Merge Multiple JPEG Images to Temporary File Then Move to Final Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputImages";
            string tempFolder = "TempMerged";
            string finalFolder = "OutputImages";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(tempFolder);
            Directory.CreateDirectory(finalFolder);

            string[] inputFiles = Directory.GetFiles(inputFolder, "*.jpg")
                .Concat(Directory.GetFiles(inputFolder, "*.jpeg"))
                .ToArray();

            if (inputFiles.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in input folder.");
                return;
            }

            List<Size> sizes = new List<Size>();
            foreach (string file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            string tempOutputPath = Path.Combine(tempFolder, "merged.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempOutputPath));

            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = new FileCreateSource(tempOutputPath, false),
                Quality = 90
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string file in inputFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(file))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                canvas.Save();
            }

            if (!File.Exists(tempOutputPath))
            {
                Console.Error.WriteLine("Merged image was not created.");
                return;
            }

            string finalOutputPath = Path.Combine(finalFolder, "merged.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));

            if (File.Exists(finalOutputPath))
            {
                File.Delete(finalOutputPath);
            }

            File.Move(tempOutputPath, finalOutputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine a series of JPEG photos into a single wide image while ensuring the file is first created in a safe temporary location before being placed in the production output folder.
 * 2. When a batch image processing job must verify that all source JPEG files exist and are readable before generating a merged result and moving it to a final directory for downstream systems.
 * 3. When an automated reporting system creates a composite JPEG banner from individual pictures and wants to avoid partial files in the destination by writing to a temp folder first.
 * 4. When a web application assembles user‑uploaded JPEG thumbnails into a panoramic image and uses a temporary folder to prevent race conditions during the move to the public assets folder.
 * 5. When a scheduled task merges daily camera JPEG captures, stores the intermediate merged file in a temp directory for quality checks, then moves the verified image to the archive folder.
 */
