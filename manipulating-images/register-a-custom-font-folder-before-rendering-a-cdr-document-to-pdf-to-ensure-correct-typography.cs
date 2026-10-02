// HOW-TO: Render CorelDRAW CDR to PDF with Custom Font Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";
            string fontFolderPath = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, fontFolderPath);

            using (var image = (CdrImage)Image.Load(inputPath, loadOptions))
            {
                image.Save(outputPath, new PdfOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
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
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a CorelDRAW CDR file to PDF while ensuring that any non‑system fonts used in the design are correctly displayed.
 * 2. When your application must load custom TrueType or OpenType fonts from a specific directory before rendering vector graphics to a PDF.
 * 3. When you want to automate batch processing of CDR documents on a server that does not have the required fonts installed system‑wide.
 * 4. When you are building a document‑generation service that must preserve exact typography from source files by supplying a custom font collection.
 * 5. When you encounter missing glyphs or font substitution errors during CDR‑to‑PDF conversion and need to provide the missing fonts programmatically.
 */
