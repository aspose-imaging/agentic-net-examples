using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CustomFontHandler;

class Program
{
    // Custom font provider – returns all fonts found in the specified folder
    private static CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0)
        {
            fontsPath = args[0]?.ToString() ?? string.Empty;
        }

        var fontList = new List<CustomFontData>();
        foreach (var fontFile in Directory.GetFiles(fontsPath))
        {
            var fontBytes = File.ReadAllBytes(fontFile);
            var fontName = Path.GetFileNameWithoutExtension(fontFile);
            fontList.Add(new CustomFontData(fontName, fontBytes));
        }

        return fontList.ToArray();
    }

    static void Main()
    {
        // Hard‑coded paths – no argument validation
        string inputFolder = @"C:\InputCdr";
        string outputFolder = @"C:\OutputPdf";
        string fontsFolder = @"C:\Fonts";

        try
        {
            // Ensure the output root folder exists
            Directory.CreateDirectory(outputFolder);

            // Get all CDR files in the input folder
            string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (string cdrFilePath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(cdrFilePath))
                {
                    Console.Error.WriteLine($"File not found: {cdrFilePath}");
                    return;
                }

                // Prepare load options with the custom font source
                var loadOptions = new CdrLoadOptions();
                loadOptions.AddCustomFontSource(GetFontSource, fontsFolder);

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(cdrFilePath, loadOptions))
                {
                    // Process each page of the CDR document
                    for (int pageIndex = 0; pageIndex < cdrImage.Pages.Length; pageIndex++)
                    {
                        var page = (CdrImagePage)cdrImage.Pages[pageIndex];

                        // Configure PDF rasterization options
                        var rasterOptions = new CdrRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None,
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        };

                        var pdfOptions = new PdfOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Build output file name (one PDF per page)
                        string outputFileName = Path.Combine(
                            outputFolder,
                            $"{Path.GetFileNameWithoutExtension(cdrFilePath)}_page{pageIndex}.pdf");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFileName));

                        // Save the page as PDF with embedded fonts
                        page.Save(outputFileName, pdfOptions);
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
 * 1. When a design studio needs to convert a batch of CorelDRAW (.cdr) files to PDF while ensuring that all custom corporate fonts are embedded in the resulting PDFs.
 * 2. When an automated publishing pipeline must render multiple CDR illustrations as PDF documents on a server without manual font installation.
 * 3. When a legal compliance system requires PDFs generated from CDR source files to contain embedded fonts to guarantee document fidelity across devices.
 * 4. When a cloud‑based document conversion service wants to process a folder of CDR assets, apply a specific font library, and output PDF files ready for archival.
 * 5. When a QA test suite validates that custom typefaces are correctly applied to CDR drawings after batch conversion to PDF with Aspose.Imaging for .NET.
 */