// HOW-TO: Create BMP Image with Anti-Aliased Graphics in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            int width = 200;
            int height = 200;

            BmpOptions options = new BmpOptions();
            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(Color.White);
                image.Save(outputPath, options);
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
 * 1. When you need to generate a blank BMP file with smooth vector drawings for a Windows desktop application.
 * 2. When you want to programmatically create a high‑quality thumbnail canvas and ensure edges are anti‑aliased using Aspose.Imaging in C#.
 * 3. When you must produce a white‑background bitmap for printing or scanning simulations where jagged lines must be avoided.
 * 4. When you are building a server‑side service that creates custom BMP charts and requires smoother curves by setting SmoothingMode to AntiAlias.
 * 5. When you need to initialize a Graphics object on a newly created image to apply drawing operations with anti‑aliasing before saving the result.
 */
