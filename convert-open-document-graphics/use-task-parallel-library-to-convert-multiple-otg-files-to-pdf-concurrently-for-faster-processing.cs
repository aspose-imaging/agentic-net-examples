// HOW-TO: Convert Multiple OTG Files to PDF Concurrently Using TPL in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = new string[]
            {
                "input1.otg",
                "input2.otg",
                "input3.otg"
            };

            string[] outputPaths = new string[]
            {
                "output1.pdf",
                "output2.pdf",
                "output3.pdf"
            };

            // Ensure the arrays have the same length
            int count = Math.Min(inputPaths.Length, outputPaths.Length);

            Parallel.For(0, count, i =>
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                string? outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir ?? ".");

                // Load OTG image and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PdfOptions());
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a batch of OTG vector graphics must be turned into PDF reports quickly, developers can run the conversions in parallel to save time.
 * 2. When an automated server job needs to generate PDF invoices from OTG templates for many customers at once, parallel processing speeds up the workflow.
 * 3. When a desktop application lets users select several OTG drawings and export them to PDF without freezing the UI, using TPL keeps the interface responsive.
 * 4. When a cloud service receives multiple OTG uploads and must store them as PDFs for archival, concurrent conversion reduces latency and resource usage.
 * 5. When a CI/CD pipeline validates that OTG assets render correctly as PDFs across many files, parallel conversion shortens the test cycle.
 */
