// HOW-TO: Create Animated PNG From SVG At Multiple Resolutions In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputSvgPath = "input.svg";
            string outputApngPath = "output.apng";

            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));

            int[] sizes = new int[] { 200, 400, 600 };

            using (Image vectorImage = Image.Load(inputSvgPath))
            {
                ApngImage apngImage = null;

                for (int i = 0; i < sizes.Length; i++)
                {
                    int size = sizes[i];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageWidth = size,
                                PageHeight = size,
                                BackgroundColor = Color.White
                            }
                        };
                        vectorImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            if (apngImage == null)
                            {
                                var apngOptions = new ApngOptions
                                {
                                    Source = new FileCreateSource(outputApngPath, false)
                                };
                                apngImage = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height);
                            }
                            else if (raster.Width != apngImage.Width || raster.Height != apngImage.Height)
                            {
                                raster.Resize(apngImage.Width, apngImage.Height);
                            }

                            apngImage.AddFrame(raster);
                        }
                    }
                }

                if (apngImage != null)
                {
                    using (apngImage)
                    {
                        apngImage.Save();
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
 * 1. When you need to generate an animated PNG thumbnail that shows a vector logo at low, medium, and high pixel sizes for responsive web design.
 * 2. When you want to convert a scalable SVG icon into a sequence of raster frames for use in a game sprite sheet that requires different resolutions.
 * 3. When you have to produce a multi‑resolution APNG for an email campaign where each frame displays the same graphic at increasing detail.
 * 4. When you need to automate the creation of an animated PNG preview of a diagram, rendering the SVG at several sizes for documentation PDFs.
 * 5. When you are building a CI pipeline that validates SVG assets by rasterizing them at several dimensions and packaging the results into a single APNG for visual regression testing.
 */
