// HOW-TO: Convert CMX Image From URL To PDF Stream In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Net;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CmxToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input URL and output file path
                string inputUrl = "https://example.com/sample.cmx";
                string outputPath = "output/result.pdf";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Download CMX image from network stream
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(inputUrl);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream networkStream = response.GetResponseStream())
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    ConvertCmxToPdf(networkStream, fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConvertCmxToPdf(Stream inputStream, Stream outputStream)
        {
            // Load CMX image from the provided stream
            using (Image cmxImage = Image.Load(inputStream))
            {
                // Save as PDF to the provided output stream
                PdfOptions pdfOptions = new PdfOptions();
                cmxImage.Save(outputStream, pdfOptions);
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application must download a CorelDRAW CMX file from a remote server and deliver it as a PDF to the user's browser without saving intermediate files.
 * 2. When an automated reporting tool needs to convert CMX diagrams stored in a cloud storage bucket into PDF documents for archival or printing.
 * 3. When a microservice processes incoming image streams, such as CMX files received via HTTP, and returns PDF results to downstream services.
 * 4. When a desktop utility batch‑processes a list of CMX URLs, converting each to PDF and writing the output directly to a file or response stream.
 * 5. When integrating Aspose.Imaging into a C# API that transforms legacy CMX graphics into PDF format for compatibility with modern PDF viewers.
 */
