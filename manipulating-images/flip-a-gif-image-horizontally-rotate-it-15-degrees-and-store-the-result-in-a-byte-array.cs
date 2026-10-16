// HOW-TO: Flip GIF Horizontally And Rotate 15 Degrees To Byte Array In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Flip horizontally
                gif.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Rotate 15 degrees with proportional resize and white background
                gif.Rotate(15f, true, Aspose.Imaging.Color.White);

                using (MemoryStream ms = new MemoryStream())
                {
                    GifOptions options = new GifOptions();
                    gif.Save(ms, options);
                    byte[] result = ms.ToArray();

                    // Use the result to avoid unused variable warning
                    Console.WriteLine($"Result byte array length: {result.Length}");
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
 * 1. When you need to mirror a GIF animation for a web banner and then rotate it slightly before sending it over a network as a byte array.
 * 2. When creating a custom thumbnail generator that flips and tilts GIFs and stores the processed image in memory for further manipulation.
 * 3. When integrating animated GIFs into a game engine that requires the image data as a byte array after applying horizontal flip and a 15‑degree rotation.
 * 4. When building an email marketing tool that adjusts GIF orientation on the fly and embeds the resulting byte array directly into the email payload.
 * 5. When developing a server‑side image service that receives GIF files, applies a flip and rotation, and returns the transformed image as a byte array for client‑side rendering.
 */
