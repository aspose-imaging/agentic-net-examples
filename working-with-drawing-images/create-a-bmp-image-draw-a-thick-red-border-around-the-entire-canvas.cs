// HOW-TO: Create BMP Image With Thick Red Border Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "./output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            int width = 200;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Color.Red, 10);
                graphics.DrawRectangle(pen, new Rectangle(0, 0, width - 1, height - 1));
                image.Save();
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
 * 1. When you need to generate a plain BMP thumbnail with a visible red frame for UI placeholders.
 * 2. When a reporting tool requires a simple bitmap with a colored border to highlight sections in generated charts.
 * 3. When an automated batch process creates BMP assets and adds a thick red outline to indicate error states.
 * 4. When a game engine loads custom textures and you must programmatically add a red border for debugging visual boundaries.
 * 5. When a document conversion service outputs BMP files and you want to embed a red margin to comply with branding guidelines.
 */
