using System;
using System.IO;
using System.Linq;
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

            foreach (var file in files)
            {
                string extension = Path.GetExtension(file).ToLowerInvariant();
                if (extension != ".tif" && extension != ".tiff")
                {
                    continue;
                }

                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Enable high-quality smoothing
                    Graphics graphics = new Graphics(image);
                    graphics.SmoothingMode = SmoothingMode.HighQuality;

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
 * 1. When a medical imaging system needs to convert batches of high‑resolution DICOM‑derived TIFF scans into searchable PDF reports while preserving smooth visual quality.
 * 2. When an archival workflow must transform scanned TIFF documents of historical manuscripts into PDF files with anti‑aliasing to ensure legible, high‑quality reproductions.
 * 3. When a publishing pipeline processes large sets of TIFF artwork files and generates print‑ready PDFs with high‑quality smoothing to avoid jagged edges.
 * 4. When a construction firm automates the conversion of site‑plan TIFF images into PDF blueprints, applying high‑quality smoothing for clearer line work.
 * 5. When a legal office batch‑converts TIFF‑based evidence photos into PDFs, using high‑quality smoothing to maintain image fidelity for courtroom presentation.
 */