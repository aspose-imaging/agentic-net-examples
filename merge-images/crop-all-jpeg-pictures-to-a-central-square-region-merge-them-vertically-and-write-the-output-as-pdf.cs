using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Setup input and output directories
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

        // Get all JPEG files
        string[] allFiles = Directory.GetFiles(inputDirectory, "*.*");
        List<string> jpegFiles = new List<string>();
        foreach (var f in allFiles)
        {
            string ext = Path.GetExtension(f).ToLowerInvariant();
            if (ext == ".jpg" || ext == ".jpeg")
                jpegFiles.Add(f);
        }

        if (jpegFiles.Count == 0)
        {
            Console.WriteLine("No JPEG files found in the input directory.");
            return;
        }

        // First pass: determine canvas size
        List<Size> sizes = new List<Size>();
        foreach (var inputPath in jpegFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage img = (RasterImage)Image.Load(inputPath))
            {
                if (!img.IsCached) img.CacheData();

                int side = Math.Min(img.Width, img.Height);
                sizes.Add(new Size(side, side));
            }
        }

        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Create canvas
        using (RasterImage canvas = (RasterImage)Image.Create(new JpegOptions(), canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            for (int i = 0; i < jpegFiles.Count; i++)
            {
                string inputPath = jpegFiles[i];
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    if (!img.IsCached) img.CacheData();

                    int side = Math.Min(img.Width, img.Height);
                    int x = (img.Width - side) / 2;
                    int y = (img.Height - side) / 2;
                    Rectangle cropRect = new Rectangle(x, y, side, side);
                    img.Crop(cropRect);

                    Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save as PDF
            string outputPdfPath = Path.Combine(outputDirectory, "merged.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                canvas.Save(outputPdfPath, pdfOptions);
            }
        }
    }
}