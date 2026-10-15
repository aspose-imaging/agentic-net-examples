// HOW-TO: Merge JPEG Images Horizontally Into PDFs For Each Folder In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

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

            string[] folders = Directory.GetDirectories(inputDirectory);
            foreach (string folder in folders)
            {
                string[] jpgFiles = Directory.GetFiles(folder, "*.jpg");
                string[] jpegFiles = Directory.GetFiles(folder, "*.jpeg");
                string[] imageFiles = jpgFiles.Concat(jpegFiles).ToArray();

                if (imageFiles.Length == 0)
                {
                    continue;
                }

                List<(int Width, int Height)> sizes = new List<(int, int)>();
                foreach (string imgPath in imageFiles)
                {
                    if (!File.Exists(imgPath))
                    {
                        Console.Error.WriteLine($"File not found: {imgPath}");
                        return;
                    }
                    using (RasterImage img = (RasterImage)Image.Load(imgPath))
                    {
                        sizes.Add((img.Width, img.Height));
                    }
                }

                int totalWidth = sizes.Sum(s => s.Width);
                int maxHeight = sizes.Max(s => s.Height);

                JpegOptions canvasOptions = new JpegOptions();
                using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, totalWidth, maxHeight))
                {
                    int offsetX = 0;
                    foreach (string imgPath in imageFiles)
                    {
                        if (!File.Exists(imgPath))
                        {
                            Console.Error.WriteLine($"File not found: {imgPath}");
                            return;
                        }
                        using (RasterImage img = (RasterImage)Image.Load(imgPath))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }

                    string folderName = Path.GetFileName(folder);
                    string outputPath = Path.Combine(outputDirectory, folderName + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    PdfOptions pdfOptions = new PdfOptions();
                    canvas.Save(outputPath, pdfOptions);
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
 * 1. When you need to create a single PDF page that shows all photos from a product shoot side‑by‑side for quick review.
 * 2. When an e‑commerce platform must generate printable catalogs by stitching together all JPEGs in each category folder into one PDF per category.
 * 3. When a legal firm wants to combine scanned JPEG evidence files from separate case folders into horizontal PDFs for easier courtroom presentation.
 * 4. When a marketing team automates the creation of banner‑style PDFs from daily photo batches stored in different project directories.
 * 5. When a photo‑archiving script must batch‑process multiple event folders, merging their images into a single PDF per event for archival storage.
 */
