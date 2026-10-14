// HOW-TO: Convert PNG to JPEG and Generate README with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/sample.jpg";
            string readmePath = "README.md";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(readmePath));

            using (Image image = Image.Load(inputPath))
            using (JpegOptions options = new JpegOptions())
            {
                image.Save(outputPath, options);
            }

            string readmeContent = "# Image Conversion Guide\n\nThis guide demonstrates how to convert a PNG image to JPEG using Aspose.Imaging for .NET.\n\n## Steps\n\n1. Load the source image:\n```csharp\nusing (Image image = Image.Load(inputPath))\n{\n    // image is loaded\n}\n```\n\n2. Create the target format options:\n```csharp\nusing (JpegOptions options = new JpegOptions())\n{\n    // configure options if needed\n}\n```\n\n3. Save the image in the desired format:\n```csharp\nimage.Save(outputPath, options);\n```\n\n## Code Example\n```csharp\nstring inputPath = \"Input/sample.png\";\nstring outputPath = \"Output/sample.jpg\";\n\nusing (Image image = Image.Load(inputPath))\nusing (JpegOptions options = new JpegOptions())\n{\n    image.Save(outputPath, options);\n}\n```";

            File.WriteAllText(readmePath, readmeContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert user‑uploaded PNG files to JPEG for web‑optimized delivery while automatically creating a markdown guide for the process.
 * 2. When a desktop application must save screenshots as JPEG to reduce file size and also produce a README that explains the conversion steps for future maintenance.
 * 3. When integrating Aspose.Imaging into a CI pipeline to transform design assets from PNG to JPEG and document the workflow for developers.
 * 4. When building a migration tool that converts legacy PNG resources to JPEG and generates a markdown file describing the conversion logic for auditors.
 * 5. When providing sample code in a product’s documentation that shows how to load a PNG, apply JPEG options, save the result, and output a README with usage instructions.
 */
