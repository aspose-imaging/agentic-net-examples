// HOW-TO: Create JPEG Thumbnails for All Images in a Folder Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    public static void Main(string[] args)
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

            string thumbDirectory = Path.Combine(outputDirectory, "Thumbnails");
            Directory.CreateDirectory(thumbDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string ext = Path.GetExtension(filePath).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg")
                {
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(thumbDirectory, fileName + "_thumb.jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (JpegImage image = (JpegImage)Aspose.Imaging.Image.Load(filePath))
                {
                    const int maxThumbWidth = 150;
                    const int maxThumbHeight = 150;
                    double ratio = Math.Min((double)maxThumbWidth / image.Width, (double)maxThumbHeight / image.Height);
                    int thumbWidth = (int)(image.Width * ratio);
                    int thumbHeight = (int)(image.Height * ratio);
                    if (thumbWidth == 0) thumbWidth = 1;
                    if (thumbHeight == 0) thumbHeight = 1;

                    image.Resize(thumbWidth, thumbHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                    JpegOptions options = new JpegOptions();
                    options.Quality = 80;
                    image.Save(outputPath, options);
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
 * 1. When you need to generate small preview images for a large collection of JPEG photos before uploading them to a web gallery.
 * 2. When an e‑commerce site must create uniform product thumbnail images from high‑resolution JPEG files stored in a directory.
 * 3. When a desktop application has to prepare thumbnail versions of user‑supplied JPEG pictures for faster display in a file‑browser view.
 * 4. When an automated script must resize uploaded JPEG attachments to a fixed 150 × 150 size for email newsletters.
 * 5. When a migration tool has to batch‑process existing JPEG assets and store the thumbnails in a separate “Thumbnails” subfolder for downstream processing.
 */
