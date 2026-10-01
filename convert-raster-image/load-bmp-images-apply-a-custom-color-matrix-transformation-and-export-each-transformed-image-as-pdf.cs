// HOW-TO: Convert BMP Images to PDF with Custom Color Matrix in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.CacheData();

                    int width = raster.Width;
                    int height = raster.Height;
                    var rect = new Rectangle(0, 0, width, height);
                    int[] pixels = raster.LoadArgb32Pixels(rect);

                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int argb = pixels[i];
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;

                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;

                        pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }

                    raster.SaveArgb32Pixels(rect, pixels);

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
                    }
                }
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
 * 1. When you need to batch‑process scanned BMP documents, adjust their colors with a custom matrix, and generate searchable PDF reports in a C# application.
 * 2. When a legacy system stores graphics as BMP files and you must apply brand‑specific color grading before delivering them as PDFs to clients.
 * 3. When creating printable PDFs from BMP assets while programmatically correcting color balance or applying artistic filters using Aspose.Imaging in .NET.
 * 4. When automating the conversion of large collections of BMP images to PDF for archival, with a custom color transformation to meet compliance color standards.
 * 5. When integrating image‑to‑PDF conversion into a workflow that requires per‑pixel manipulation, such as converting medical BMP scans to PDF with a calibrated color matrix in C#.
 */
