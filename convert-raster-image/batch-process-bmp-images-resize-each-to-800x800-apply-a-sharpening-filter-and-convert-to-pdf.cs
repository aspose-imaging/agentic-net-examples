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

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPdfPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    raster.Resize(800, 800);

                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                    raster.Save(outputPdfPath, new PdfOptions());
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
 * 1. When a developer needs to convert a folder of legacy BMP scans into searchable PDF documents while standardizing each page to an 800 × 800 pixel size and enhancing detail with a sharpening filter.
 * 2. When an e‑commerce platform must automatically process product photo BMP uploads, resize them to a uniform 800 × 800 resolution, apply sharpening for clearer visuals, and store the results as PDF catalogs.
 * 3. When a medical imaging system requires batch preparation of BMP radiology images for archival, resizing them to a consistent size, sharpening to improve diagnostic clarity, and saving them as PDF reports.
 * 4. When a publishing workflow needs to transform a collection of BMP illustrations into print‑ready PDFs, ensuring each image is resized to 800 × 800 pixels and sharpened to maintain line crispness.
 * 5. When a document management solution must ingest BMP files from scanners, uniformly resize and sharpen them, and convert them to PDF for easy viewing and indexing.
 */