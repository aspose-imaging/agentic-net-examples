// HOW-TO: Combine Multi‑Page PDF Vector Graphics Into a Single SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.pdf";
            string outputPath = "output.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Cast to IMultipageImage to access pages
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a multipage image.");
                    return;
                }

                List<XElement> pageRoots = new List<XElement>();
                List<double> pageHeights = new List<double>();
                double maxWidth = 0;
                double totalHeight = 0;

                // Convert each page to SVG and collect dimensions
                foreach (Image page in multipage.Pages)
                {
                    using (var ms = new MemoryStream())
                    {
                        var svgOptions = new SvgOptions();
                        page.Save(ms, svgOptions);
                        ms.Position = 0;

                        XDocument svgDoc = XDocument.Load(ms);
                        XElement root = svgDoc.Root;
                        if (root == null)
                            continue;

                        // Parse width and height (assume pixels or unit-less)
                        double width = ParseSvgLength(root.Attribute("width")?.Value);
                        double height = ParseSvgLength(root.Attribute("height")?.Value);

                        maxWidth = Math.Max(maxWidth, width);
                        totalHeight += height;

                        pageRoots.Add(root);
                        pageHeights.Add(height);
                    }
                }

                // Build combined SVG
                XNamespace ns = "http://www.w3.org/2000/svg";
                XElement combinedRoot = new XElement(ns + "svg",
                    new XAttribute("xmlns", ns.NamespaceName),
                    new XAttribute("width", maxWidth),
                    new XAttribute("height", totalHeight)
                );

                double currentY = 0;
                for (int i = 0; i < pageRoots.Count; i++)
                {
                    XElement pageRoot = pageRoots[i];
                    double pageHeight = pageHeights[i];

                    // Create a group with translation for this page
                    XElement group = new XElement(ns + "g",
                        new XAttribute("transform", $"translate(0,{currentY})")
                    );

                    // Copy all child nodes from the page's SVG (excluding the outer <svg> element)
                    foreach (XNode node in pageRoot.Nodes())
                    {
                        group.Add(node);
                    }

                    combinedRoot.Add(group);
                    currentY += pageHeight;
                }

                XDocument combinedDoc = new XDocument(combinedRoot);
                combinedDoc.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper to parse SVG length strings (e.g., "800px", "800")
    private static double ParseSvgLength(string length)
    {
        if (string.IsNullOrWhiteSpace(length))
            return 0;

        // Remove any unit suffix like "px"
        string numericPart = length.Trim().ToLowerInvariant();
        if (numericPart.EndsWith("px"))
            numericPart = numericPart.Substring(0, numericPart.Length - 2);

        if (double.TryParse(numericPart, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double result))
            return result;

        return 0;
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed an entire multi‑page PDF brochure as a single scalable graphic on a web page.
 * 2. When you want to generate a combined SVG for printing or further vector editing from a PDF report.
 * 3. When you must reduce the number of files by merging PDF pages into one SVG for easier distribution.
 * 4. When you are building a C# application that converts PDF invoices into a single SVG for archival in a vector‑based system.
 * 5. When you need to preserve vector quality while consolidating PDF slides into one SVG canvas for interactive presentations.
 */
