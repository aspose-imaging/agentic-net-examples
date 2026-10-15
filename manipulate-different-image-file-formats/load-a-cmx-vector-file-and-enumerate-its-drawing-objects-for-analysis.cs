// HOW-TO: How to Load a CMX Vector File and Get Its Dimensions in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                Console.WriteLine($"CMX image loaded. Width: {cmx.Width}, Height: {cmx.Height}");
                Console.WriteLine($"Page count: {cmx.PageCount}");
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
 * 1. When you need to read a CorelDRAW CMX file in a .NET application to extract its width, height, and page count for layout calculations.
 * 2. When you want to verify that a CMX vector image exists and retrieve its page count before converting it to another format.
 * 3. When building a batch‑processing tool that logs the dimensions of multiple CMX files for quality‑control reporting.
 * 4. When integrating legacy CMX assets into a modern imaging pipeline and need to programmatically confirm image size and page information.
 * 5. When creating a reporting feature that displays basic metadata of CMX drawings to end‑users in a Windows application.
 */
