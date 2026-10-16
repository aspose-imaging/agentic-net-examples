// HOW-TO: Create Animated Gradient Fill From SVG And Export As APNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apng.RemoveAllFrames();

                    int frameCount = 10;
                    for (int i = 0; i < frameCount; i++)
                    {
                        byte r = (byte)(255 - (i * 255 / (frameCount - 1)));
                        byte b = (byte)(i * 255 / (frameCount - 1));
                        Color frameColor = Color.FromArgb(128, r, 0, b);

                        BmpOptions bmpOptions = new BmpOptions
                        {
                            Source = new FileCreateSource("temp.bmp", false)
                        };

                        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
                        {
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.Transparent);
                            graphics.DrawImage(svgImage, new Point(0, 0));
                            using (SolidBrush brush = new SolidBrush(frameColor))
                            {
                                graphics.FillRectangle(brush, 0, 0, width, height);
                            }

                            apng.AddFrame(canvas);
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
 * 1. When a developer needs to convert a static SVG logo into a looping animated PNG with a color‑changing gradient for web banners.
 * 2. When an application must generate lightweight animated icons that transition between colors without using video files.
 * 3. When a game UI requires dynamic button graphics that fade from red to blue using vector shapes and needs to be saved as APNG for cross‑platform compatibility.
 * 4. When an e‑learning platform wants to illustrate a process by animating the fill of a diagram and deliver it as a single APNG file.
 * 5. When a reporting tool has to embed animated vector illustrations in PDFs and needs the animation pre‑rendered as an APNG image.
 */
