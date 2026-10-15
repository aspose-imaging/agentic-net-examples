// HOW-TO: Set Custom Hex Background Color for SVG to PNG Conversion in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Globalization;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";
            string hexColor = "#FF00FF"; // custom hex value

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Parse hex color (supports #RRGGBB or #AARRGGBB)
            Color backgroundColor;
            string cleanHex = hexColor.TrimStart('#');
            if (cleanHex.Length == 6)
            {
                int r = int.Parse(cleanHex.Substring(0, 2), NumberStyles.HexNumber);
                int g = int.Parse(cleanHex.Substring(2, 2), NumberStyles.HexNumber);
                int b = int.Parse(cleanHex.Substring(4, 2), NumberStyles.HexNumber);
                backgroundColor = Color.FromArgb(255, r, g, b);
            }
            else if (cleanHex.Length == 8)
            {
                int a = int.Parse(cleanHex.Substring(0, 2), NumberStyles.HexNumber);
                int r = int.Parse(cleanHex.Substring(2, 2), NumberStyles.HexNumber);
                int g = int.Parse(cleanHex.Substring(4, 2), NumberStyles.HexNumber);
                int b = int.Parse(cleanHex.Substring(6, 2), NumberStyles.HexNumber);
                backgroundColor = Color.FromArgb(a, r, g, b);
            }
            else
            {
                Console.Error.WriteLine($"Invalid hex color format: {hexColor}");
                return;
            }

            var rasterizationOptions = new SvgRasterizationOptions
            {
                BackgroundColor = backgroundColor
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to render an SVG logo on a solid brand‑color background and save it as a PNG for web use.
 * 2. When generating PNG assets from SVG diagrams and must apply a specific hex‑coded background to match corporate guidelines.
 * 3. When converting user‑uploaded SVG files to PNG for email attachments while replacing transparent areas with a defined color.
 * 4. When creating a batch process that rasterizes SVG icons to PNG with a preset background for mobile app resources.
 * 5. When integrating Aspose.Imaging in a C# service that produces printable PNGs from SVGs with a custom background to meet printing specifications.
 */
