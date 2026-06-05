using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            string fontsPath = Path.Combine(baseDir, "Fonts");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions();
                loadOptions.AddCustomFontSource((args) =>
                {
                    string path = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                    var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                    {
                        foreach (var fontFile in Directory.GetFiles(path))
                        {
                            byte[] data = File.ReadAllBytes(fontFile);
                            string name = Path.GetFileNameWithoutExtension(fontFile);
                            list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                    return list.ToArray();
                }, fontsPath);

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    using (var pdfOptions = new PdfOptions())
                    {
                        var rasterOptions = new CdrRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                        pdfOptions.VectorRasterizationOptions = rasterOptions;
                        image.Save(outputPath, pdfOptions);
                    }
                }
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
 * 1. When a design studio needs to convert a large collection of CorelDRAW (CDR) artwork into PDF documents that preserve brand‑specific typography by embedding custom fonts during batch processing with Aspose.Imaging for .NET.
 * 2. When an automated publishing pipeline must render multiple CDR files to PDF while ensuring that any non‑standard fonts used in the source files are included in the output so the PDFs display correctly on any device.
 * 3. When a corporate compliance system requires converting confidential CDR reports to PDF with embedded corporate fonts to prevent font substitution and maintain document integrity across different operating systems.
 * 4. When a cloud‑based document conversion service wants to process user‑uploaded CDR files in bulk, apply a custom font directory, and generate PDF files with those fonts embedded for downstream printing workflows.
 * 5. When a legacy graphics archive needs to be migrated to a searchable PDF library, and the migration tool must load each CDR, register custom font sources, and save the rendered pages as PDFs with the original fonts embedded.
 */