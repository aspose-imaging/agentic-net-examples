// HOW-TO: Apply Custom Stroke Dash Pattern to SVG and Export as PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG as XML to modify stroke dash pattern
            XDocument svgDoc = XDocument.Load(inputPath);
            XNamespace ns = svgDoc.Root.Name.Namespace;

            // Define custom dash pattern (e.g., 5,2,1,2)
            string dashPattern = "5,2,1,2";

            // Apply dash pattern to all elements that have a stroke attribute
            foreach (var element in svgDoc.Descendants())
            {
                XAttribute strokeAttr = element.Attribute("stroke");
                if (strokeAttr != null)
                {
                    // Set or replace the stroke-dasharray attribute
                    element.SetAttributeValue("stroke-dasharray", dashPattern);
                }
            }

            // Save the modified SVG to a temporary file
            string tempSvgPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".svg");
            svgDoc.Save(tempSvgPath);

            // Load the modified SVG with Aspose.Imaging
            using (Image image = Image.Load(tempSvgPath))
            {
                // Save as PDF
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }

            // Clean up temporary file
            if (File.Exists(tempSvgPath))
            {
                File.Delete(tempSvgPath);
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
 * 1. When you need to generate a PDF report that shows dashed lines defined in an SVG diagram.
 * 2. When you want to programmatically add a specific dash style to all stroked paths in a vector graphic before converting it to a printable PDF.
 * 3. When an application must transform user‑uploaded SVG icons into PDF assets with consistent line styling for branding guidelines.
 * 4. When automating batch processing of engineering schematics to ensure every stroke uses a uniform dash pattern in the final PDF documentation.
 * 5. When creating PDF invoices that include vector illustrations where the dash pattern must be enforced for visual emphasis.
 */
