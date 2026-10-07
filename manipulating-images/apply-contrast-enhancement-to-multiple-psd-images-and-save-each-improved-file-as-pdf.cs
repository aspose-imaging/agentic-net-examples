// HOW-TO: Enhance Contrast of PSD Files and Convert to PDF in C# (Aspose.Imaging for .NET)
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
                    continue;
                }

                if (!inputPath.EndsWith(".psd", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster != null)
                    {
                        if (!raster.IsCached)
                        {
                            raster.CacheData();
                        }
                        raster.AdjustContrast(0.5f);
                    }

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
 * 1. When you need to automatically improve the visual clarity of a batch of Photoshop PSD files before delivering them as PDF reports.
 * 2. When a web service must process uploaded PSD artwork, enhance its contrast, and store the result as a PDF for client preview.
 * 3. When an archival system requires converting legacy PSD images to PDF while applying contrast correction to ensure readability.
 * 4. When generating printable PDFs from PSD designs in a desktop application, and you want to boost contrast to meet printing standards.
 * 5. When automating a workflow that reads PSD files from a folder, adjusts their contrast for better on‑screen viewing, and saves each as a PDF for distribution.
 */
