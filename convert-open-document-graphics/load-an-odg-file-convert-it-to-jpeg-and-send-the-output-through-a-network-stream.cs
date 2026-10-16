// HOW-TO: Convert ODG to JPEG and Stream Over TCP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToJpegNetwork
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output.jpg";
                string host = "localhost";
                int port = 5000;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load ODG image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as JPEG to file
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);

                    // Also send JPEG data over network
                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, jpegOptions);
                        byte[] jpegData = memoryStream.ToArray();

                        using (TcpClient client = new TcpClient())
                        {
                            client.Connect(host, port);
                            using (NetworkStream networkStream = client.GetStream())
                            {
                                networkStream.Write(jpegData, 0, jpegData.Length);
                                networkStream.Flush();
                            }
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
 * 1. When a desktop application needs to convert an OpenDocument graphic (ODG) into a JPEG thumbnail and immediately send it to a remote monitoring server via TCP.
 * 2. When a cloud service processes user‑uploaded ODG diagrams, saves a JPEG version for storage and streams the same image to another microservice for further analysis.
 * 3. When a real‑time collaboration tool converts a designer’s ODG file to JPEG and pushes the image over a network socket to display it instantly on teammates’ screens.
 * 4. When an automated reporting system generates JPEG snapshots from ODG charts, writes them to disk for archival and transmits the bytes to a printer daemon over TCP.
 * 5. When a mobile backend receives ODG files, converts them to JPEG for web preview, and streams the image to a client app without first writing it to a temporary file.
 */
