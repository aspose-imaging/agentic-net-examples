// HOW-TO: Batch Convert TIFF to PDF with Anti‑Aliasing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

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
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Enable smoothing for any drawing operations (high‑quality rendering)
                    Graphics graphics = new Graphics(tiffImage);
                    graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                    PdfOptions pdfOptions = new PdfOptions();
                    tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive a collection of scanned TIFF documents as high‑quality PDFs for long‑term storage.
 * 2. When you must generate printable PDFs from multi‑page TIFF files while preserving image clarity with anti‑aliasing.
 * 3. When an application processes batches of medical imaging TIFFs and requires smooth rendering before converting them to PDF reports.
 * 4. When a web service receives user‑uploaded TIFF images and must quickly convert them to PDF with enhanced visual quality.
 * 5. When automating the conversion of engineering drawings saved as TIFF into PDF for easy sharing and viewing in browsers.
 */
