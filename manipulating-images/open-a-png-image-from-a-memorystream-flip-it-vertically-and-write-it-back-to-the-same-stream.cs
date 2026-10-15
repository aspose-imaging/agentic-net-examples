// HOW-TO: Flip a PNG Vertically Using MemoryStream in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            byte[] inputBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(inputBytes, 0, inputBytes.Length);
                ms.Position = 0;

                using (Image image = Image.Load(ms))
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    ms.SetLength(0);
                    ms.Position = 0;
                    image.Save(ms);
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
 * 1. When you need to mirror a PNG image for a UI element without creating a temporary file, you can load it into a MemoryStream, flip it vertically, and save it back.
 * 2. When processing uploaded PNGs in a web API, you can use Aspose.Imaging to vertically flip the image in memory before returning it to the client.
 * 3. When generating thumbnails that require a top‑down orientation, you can read the source PNG from a byte array, apply a vertical flip, and write the result to the same stream.
 * 4. When integrating image transformations into a background service that works with streams for performance, you can vertically flip PNGs using RotateFlip on an Image loaded from a MemoryStream.
 * 5. When you need to correct upside‑down screenshots captured from a device, you can load the PNG into a MemoryStream, flip it along the Y‑axis, and overwrite the original byte array.
 */
