// HOW-TO: Load Image from TCP Socket and Save as BMP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string host = "127.0.0.1";
            int port = 12345;
            string outputPath = "output/output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream networkStream = client.GetStream())
            {
                using (Image image = Image.Load(networkStream))
                {
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    image.Save(outputPath, bmpOptions);
                }
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
 * 1. When you need to receive image data streamed over a network connection and store it locally as a BMP file for further processing.
 * 2. When building a client‑server application that captures screenshots from a remote device and saves them in a lossless BMP format using C#.
 * 3. When integrating a legacy system that sends raw image bytes over a socket and you must convert them to a standard file type for archival.
 * 4. When developing a real‑time monitoring tool that reads image frames from a TCP feed and writes them to disk for later analysis.
 * 5. When creating a batch job that pulls images from a network service and uses Aspose.Imaging to convert and persist them as BMP files.
 */
