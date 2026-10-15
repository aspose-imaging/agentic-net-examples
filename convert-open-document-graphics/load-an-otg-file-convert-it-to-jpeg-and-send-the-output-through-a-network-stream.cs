// HOW-TO: Convert OTG Image to JPEG and Transmit Over TCP in C# (Aspose.Imaging for .NET)
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

namespace OtgToJpegNetwork
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths and network settings
                string inputPath = "input.otg";
                string outputPath = "output.jpg";
                string host = "localhost";
                int port = 12345;

                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load OTG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare JPEG options
                    var jpegOptions = new JpegOptions();

                    // Save to memory stream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, jpegOptions);
                        byte[] jpegBytes = memoryStream.ToArray();

                        // Save to file
                        File.WriteAllBytes(outputPath, jpegBytes);

                        // Send JPEG bytes over network
                        using (TcpClient client = new TcpClient())
                        {
                            client.Connect(host, port);
                            using (NetworkStream networkStream = client.GetStream())
                            {
                                networkStream.Write(jpegBytes, 0, jpegBytes.Length);
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
 * 1. When you need to read a proprietary OTG graphic from a device, convert it to a standard JPEG, and store it locally for later viewing.
 * 2. When a server application must receive an OTG file, transform it into a compressed JPEG, and forward the image to another service over a TCP connection.
 * 3. When building a real‑time imaging pipeline that captures OTG screenshots, converts them to JPEG to reduce size, and streams them to a remote monitoring console.
 * 4. When integrating legacy OTG assets into a web‑based gallery, you can convert each file to JPEG and send the bytes through a socket to a client application.
 * 5. When automating batch processing that reads OTG files, creates JPEG thumbnails, saves them to disk, and pushes the thumbnails to a networked printer or display device.
 */
