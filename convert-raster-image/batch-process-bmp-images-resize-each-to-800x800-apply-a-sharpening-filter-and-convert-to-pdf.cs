// HOW-TO: Batch Resize BMP to 800x800, Sharpen and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                // Process only BMP files
                if (!inputPath.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Ensure we are working with a raster image
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached)
                        raster.CacheData();

                    // Apply sharpening filter to the whole image
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                    // Resize to 800x800
                    raster.Resize(800, 800);

                    // Save as PDF
                    raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to automatically generate printable PDFs from a folder of scanned BMP photos, resizing them to a standard page size and enhancing details.
 * 2. When a web service must preprocess user‑uploaded BMP icons by scaling them to 800 × 800 pixels, applying a sharpening filter, and storing them as PDFs for archival.
 * 3. When a batch job has to prepare BMP graphics for inclusion in a PDF report, ensuring consistent dimensions and improved clarity without manual editing.
 * 4. When migrating legacy BMP assets to a PDF‑based documentation system, you want to automate resizing, sharpening, and format conversion in C#.
 * 5. When creating a command‑line tool that processes multiple BMP files at once, applying a sharpen filter and converting each to a PDF for distribution to clients.
 */
