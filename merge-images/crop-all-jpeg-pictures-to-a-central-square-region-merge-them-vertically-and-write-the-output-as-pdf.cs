using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Batch directory setup (atomic block as required)
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

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        // Filter JPEG files
        List<string> jpegFiles = new List<string>();
        foreach (string f in files)
        {
            string ext = Path.GetExtension(f).ToLowerInvariant();
            if (ext == ".jpg" || ext == ".jpeg")
            {
                jpegFiles.Add(f);
            }
        }

        if (jpegFiles.Count == 0)
        {
            Console.WriteLine("No JPEG files found in the Input directory.");
            return;
        }

        // Load, crop to central square, and collect sizes
        List<Aspose.Imaging.RasterImage> croppedImages = new List<Aspose.Imaging.RasterImage>();
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();

        foreach (string path in jpegFiles)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }

            Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path);
            if (!img.IsCached) img.CacheData();

            int square = Math.Min(img.Width, img.Height);
            int offsetX = (img.Width - square) / 2;
            int offsetY = (img.Height - square) / 2;
            Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(offsetX, offsetY, square, square);
            img.Crop(cropRect);

            croppedImages.Add(img);
            sizes.Add(new Aspose.Imaging.Size(square, square));
        }

        // Calculate canvas size for vertical merge
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Create unbound canvas (no source) using JpegOptions (any raster format works)
        JpegOptions canvasOptions = new JpegOptions();
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(canvasOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (var img in croppedImages)
            {
                Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                offsetY += img.Height;
            }

            // Prepare output PDF path
            string outputPath = Path.Combine(outputDirectory, "Merged.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save canvas as PDF
            PdfOptions pdfOptions = new PdfOptions();
            canvas.Save(outputPath, pdfOptions);
        }

        // Dispose loaded images
        foreach (var img in croppedImages)
        {
            img.Dispose();
        }
    }
}