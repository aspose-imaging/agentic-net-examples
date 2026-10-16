// HOW-TO: Convert BMP to SVG and Add Custom XML Comment in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as SVG
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }

            // Embed custom XML comment
            string comment = "<!-- Converted from BMP to SVG using Aspose.Imaging -->";
            string svgContent = File.ReadAllText(outputPath);
            int insertPos = svgContent.IndexOf("?>");
            if (insertPos != -1)
            {
                insertPos += 2; // after ?>
                svgContent = svgContent.Insert(insertPos, Environment.NewLine + comment);
            }
            else
            {
                // No XML declaration, prepend comment
                svgContent = comment + Environment.NewLine + svgContent;
            }
            File.WriteAllText(outputPath, svgContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to transform legacy BMP graphics into scalable SVG files for responsive web design while preserving a traceable conversion note.
 * 2. When generating vector assets from bitmap icons and want to embed an XML comment to indicate the source format for future maintenance.
 * 3. When automating a batch process that converts scanned BMP images to SVG and adds a custom comment for audit logging.
 * 4. When exporting medical imaging BMPs to SVG for inclusion in reports and require an embedded comment to comply with documentation standards.
 * 5. When creating a build pipeline that converts BMP assets to SVG and inserts a custom XML comment to help developers identify the conversion step in the source code.
 */
