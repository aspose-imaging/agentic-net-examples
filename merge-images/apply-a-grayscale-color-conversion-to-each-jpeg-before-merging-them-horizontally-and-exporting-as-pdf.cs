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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            var jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found.");
                return;
            }

            List<RasterImage> images = new List<RasterImage>();
            List<Size> sizes = new List<Size>();

            foreach (var file in jpegFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                RasterImage img = (RasterImage)Image.Load(file);
                var rci = img as RasterCachedImage;
                if (rci != null)
                {
                    if (!rci.IsCached) rci.CacheData();
                    rci.Grayscale();
                }
                else
                {
                    img.Grayscale();
                }

                images.Add(img);
                sizes.Add(img.Size);
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            string outputPath = Path.Combine(outputDirectory, "merged.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.Source = new FileCreateSource(outputPath, false);

            using (RasterImage canvas = (RasterImage)Image.Create(pdfOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var img in images)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }

                canvas.Save();
            }

            foreach (var img in images)
            {
                img.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}