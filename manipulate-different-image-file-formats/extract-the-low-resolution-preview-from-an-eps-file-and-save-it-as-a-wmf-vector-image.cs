// HOW-TO: Extract EPS Low Resolution Preview and Save as WMF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;

namespace EpsPreviewExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.eps";
                string outputPath = "output.wmf";

                // Check input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Read entire EPS file
                byte[] epsBytes = File.ReadAllBytes(inputPath);
                string epsText = Encoding.ASCII.GetString(epsBytes);

                // Locate the preview section
                const string beginMarker = "%%BeginPreview";
                const string endMarker = "%%EndPreview";

                int beginIndex = epsText.IndexOf(beginMarker, StringComparison.Ordinal);
                if (beginIndex == -1)
                {
                    Console.Error.WriteLine("BeginPreview marker not found.");
                    return;
                }

                // Find end of the line containing the BeginPreview marker
                int lineEnd = epsText.IndexOf('\n', beginIndex);
                if (lineEnd == -1)
                {
                    Console.Error.WriteLine("Malformed BeginPreview line.");
                    return;
                }

                // Data starts after the line break
                int dataStart = lineEnd + 1;

                int endIndex = epsText.IndexOf(endMarker, dataStart, StringComparison.Ordinal);
                if (endIndex == -1)
                {
                    Console.Error.WriteLine("EndPreview marker not found.");
                    return;
                }

                // Calculate length of preview data
                int previewLength = endIndex - dataStart;
                if (previewLength <= 0)
                {
                    Console.Error.WriteLine("Preview data is empty.");
                    return;
                }

                // Extract preview bytes
                byte[] previewBytes = new byte[previewLength];
                Array.Copy(epsBytes, dataStart, previewBytes, 0, previewLength);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Write preview as WMF file
                File.WriteAllBytes(outputPath, previewBytes);
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
 * 1. When you need to generate a thumbnail of an EPS illustration for a Windows Forms UI without rendering the full vector content.
 * 2. When converting legacy EPS files to WMF so they can be inserted into older Microsoft Office documents that only accept WMF graphics.
 * 3. When creating low‑resolution previews for a batch of EPS assets to display in a web gallery while keeping the preview file size minimal.
 * 4. When extracting the embedded preview from EPS files to produce printable preview pages for a document management system.
 * 5. When automating the extraction of EPS preview data to embed as vector icons in a C# reporting or dashboard application.
 */
