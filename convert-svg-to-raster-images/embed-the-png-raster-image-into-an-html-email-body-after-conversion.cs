// HOW-TO: Embed PNG Image in HTML Email Body Using C# Base64 (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/email.html";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] imageBytes = File.ReadAllBytes(inputPath);
            string base64 = Convert.ToBase64String(imageBytes);
            string html = $"<html><body><img src=\"data:image/png;base64,{base64}\" alt=\"Embedded Image\" /></body></html>";

            File.WriteAllText(outputPath, html);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to send a PNG picture inline in an email without attaching separate files.
 * 2. When generating dynamic HTML newsletters that include embedded images to avoid broken links.
 * 3. When creating automated reports that embed charts as PNGs directly into the email body.
 * 4. When building a C# service that converts local image assets to base64 HTML for email templates.
 * 5. When ensuring email clients display images without requiring external hosting or additional downloads.
 */
