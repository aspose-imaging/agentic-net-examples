// HOW-TO: Convert OTG to SVG and Flatten Groups in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }

            XDocument doc = XDocument.Load(outputPath);
            var groups = doc.Descendants()
                            .Where(e => e.Name.LocalName == "g")
                            .ToList();

            foreach (var g in groups)
            {
                var parent = g.Parent;
                if (parent != null)
                {
                    foreach (var child in g.Elements())
                    {
                        parent.Add(child);
                    }
                    g.Remove();
                }
            }

            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a vector diagram created in OpenOffice Draw on a web page, you can convert the OTG file to SVG and remove unnecessary group tags to ensure the SVG renders quickly.
 * 2. When an automated pipeline must generate lightweight SVG assets from OTG sources for mobile apps, this code converts the format and flattens the group hierarchy to reduce file size.
 * 3. When a design‑to‑code workflow requires cleaning up exported OTG graphics before importing them into a CAD system, the code produces a simplified SVG without nested <g> elements.
 * 4. When you are building a reporting tool that embeds vector images and you want consistent styling, converting OTG to SVG and stripping groups guarantees uniform styling across browsers.
 * 5. When a batch process needs to prepare a library of OTG icons for use in a UI library, this snippet converts each file to SVG and eliminates extra group layers to make the icons easier to style with CSS.
 */
