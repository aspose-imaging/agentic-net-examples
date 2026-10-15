// HOW-TO: Get JPEG Image Width and Height in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                Console.WriteLine($"Width: {image.Width}");
                Console.WriteLine($"Height: {image.Height}");
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
 * 1. When building a batch processing tool that needs to verify the dimensions of uploaded JPEG photos before resizing them using Aspose.Imaging.
 * 2. When creating a server‑side validation routine in C# that checks if a user‑submitted JPEG meets minimum width and height requirements for a web gallery.
 * 3. When generating a console report that lists the pixel dimensions of JPEG image assets stored on disk for inventory or compliance purposes.
 * 4. When developing a debugging utility that logs image size information to help troubleshoot layout issues in a C# desktop application.
 * 5. When implementing a quick script to read JPEG width and height without fully loading the image, improving performance in image‑processing pipelines.
 */
