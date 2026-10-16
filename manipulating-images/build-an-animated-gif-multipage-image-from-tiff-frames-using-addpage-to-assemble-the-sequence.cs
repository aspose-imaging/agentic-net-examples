// HOW-TO: Create Animated GIF From Multiple TIFF Frames Using AddPage In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input TIFF frame paths
            string tiffPath1 = "frame1.tif";
            string tiffPath2 = "frame2.tif";
            string tiffPath3 = "frame3.tif";

            // Verify input files exist
            if (!File.Exists(tiffPath1))
            {
                Console.Error.WriteLine($"File not found: {tiffPath1}");
                return;
            }
            if (!File.Exists(tiffPath2))
            {
                Console.Error.WriteLine($"File not found: {tiffPath2}");
                return;
            }
            if (!File.Exists(tiffPath3))
            {
                Console.Error.WriteLine($"File not found: {tiffPath3}");
                return;
            }

            // Output GIF path
            string outputPath = "output/animated.gif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load first TIFF frame to obtain dimensions
            using (TiffImage firstTiff = (TiffImage)Image.Load(tiffPath1))
            {
                int width = firstTiff.Width;
                int height = firstTiff.Height;

                // Create empty GIF with dimensions of first frame
                GifOptions gifOptions = new GifOptions();
                using (Image gifImage = Image.Create(gifOptions, width, height))
                {
                    GifImage gif = (GifImage)gifImage;

                    // Set pixels of the first frame from the first TIFF
                    Color[] firstPixels = ((RasterImage)firstTiff).LoadPixels(firstTiff.Bounds);
                    int[] firstArgb = firstPixels.Select(c => c.ToArgb()).ToArray();
                    gif.SaveArgb32Pixels(gif.Bounds, firstArgb);

                    // Add remaining TIFF frames as pages
                    string[] additionalTiffPaths = new string[] { tiffPath2, tiffPath3 };
                    foreach (string tiffPath in additionalTiffPaths)
                    {
                        using (TiffImage tiff = (TiffImage)Image.Load(tiffPath))
                        {
                            // Ensure frame size matches GIF canvas; resize if necessary
                            if (tiff.Width != width || tiff.Height != height)
                            {
                                tiff.Resize(width, height, ResizeType.NearestNeighbourResample);
                            }
                            gif.AddPage(tiff);
                        }
                    }

                    // Save the animated GIF
                    gif.Save(outputPath, gifOptions);
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
 * 1. When you need to convert a series of scanned TIFF pages into a single animated GIF for quick web preview.
 * 2. When you want to generate a lightweight looping animation from high‑resolution TIFF medical images for inclusion in a diagnostic report.
 * 3. When you have separate TIFF layers that represent video frames and must assemble them into an animated GIF to send as an email attachment.
 * 4. When you need to programmatically create an animated GIF from TIFF screenshots to embed in a software tutorial or help file.
 * 5. When you must batch‑process TIFF assets and output an animated GIF for display on digital signage or kiosks.
 */
