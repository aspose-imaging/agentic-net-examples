// HOW-TO: Read APNG Loop Count and Frame Count in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                int loopCount = apng.NumPlays;
                int frameCount = apng.PageCount;

                Console.WriteLine($"Loop count: {loopCount}");
                Console.WriteLine($"Total frames: {frameCount}");
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
 * 1. When you need to retrieve the NumPlays (loop count) of an APNG file to decide how many times the animation should repeat in a C# application.
 * 2. When you want to log or display the total number of frames (PageCount) in an APNG for debugging or analytics purposes.
 * 3. When building a media library that stores animation metadata such as loop count and frame count for each APNG using Aspose.Imaging for .NET.
 * 4. When validating an uploaded APNG to ensure it meets required animation parameters before further processing or conversion.
 * 5. When creating a user interface that shows the animation length and repeat behavior of an APNG based on its metadata.
 */
