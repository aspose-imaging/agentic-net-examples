// HOW-TO: Validate SVG Generated From ODG Conversion Against XSD In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output.svg";
            string schemaPath = "svg.xsd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (var image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(outputPath, options);
            }

            if (!File.Exists(schemaPath))
            {
                Console.Error.WriteLine($"File not found: {schemaPath}");
                return;
            }

            bool hasErrors = false;
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.Schemas.Add(null, schemaPath);
            settings.ValidationEventHandler += (sender, e) =>
            {
                hasErrors = true;
                Console.Error.WriteLine($"Validation {e.Severity}: {e.Message}");
            };

            using (var reader = XmlReader.Create(outputPath, settings))
            {
                while (reader.Read()) { }
            }

            if (!hasErrors)
            {
                Console.WriteLine("SVG validation succeeded.");
            }
            else
            {
                Console.Error.WriteLine("SVG validation failed.");
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
 * 1. When you need to ensure that an SVG created from an OpenDocument graphic complies with the official SVG schema before publishing it.
 * 2. When a web application must convert user‑uploaded ODG files to SVG and guarantee the output is standards‑compatible for browsers.
 * 3. When an automated build pipeline generates SVG assets from ODG sources and wants to catch schema violations early.
 * 4. When integrating Aspose.Imaging into a document‑processing service that requires validated SVG for downstream vector editing tools.
 * 5. When performing quality‑assurance testing of batch ODG‑to‑SVG conversions to verify that each SVG file passes XML schema validation.
 */
