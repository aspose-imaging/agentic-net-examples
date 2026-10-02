// HOW-TO: Batch Apply Custom Fonts to CDR and Export PDFs with Embedded Fonts in C# (Aspose.Imaging for .NET)
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
            string fontsDirectory = Path.Combine(baseDir, "Fonts");

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

            if (!Directory.Exists(fontsDirectory))
            {
                Directory.CreateDirectory(fontsDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                var loadOptions = new LoadOptions();
                loadOptions.AddCustomFontSource(
                    (object[] args) =>
                    {
                        string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                        var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                        {
                            foreach (var fontFile in Directory.GetFiles(fontsPath))
                            {
                                byte[] fontBytes = File.ReadAllBytes(fontFile);
                                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                                result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                            }
                        }
                        return result.ToArray();
                    },
                    fontsDirectory);

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var pdfOptions = new PdfOptions())
                    {
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
 * 1. When a company needs to convert a large collection of CorelDRAW (.cdr) designs into PDF documents while ensuring that all custom typography is preserved and embedded for reliable printing.
 * 2. When an automated publishing workflow must replace missing or outdated fonts in multiple CDR files before generating print‑ready PDFs for distribution.
 * 3. When a SaaS platform offers on‑the‑fly preview of user‑uploaded CDR artwork as PDFs and must embed the specific brand fonts to maintain visual consistency.
 * 4. When a legal or compliance system archives design files as PDFs and requires the original fonts to be embedded to prevent font substitution during later review.
 * 5. When a batch processing script needs to render CDR files to PDFs in a .NET application, loading custom font files from a separate folder to guarantee correct text rendering across different machines.
 */
