// HOW-TO: Batch Crop Rotate and Resize Images in a Folder Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;

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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string extension = Path.GetExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_processed" + extension);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage rasterImage)
                    {
                        if (!rasterImage.IsCached)
                        {
                            rasterImage.CacheData();
                        }

                        // Crop 50 pixels from each side if possible
                        int cropLeft = 50;
                        int cropTop = 50;
                        int cropRight = 50;
                        int cropBottom = 50;
                        int newWidth = rasterImage.Width - cropLeft - cropRight;
                        int newHeight = rasterImage.Height - cropTop - cropBottom;

                        if (newWidth > 0 && newHeight > 0)
                        {
                            Rectangle cropRect = new Rectangle(cropLeft, cropTop, newWidth, newHeight);
                            rasterImage.Crop(cropRect);
                        }

                        // Rotate 90 degrees clockwise with white background
                        rasterImage.Rotate(90f, true, Color.White);

                        // Resize to half of current dimensions
                        int resizeWidth = rasterImage.Width / 2;
                        int resizeHeight = rasterImage.Height / 2;
                        rasterImage.Resize(resizeWidth, resizeHeight, ResizeType.NearestNeighbourResample);

                        rasterImage.Save(outputPath);
                    }
                    else
                    {
                        // For non‑raster images, simply save a copy
                        image.Save(outputPath);
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
 * 1. When you need to automatically trim borders, rotate, and resize dozens of JPEG or PNG photos stored in a folder before uploading them to a web gallery.
 * 2. When a document management system must preprocess scanned TIFF files by cropping edges, aligning orientation, and scaling them to a standard size during import.
 * 3. When an e‑commerce platform wants to generate uniformly sized product thumbnails from a batch of high‑resolution images on the server side.
 * 4. When a mobile app backend has to prepare user‑submitted images by removing unwanted margins, correcting rotation, and reducing dimensions to meet API size limits.
 * 5. When a reporting tool requires batch conversion of raw camera RAW files into smaller, correctly oriented PNGs for inclusion in PDF reports.
 */
