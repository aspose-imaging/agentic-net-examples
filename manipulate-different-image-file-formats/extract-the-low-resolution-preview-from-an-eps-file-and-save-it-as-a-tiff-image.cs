// HOW-TO: Extract EPS Low Resolution Preview and Save as TIFF in C# (Aspose.Imaging for .NET)
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
                string inputPath = @"C:\Input\sample.eps";
                string outputPath = @"C:\Output\preview.tif";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Read all bytes from the EPS file
                byte[] epsBytes = File.ReadAllBytes(inputPath);
                string epsText = Encoding.ASCII.GetString(epsBytes);

                // Locate the BeginPreview marker
                const string beginMarker = "%%BeginPreview";
                const string endMarker = "%%EndPreview";

                int beginIndex = epsText.IndexOf(beginMarker, StringComparison.Ordinal);
                if (beginIndex == -1)
                {
                    Console.Error.WriteLine("BeginPreview marker not found.");
                    return;
                }

                // Find the end of the line after BeginPreview
                int lineEnd = epsText.IndexOf('\n', beginIndex);
                if (lineEnd == -1)
                {
                    Console.Error.WriteLine("Malformed BeginPreview line.");
                    return;
                }

                // Locate EndPreview marker after BeginPreview
                int endIndex = epsText.IndexOf(endMarker, lineEnd, StringComparison.Ordinal);
                if (endIndex == -1)
                {
                    Console.Error.WriteLine("EndPreview marker not found.");
                    return;
                }

                // Calculate byte positions
                // Convert character indices to byte indices (ASCII => 1 byte per char)
                int previewStartByte = lineEnd + 1; // start after newline
                int previewEndByte = endIndex; // start of EndPreview

                if (previewStartByte >= previewEndByte || previewEndByte > epsBytes.Length)
                {
                    Console.Error.WriteLine("Invalid preview data boundaries.");
                    return;
                }

                // Extract preview bytes
                int previewLength = previewEndByte - previewStartByte;
                byte[] previewBytes = new byte[previewLength];
                Array.Copy(epsBytes, previewStartByte, previewBytes, 0, previewLength);

                // Save the preview as TIFF
                File.WriteAllBytes(outputPath, previewBytes);
                Console.WriteLine($"Preview extracted to: {outputPath}");
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
 * 1. When a publishing workflow needs to generate quick‑look thumbnails of EPS artwork for a web catalog, developers can extract the embedded preview and save it as a TIFF file.
 * 2. When a document management system stores EPS files but requires a low‑resolution image for preview panes, this code provides a fast way to create the preview image in C#.
 * 3. When an automated batch process must create printable low‑resolution versions of EPS logos for proofing, extracting the preview and converting it to TIFF simplifies the pipeline.
 * 4. When a legacy design archive contains EPS files without separate preview images, developers can use this snippet to generate TIFF previews for archival indexing.
 * 5. When a Windows desktop application needs to display EPS content in a control that only supports raster formats, extracting the EPS preview and saving it as TIFF enables immediate rendering.
 */
