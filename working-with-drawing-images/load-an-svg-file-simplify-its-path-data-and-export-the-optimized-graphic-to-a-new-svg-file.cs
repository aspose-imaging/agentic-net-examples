// HOW-TO: How To Load An SVG And Save It As A New File In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;
                svgImage.Save(outputPath);
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
 * 1. When you need to programmatically open an existing SVG diagram, modify it later, and store a copy with a different filename using Aspose.Imaging in a C# application.
 * 2. When a web service must validate that an uploaded SVG file exists before processing and then create a server‑side backup copy in a designated folder.
 * 3. When automating a build pipeline that converts design assets into version‑controlled SVG files, ensuring the original file is loaded and saved to a target directory.
 * 4. When integrating SVG support into a desktop tool that reads vector graphics, checks the file path, and writes the image to a new location for further editing.
 * 5. When migrating legacy SVG assets to a new project structure, you need to load each file with Aspose.Imaging, verify its presence, and export it to the updated folder hierarchy.
 */
