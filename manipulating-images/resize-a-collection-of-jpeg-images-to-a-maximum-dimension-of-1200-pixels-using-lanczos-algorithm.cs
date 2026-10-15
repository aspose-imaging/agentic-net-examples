// HOW-TO: Resize Multiple JPEG Images to Max 1200 Pixels Using Lanczos in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] patterns = new[] { "*.jpg", "*.jpeg" };
            foreach (string pattern in patterns)
            {
                foreach (string inputPath in Directory.GetFiles(inputDirectory, pattern))
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        int newWidth = image.Width;
                        int newHeight = image.Height;

                        if (image.Width >= image.Height)
                        {
                            if (image.Width > 1200)
                            {
                                newWidth = 1200;
                                newHeight = (int)((double)image.Height * 1200 / image.Width);
                            }
                        }
                        else
                        {
                            if (image.Height > 1200)
                            {
                                newHeight = 1200;
                                newWidth = (int)((double)image.Width * 1200 / image.Height);
                            }
                        }

                        if (newWidth != image.Width || newHeight != image.Height)
                        {
                            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                        }

                        JpegOptions options = new JpegOptions();
                        options.Source = new FileCreateSource(outputPath, false);
                        image.Save(outputPath, options);
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
 * 1. When you need to prepare a batch of user‑uploaded JPEG photos for a web gallery so that no image exceeds 1200 px while preserving quality with Lanczos resampling.
 * 2. When an e‑commerce platform must automatically downsize product photos to a maximum dimension before storing them in a CDN to reduce bandwidth.
 * 3. When a mobile app backend processes incoming JPEG attachments and must ensure they fit within a 1200 px limit for faster download on low‑speed connections.
 * 4. When a digital asset management system requires periodic resizing of legacy JPEG files to a uniform size for consistent thumbnail generation.
 * 5. When a photo‑printing service needs to validate and resize customer‑submitted JPEG images to a 1200 px maximum before applying further image‑processing steps.
 */
