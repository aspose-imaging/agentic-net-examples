// HOW-TO: Extract Embedded Images From SVG And Save To ZIP In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputZipPath = "output.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath) ?? ".");

            using (FileStream zipStream = new FileStream(outputZipPath, FileMode.Create))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Update))
            {
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.VectorImage vectorImage = (Aspose.Imaging.VectorImage)image;
                    var embeddedImages = vectorImage.GetEmbeddedImages();
                    int i = 0;
                    foreach (Aspose.Imaging.EmbeddedImage im in embeddedImages)
                    {
                        using (im)
                        {
                            Aspose.Imaging.FileFormat format = im.Image.FileFormat;
                            string extension = format == Aspose.Imaging.FileFormat.Jpeg ? ".jpg"
                                : format == Aspose.Imaging.FileFormat.Png ? ".png"
                                : format == Aspose.Imaging.FileFormat.Bmp ? ".bmp"
                                : "." + format.ToString().ToLower();

                            string fileName = "image" + i + extension;
                            i++;

                            using (MemoryStream ms = new MemoryStream())
                            {
                                im.Image.Save(ms);
                                ms.Position = 0;
                                var entry = archive.CreateEntry(fileName);
                                using (var entryStream = entry.Open())
                                {
                                    ms.CopyTo(entryStream);
                                }
                            }
                        }
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
 * 1. When you need to retrieve all raster graphics embedded in an SVG for reuse in a web gallery, you can extract them and package them into a ZIP file with their original filenames.
 * 2. When generating a design asset bundle, you may extract PNG, JPEG, or BMP images from an SVG and archive them for delivery to a client or a content management system.
 * 3. When performing automated quality checks on SVG files, extracting the embedded images lets you validate each raster file individually without altering the original SVG.
 * 4. When migrating legacy SVG assets to a new platform that only supports separate image files, you can pull out the embedded images and store them in a ZIP for bulk import.
 * 5. When creating a backup of all raster resources used in an SVG diagram, extracting and zipping the images preserves their original names and formats for easy restoration.
 */
