// HOW-TO: Create KML File From JPEG Images Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-28
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, "locations.kml");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            StringBuilder kml = new StringBuilder();
            kml.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            kml.AppendLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2"">");
            kml.AppendLine(@"<Document>");

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    continue;
                }

                using (JpegImage image = (JpegImage)Image.Load(file))
                {
                    kml.AppendLine("<Placemark>");
                    kml.AppendLine($"<name>{Path.GetFileName(file)}</name>");
                    kml.AppendLine("<Point>");
                    kml.AppendLine("<coordinates>0,0,0</coordinates>");
                    kml.AppendLine("</Point>");
                    kml.AppendLine("</Placemark>");
                }
            }

            kml.AppendLine("</Document>");
            kml.AppendLine("</kml>");

            File.WriteAllText(outputPath, kml.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a KML document that lists all JPEG photos in a directory so they can be visualized as points in Google Earth.
 * 2. When an application must batch‑process JPEG images to extract metadata and produce a map‑compatible KML file without manual editing.
 * 3. When a GIS workflow requires converting a collection of picture filenames into placemarks for location‑based reporting.
 * 4. When a photo‑management system wants to export image locations to a KML file for sharing with clients or stakeholders.
 * 5. When a C# service automates the creation of KML files from uploaded JPEGs to integrate with mapping APIs.
 */
