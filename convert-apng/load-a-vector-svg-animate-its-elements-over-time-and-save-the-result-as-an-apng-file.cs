// HOW-TO: Create Animated PNG From SVG With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputSvgPath = "input.svg";
            string outputApngPath = "output/output.apng";

            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));

            using (Image svgImg = Image.Load(inputSvgPath))
            {
                SvgImage svg = (SvgImage)svgImg;

                int frameCount = 10;
                int frameDelay = 100; // milliseconds per frame

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputApngPath, false),
                    DefaultFrameTime = (uint)frameDelay,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                int canvasWidth = 800;
                int canvasHeight = 600;

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, canvasWidth, canvasHeight))
                {
                    apng.RemoveAllFrames();

                    for (int i = 0; i < frameCount; i++)
                    {
                        using (RasterImage frame = (RasterImage)Image.Create(
                            new PngOptions { Source = new StreamSource(new MemoryStream()) },
                            canvasWidth,
                            canvasHeight))
                        {
                            Graphics g = new Graphics(frame);
                            g.Clear(Color.Transparent);
                            g.DrawImage(svg, new Point(0, 0));

                            int rectSize = 50;
                            int x = (int)((canvasWidth - rectSize) * (double)i / (frameCount - 1));
                            int y = canvasHeight / 2 - rectSize / 2;
                            Pen pen = new Pen(Color.Red, 3);
                            g.DrawRectangle(pen, new Rectangle(x, y, rectSize, rectSize));

                            apng.AddFrame(frame);
                        }
                    }

                    apng.Save();
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
 * 1. When a developer needs to convert a static SVG illustration into an animated PNG for web pages that support APNG.
 * 2. When an application must generate frame‑by‑frame animations from vector graphics for email newsletters without using GIF.
 * 3. When a reporting tool has to embed scalable vector icons that animate over time in PDF or HTML reports using APNG.
 * 4. When a game UI requires lightweight animated assets created from SVG sources at runtime in a C# backend.
 * 5. When a marketing platform automates the creation of banner ads that animate SVG logos and saves them as APNG for higher color depth and transparency.
 */
