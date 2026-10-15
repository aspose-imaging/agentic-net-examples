// HOW-TO: Add Caption to EPS and Save as SVG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(epsImage);

                string caption = "Sample Caption";
                Font font = new Font("Arial", 24);

                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    float x = (epsImage.Width - 200) / 2;
                    float y = epsImage.Height - 30;
                    graphics.DrawString(caption, font, brush, new PointF(x, y));
                }

                epsImage.Save(outputPath, new SvgOptions());
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
 * 1. When you need to annotate a vector EPS logo with a descriptive label before converting it to an SVG for web display.
 * 2. When generating printable marketing materials that require adding dynamic text to EPS artwork and exporting the result as scalable SVG files.
 * 3. When automating a workflow that adds product names to EPS diagrams and saves them as SVGs for inclusion in responsive UI components.
 * 4. When creating batch scripts that embed copyright notices at the bottom of EPS illustrations and output the annotated images in SVG format.
 * 5. When converting EPS technical drawings to SVG while programmatically inserting version numbers or timestamps as captions using C#.
 */
