// HOW-TO: Create BMP Image With Green Rectangle Using MemoryStream In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (MemoryStream ms = new MemoryStream())
            {
                BmpOptions bmpOptions = new BmpOptions();
                int width = 200;
                int height = 200;

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 3);
                    Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(20, 20, 160, 160);
                    graphics.DrawRectangle(pen, rect);

                    image.Save(ms, bmpOptions);
                }

                File.WriteAllBytes(outputPath, ms.ToArray());
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
 * 1. When you need to generate a BMP thumbnail with a highlighted border on the fly for a reporting dashboard.
 * 2. When you want to create a simple placeholder image with a colored rectangle for testing image upload functionality.
 * 3. When an application must draw vector graphics into a BMP file in memory before sending it over a network or API.
 * 4. When you are building a server‑side service that programmatically adds a green frame to user‑provided images without writing intermediate files.
 * 5. When you need to produce a BMP asset with custom dimensions and shapes for a legacy system that only accepts BMP format.
 */
