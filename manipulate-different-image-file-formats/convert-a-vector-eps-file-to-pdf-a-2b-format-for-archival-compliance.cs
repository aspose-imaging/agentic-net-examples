// HOW-TO: Convert EPS To PDF/A‑2b For Archival Compliance In C# (Aspose.Imaging for .NET)
using System;
using System.Diagnostics;
using System.IO;

namespace EpsToPdfAConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.eps";
                string outputPath = "output.pdf";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Build Ghostscript arguments for PDF/A‑2b conversion
                string args = $"-dPDFA=2 " +                     // Target PDF/A‑2b
                              $"-dPDFACompatibilityPolicy=1 " + // Enforce compliance
                              $"-sColorConversionStrategy=RGB " +
                              $"-sDEVICE=pdfwrite " +
                              $"-dNOPAUSE -dBATCH -dSAFER " +
                              $"-sOutputFile=\"{outputPath}\" " +
                              $"\"{inputPath}\"";

                // Start Ghostscript process
                var startInfo = new ProcessStartInfo
                {
                    FileName = "gswin64c", // Assumes Ghostscript is in PATH
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(startInfo))
                {
                    if (process == null)
                    {
                        Console.Error.WriteLine("Failed to start Ghostscript process.");
                        return;
                    }

                    // Capture any output (optional)
                    string stdOut = process.StandardOutput.ReadToEnd();
                    string stdErr = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        Console.Error.WriteLine($"Ghostscript exited with code {process.ExitCode}.");
                        if (!string.IsNullOrWhiteSpace(stdErr))
                        {
                            Console.Error.WriteLine($"Error output: {stdErr}");
                        }
                    }
                }
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
 * 1. When a developer needs to archive legacy EPS artwork in a PDF/A‑2b file to meet long‑term preservation standards.
 * 2. When a C# application must generate PDF/A‑2b compliant documents from vector EPS files for legal or regulatory submissions.
 * 3. When integrating Ghostscript into a .NET workflow to batch‑convert design assets to PDF/A‑2b for a document management system.
 * 4. When preserving the original colors of EPS graphics while ensuring the output meets PDF/A‑2b color conversion requirements.
 * 5. When automating the conversion of EPS files to PDF/A‑2b to guarantee compatibility with archival storage solutions.
 */
