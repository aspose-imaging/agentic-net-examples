// HOW-TO: Create BMP Image with Green Ellipse and Get Byte Array in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            int width = 200;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Green, 5);
                graphics.DrawEllipse(pen, 0, 0, width, height);

                image.Save();

                byte[] imageBytes = File.ReadAllBytes(outputPath);
                Console.WriteLine($"Byte array length: {imageBytes.Length}");
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
 * 1. When you need to generate a BMP thumbnail with a highlighted green ellipse for a reporting dashboard and send it over a web API as a byte array.
 * 2. When an application must create a simple vector shape on a bitmap, such as a green ring, and store the image in memory without writing to disk.
 * 3. When you want to embed a programmatically drawn BMP graphic into an email attachment by converting the file to a byte[] for the mail message.
 * 4. When a game or simulation requires a dynamically created BMP texture with a green circular outline to be loaded directly into a graphics engine.
 * 5. When a testing framework needs to verify image processing output by creating a BMP with a known ellipse and comparing the resulting byte array against expected data.
 */
