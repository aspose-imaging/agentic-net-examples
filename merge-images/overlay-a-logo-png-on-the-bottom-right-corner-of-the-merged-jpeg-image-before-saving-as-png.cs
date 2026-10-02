// HOW-TO: Merge Multiple JPEGs and Add Bottom Right Logo PNG in C# (Aspose.Imaging for .NET)
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
            string logoPath = "logo.png";
            string outputPath = "Output/merged.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles2 = Directory.GetFiles(inputDirectory, "*.jpeg");
            var allFiles = jpegFiles.Concat(jpegFiles2).ToArray();

            if (allFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found.");
                return;
            }

            foreach (var file in allFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            List<Size> sizes = new List<Size>();
            foreach (var file in allFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (var file in allFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(file))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    int posX = canvas.Width - logo.Width;
                    int posY = canvas.Height - logo.Height;
                    Rectangle logoBounds = new Rectangle(posX, posY, logo.Width, logo.Height);
                    canvas.SaveArgb32Pixels(logoBounds, logo.LoadArgb32Pixels(logo.Bounds));
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
 * 1. When you need to combine several product JPEG photos into a single banner and brand it with a bottom‑right PNG logo using C#.
 * 2. When creating a printable catalog page that stitches high‑resolution JPEG images together and adds a transparent PNG watermark logo at the corner.
 * 3. When generating a composite image for a web slideshow where all source JPEGs are merged and a PNG logo is overlaid for copyright protection.
 * 4. When automating the preparation of marketing assets that require merging client‑provided JPEGs and adding a partner PNG logo before publishing as a PNG file.
 * 5. When building a batch process that consolidates scanned JPEG documents into one image and stamps a PNG logo for document tracking.
 */
