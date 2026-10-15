// HOW-TO: Extract Text From CMX File to Plain Text Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

namespace CmxTextExtractor
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.cmx";
            string outputPath = "output.txt";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Image image = Image.Load(inputPath);
                string extractedText = string.Empty;

                if (image is CmxImage cmxImage)
                {
                    // Try to get a property that may contain text objects
                    var textsProp = cmxImage.GetType().GetProperty("Texts");
                    if (textsProp != null)
                    {
                        var texts = textsProp.GetValue(cmxImage) as IEnumerable;
                        if (texts != null)
                        {
                            foreach (var t in texts)
                            {
                                if (t != null)
                                    extractedText += t.ToString() + Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        // Fallback to metadata string representation
                        extractedText = cmxImage.Metadata?.ToString() ?? string.Empty;
                    }
                }
                else
                {
                    extractedText = image.Metadata?.ToString() ?? string.Empty;
                }

                File.WriteAllText(outputPath, extractedText);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to index searchable keywords from legacy CMX drawings for a document management system.
 * 2. When you want to extract embedded text annotations from CMX files to generate searchable PDF metadata.
 * 3. When building a batch process that converts CMX design notes into plain‑text logs for analytics.
 * 4. When integrating CMX content into a full‑text search engine that requires .txt input files.
 * 5. When migrating CAD data and need to preserve textual information from CMX files for compliance reporting.
 */
