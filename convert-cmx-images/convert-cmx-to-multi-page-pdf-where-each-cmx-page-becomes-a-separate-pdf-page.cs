// HOW-TO: Convert CMX File to Multi‑Page PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CmxtoPdfConverter
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.cmx";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            try
            {
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to archive multi‑page CorelDRAW CMX drawings as a single searchable PDF document for easy distribution.
 * 2. When an application must generate printable PDFs from CMX files received from a legacy design system without manually extracting each page.
 * 3. When a workflow requires converting batch CMX files into multi‑page PDFs for integration with document management or e‑signature platforms.
 * 4. When a web service needs to provide on‑the‑fly conversion of uploaded CMX artwork into PDF so users can preview the entire design in one file.
 * 5. When a reporting tool must embed CMX graphics into PDF reports, preserving each CMX page as a separate PDF page for consistent pagination.
 */
