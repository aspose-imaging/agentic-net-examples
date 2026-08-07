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
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Gather JPEG files
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (inputFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string filePath in inputFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal composition
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Output file path
            string outputPath = Path.Combine(outputDirectory, "merged.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare PNG options with bound source
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create canvas and merge images side by side
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string filePath in inputFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(filePath))
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
 * 1. When a developer needs to generate a side‑by‑side preview of product photos that must be mirrored for a virtual dressing‑room, they can flip each JPEG horizontally, stitch them together, and save the result as a PNG.
 * 2. When creating a single banner image from a series of scanned receipts that require horizontal mirroring to protect sensitive data, the code can flip each JPEG, concatenate them horizontally, and output a PNG for web display.
 * 3. When building an automated pipeline that converts a collection of landscape JPEGs into a panoramic PNG for a travel blog, a developer can use this code to mirror each image, merge them side by side, and produce a web‑friendly PNG.
 * 4. When preparing mirrored sprite sheets for a 2‑D game, a developer can flip each character JPEG frame, arrange the frames in a horizontal strip, and export the combined image as a PNG for use in the game engine.
 * 5. When generating a printable contact sheet where each JPEG thumbnail must be mirrored to match a specific layout requirement, the code can horizontally flip the images, compose them side‑by‑side, and save the final composition as a high‑resolution PNG.
 */