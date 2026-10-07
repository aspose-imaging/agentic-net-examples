// HOW-TO: Create Rotating SVG Animation and Export as APNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width, height;
            using (Image svg = Image.Load(inputPath))
            {
                width = svg.Width;
                height = svg.Height;
            }

            int frameCount = 36;
            double angleStep = 360.0 / frameCount;

            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100
            };

            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
            {
                apng.RemoveAllFrames();

                for (int i = 0; i < frameCount; i++)
                {
                    double angle = i * angleStep;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (Image tempSvg = Image.Load(inputPath))
                        {
                            tempSvg.Save(ms, new PngOptions
                            {
                                VectorRasterizationOptions = new SvgRasterizationOptions
                                {
                                    PageWidth = width,
                                    PageHeight = height,
                                    BackgroundColor = Color.White
                                }
                            });
                        }

                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            raster.Rotate((float)angle, true, Color.White);
                            apng.AddFrame(raster);
                        }
                    }
                }

                apng.Save();
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
 * 1. When you need to turn a static SVG logo into a continuously rotating animated PNG for use in a website header.
 * 2. When you want to generate a series of frames that show a vector illustration spinning, then combine them into an APNG for inclusion in mobile app splash screens.
 * 3. When you have to automate the creation of rotating product previews from SVG files to embed in email newsletters without relying on JavaScript.
 * 4. When you are building a game and require a lightweight, loss‑less animated sprite created from a vector asset, using C# and Aspose.Imaging.
 * 5. When you must batch‑process multiple SVG icons into looping APNG animations for a UI component library, ensuring consistent size and background color.
 */
