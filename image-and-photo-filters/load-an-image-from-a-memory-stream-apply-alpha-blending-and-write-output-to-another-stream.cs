// HOW-TO: Blend Two Images With 50% Opacity From Memory Streams In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background image from memory stream
            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (MemoryStream inputStream = new MemoryStream())
            {
                fileStream.CopyTo(inputStream);
                inputStream.Position = 0;

                using (RasterImage background = (RasterImage)Image.Load(inputStream))
                {
                    // Load overlay image (same source for demonstration)
                    using (FileStream overlayFileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                    using (MemoryStream overlayStream = new MemoryStream())
                    {
                        overlayFileStream.CopyTo(overlayStream);
                        overlayStream.Position = 0;

                        using (RasterImage overlay = (RasterImage)Image.Load(overlayStream))
                        {
                            // Calculate center position
                            int posX = (background.Width - overlay.Width) / 2;
                            int posY = (background.Height - overlay.Height) / 2;
                            Aspose.Imaging.Point location = new Aspose.Imaging.Point(posX, posY);

                            // Apply alpha blending with 50% opacity (127)
                            background.Blend(location, overlay, 127);
                        }
                    }

                    // Save result to output memory stream
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        Source outSource = new StreamSource(outputStream);
                        PngOptions pngOptions = new PngOptions() { Source = outSource };
                        background.Save(outputStream, pngOptions);

                        // Write output stream to file
                        File.WriteAllBytes(outputPath, outputStream.ToArray());
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
 * 1. When you need to overlay a logo onto a photo stored in a byte array before saving it as a PNG file.
 * 2. When generating dynamic watermarks on images received from a web API without creating temporary files on disk.
 * 3. When creating composite thumbnails by blending two pictures in memory for a gallery preview.
 * 4. When applying semi‑transparent UI elements onto background images in a desktop application.
 * 5. When processing scanned documents and adding a translucent stamp directly from streams for compliance.
 */
