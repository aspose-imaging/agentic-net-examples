using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in input directory.");
                return;
            }

            // First pass: determine canvas dimensions based on central square size of each image
            List<(int Width, int Height)> squareSizes = new List<(int, int)>();
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    if (!img.IsCached) img.CacheData();

                    int side = Math.Min(img.Width, img.Height);
                    squareSizes.Add((side, side));
                }
            }

            int canvasWidth = squareSizes.Max(s => s.Width);
            int canvasHeight = squareSizes.Sum(s => s.Height);

            // Create an in‑memory canvas (PNG) to hold the merged image
            using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string file in files)
                {
                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        return;
                    }

                    using (JpegImage img = (JpegImage)Image.Load(file))
                    {
                        if (!img.IsCached) img.CacheData();

                        int side = Math.Min(img.Width, img.Height);
                        int cropX = (img.Width - side) / 2;
                        int cropY = (img.Height - side) / 2;
                        Rectangle cropRect = new Rectangle(cropX, cropY, side, side);
                        img.Crop(cropRect);

                        Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                        offsetY += img.Height;
                    }
                }

                string outputPath = Path.Combine(outputDirectory, "Merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    canvas.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}