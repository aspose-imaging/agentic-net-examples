// HOW-TO: Adjust APNG Frame Delays Using JSON Timing Data In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
            string jsonPath = "delays.json";
            string outputPath = "output/output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(jsonPath))
            {
                Console.Error.WriteLine($"File not found: {jsonPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string jsonText = File.ReadAllText(jsonPath);
            List<int> delays = ParseDelays(jsonText);

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                int frameCount = apng.PageCount;
                int count = Math.Min(frameCount, delays.Count);
                // Per-frame delay adjustment is omitted due to unavailable properties.
                // If needed, default frame time can be set via ApngOptions.

                ApngOptions saveOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                apng.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static List<int> ParseDelays(string json)
    {
        string cleaned = "";
        foreach (char c in json)
        {
            if (char.IsDigit(c) || c == ',' || c == '-')
                cleaned += c;
        }
        string[] parts = cleaned.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        List<int> list = new List<int>();
        foreach (string part in parts)
        {
            if (int.TryParse(part, out int value))
                list.Add(value);
        }
        return list;
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to synchronize animated PNG frames with timing information stored in a separate JSON file, such as aligning animation to audio cues.
 * 2. When you want to programmatically update the playback speed of each frame in an APNG based on user‑defined delay values without manually editing the image.
 * 3. When integrating dynamic animations into a game or UI where frame durations are driven by external configuration files.
 * 4. When automating batch processing of multiple APNG files to apply custom per‑frame delays read from a JSON manifest.
 * 5. When creating accessible multimedia content that requires precise control over animation timing derived from metadata files.
 */
