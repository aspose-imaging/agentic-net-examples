using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG files
        string[] inputPaths = new[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Hardcoded output PDF file
        string outputPath = "merged.pdf";

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Collect image sizes
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Size sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create a raster canvas (unbound)
        using (RasterImage canvas = (RasterImage)Image.Create(new JpegOptions(), totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PDF options with A4 page size (595x842 points at 72 DPI)
            PdfOptions pdfOptions = new PdfOptions
            {
                PageSize = new Size(595, 842)
            };

            // Save the merged image as PDF
            canvas.Save(outputPath, pdfOptions);
        }
    }
}