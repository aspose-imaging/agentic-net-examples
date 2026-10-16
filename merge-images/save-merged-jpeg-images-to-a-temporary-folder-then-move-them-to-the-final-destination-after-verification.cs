// HOW-TO: Merge Multiple JPEG Images Horizontally and Save via Temporary Folder in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "Input";
            string tempFolder = "Temp";
            string outputFolder = "Output";
            string outputFileName = "merged.jpg";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(tempFolder);
            Directory.CreateDirectory(outputFolder);

            List<string> imagePaths = Directory.GetFiles(inputFolder, "*.jpg")
                .Concat(Directory.GetFiles(inputFolder, "*.jpeg"))
                .ToList();

            if (imagePaths.Count == 0)
            {
                Console.Error.WriteLine("No JPEG images found in input folder.");
                return;
            }

            int totalWidth = 0;
            int maxHeight = 0;

            foreach (string path in imagePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    totalWidth += img.Width;
                    if (img.Height > maxHeight)
                        maxHeight = img.Height;
                }
            }

            string tempPath = Path.Combine(tempFolder, outputFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            Source source = new FileCreateSource(tempPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string path in imagePaths)
                {
                    using (JpegImage img = (JpegImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                canvas.Save();
            }

            if (!File.Exists(tempPath))
            {
                Console.Error.WriteLine("Merged image was not created.");
                return;
            }

            string finalPath = Path.Combine(outputFolder, outputFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(finalPath));
            if (File.Exists(finalPath))
                File.Delete(finalPath);
            File.Move(tempPath, finalPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine a series of product photos into a single panoramic JPEG for an e‑commerce catalog while ensuring the file is written to a safe temporary location before publishing.
 * 2. When a web service must stitch user‑uploaded JPEG screenshots side‑by‑side and store the intermediate result in a temp folder to validate size or content before moving it to the final output directory.
 * 3. When an automated report generator creates a composite image of chart snapshots and wants to use Aspose.Imaging to merge them horizontally, saving first to a temporary path to allow rollback on failure.
 * 4. When a batch image processing job processes thousands of JPEG files, merges them into a single wide image, and uses a temporary folder to avoid partial files appearing in the production folder during processing.
 * 5. When a desktop application needs to verify that all source JPEG files exist and are readable before creating a merged image, writing the result to a temp directory to perform integrity checks before moving it to the user‑specified output folder.
 */
