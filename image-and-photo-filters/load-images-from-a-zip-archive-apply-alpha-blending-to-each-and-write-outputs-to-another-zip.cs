// HOW-TO: Alpha Blend Images From a ZIP and Export to Another ZIP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string outputZipPath = "output.zip";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath) ?? ".");

            using (FileStream zipToOpen = new FileStream(inputZipPath, FileMode.Open, FileAccess.Read))
            using (System.IO.Compression.ZipArchive inputArchive = new System.IO.Compression.ZipArchive(zipToOpen, System.IO.Compression.ZipArchiveMode.Read))
            using (FileStream outZipStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.ReadWrite))
            using (System.IO.Compression.ZipArchive outputArchive = new System.IO.Compression.ZipArchive(outZipStream, System.IO.Compression.ZipArchiveMode.Update))
            {
                foreach (var entry in inputArchive.Entries)
                {
                    string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".bmp" && ext != ".gif" && ext != ".webp" && ext != ".tif" && ext != ".tiff")
                        continue;

                    using (Stream entryStream = entry.Open())
                    using (RasterImage background = (RasterImage)Image.Load(entryStream))
                    {
                        string overlayPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".bmp");
                        Source overlaySource = new FileCreateSource(overlayPath, false);
                        BmpOptions overlayOptions = new BmpOptions() { Source = overlaySource };
                        using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, background.Width, background.Height))
                        {
                            int pixelCount = overlay.Width * overlay.Height;
                            Aspose.Imaging.Color fillColor = Aspose.Imaging.Color.FromArgb(255, 255, 0, 0);
                            int argb = fillColor.ToArgb();
                            int[] pixels = new int[pixelCount];
                            for (int i = 0; i < pixelCount; i++) pixels[i] = argb;
                            overlay.SaveArgb32Pixels(overlay.Bounds, pixels);

                            int offsetX = (background.Width - overlay.Width) / 2;
                            int offsetY = (background.Height - overlay.Height) / 2;
                            background.Blend(new Point(offsetX, offsetY), overlay, 127);
                        }
                        File.Delete(overlayPath);

                        ImageOptionsBase saveOptions;
                        switch (ext)
                        {
                            case ".jpg":
                            case ".jpeg":
                                saveOptions = new JpegOptions() { Quality = 90 };
                                break;
                            case ".png":
                                saveOptions = new PngOptions();
                                break;
                            case ".bmp":
                                saveOptions = new BmpOptions();
                                break;
                            case ".gif":
                                saveOptions = new GifOptions();
                                break;
                            case ".webp":
                                saveOptions = new WebPOptions();
                                break;
                            case ".tif":
                            case ".tiff":
                                saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                                break;
                            default:
                                saveOptions = new JpegOptions() { Quality = 90 };
                                break;
                        }

                        using (MemoryStream ms = new MemoryStream())
                        {
                            background.Save(ms, saveOptions);
                            ms.Position = 0;
                            var outEntry = outputArchive.CreateEntry(entry.Name);
                            using (Stream outEntryStream = outEntry.Open())
                            {
                                ms.CopyTo(outEntryStream);
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
 * 1. When you need to batch‑process a collection of photos stored in a zip file and apply a uniform transparency effect before distributing them.
 * 2. When an e‑commerce platform wants to add a watermark‑like overlay to all product images packaged in a zip archive without extracting each file manually.
 * 3. When a game developer prepares sprite sheets that require alpha blending and wants to automate the conversion directly from a zip of source assets.
 * 4. When a digital archiving system must normalize image opacity for compliance and store the processed files back into a compressed archive.
 * 5. When a cloud service receives user‑uploaded zip bundles of images and must apply a fade‑out effect before saving the results to another zip for downstream processing.
 */
