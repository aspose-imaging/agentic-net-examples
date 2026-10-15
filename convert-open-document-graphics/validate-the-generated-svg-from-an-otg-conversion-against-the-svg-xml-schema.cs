// HOW-TO: Validate OTG to SVG Conversion Against SVG Schema in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using System.Xml;
using System.Xml.Schema;

namespace OtgToSvgValidator
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string svgPath = "output.svg";
                string schemaPath = "svg.xsd";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(svgPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new SvgOptions();
                    image.Save(svgPath, options);
                }

                if (!File.Exists(schemaPath))
                {
                    Console.Error.WriteLine($"File not found: {schemaPath}");
                    return;
                }

                bool isValid = true;
                var settings = new XmlReaderSettings
                {
                    ValidationType = ValidationType.Schema
                };
                settings.Schemas.Add(null, schemaPath);
                settings.ValidationEventHandler += (sender, e) =>
                {
                    isValid = false;
                    Console.Error.WriteLine($"Validation {e.Severity}: {e.Message}");
                };

                using (var reader = XmlReader.Create(svgPath, settings))
                {
                    while (reader.Read()) { }
                }

                if (isValid)
                {
                    Console.WriteLine("SVG validation succeeded.");
                }
                else
                {
                    Console.WriteLine("SVG validation failed.");
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
 * 1. When you need to ensure that an OTG file exported from a graphics editor produces standards‑compliant SVG for web publishing.
 * 2. When an automated build pipeline must convert proprietary OTG drawings to SVG and verify they conform to the official SVG XML schema before deployment.
 * 3. When a SaaS service accepts user‑uploaded OTG files and must validate the generated SVG to prevent malformed markup that could break browsers.
 * 4. When performing batch processing of legacy OTG assets to SVG and need to catch schema violations early to maintain data quality.
 * 5. When integrating Aspose.Imaging into a C# application that generates SVG reports and you must guarantee the output passes XML schema validation for downstream tools.
 */
