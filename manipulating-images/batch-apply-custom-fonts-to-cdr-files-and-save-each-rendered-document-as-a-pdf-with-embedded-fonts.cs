using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CustomFontHandler;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Cdr.Objects;

class Program
{
    // Custom font provider – returns all fonts found in the specified folder
    private static CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0 && args[0] != null)
        {
            fontsPath = args[0].ToString();
        }

        var fontList = new List<CustomFontData>();
        if (Directory.Exists(fontsPath))
        {
            foreach (var fontFile in Directory.GetFiles(fontsPath))
            {
                var fontName = Path.GetFileNameWithoutExtension(fontFile);
                var fontBytes = File.ReadAllBytes(fontFile);
                fontList.Add(new CustomFontData(fontName, fontBytes));
            }
        }
        return fontList.ToArray();
    }

    static void Main()
    {
        // Hard‑coded paths
        string inputDir = @"C:\InputCdr";
        string outputDir = @"C:\OutputPdf";
        string fontsDir = @"C:\CustomFonts";

        try
        {
            // Ensure output root exists
            Directory.CreateDirectory(outputDir);

            // Process each CDR file in the input directory
            foreach (var inputPath in Directory.GetFiles(inputDir, "*.cdr"))
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string baseOutputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                // Prepare load options with custom font source
                var loadOptions = new CdrLoadOptions();
                loadOptions.AddCustomFontSource(GetFontSource, fontsDir);

                // Load the CDR image
                using (var cdrImage = (CdrImage)Image.Load(inputPath, loadOptions))
                {
                    // If the document has multiple pages, create a PDF per page
                    for (int i = 0; i < cdrImage.Pages.Length; i++)
                    {
                        var page = (CdrImagePage)cdrImage.Pages[i];

                        // Determine output path for this page
                        string outputPath = baseOutputPath;
                        if (cdrImage.Pages.Length > 1)
                        {
                            outputPath = Path.Combine(outputDir, $"{fileNameWithoutExt}_page{i}.pdf");
                        }

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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

                        // Save the page as PDF with embedded custom fonts
                        page.Save(outputPath, pdfOptions);
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
 * 1. When a design studio needs to convert a large collection of CorelDRAW (.cdr) artwork into PDF portfolios while ensuring that all proprietary typefaces from a custom font folder are embedded for consistent printing.
 * 2. When an automated publishing pipeline must replace missing system fonts in CDR files with company‑specific fonts before generating PDF proofs for client review.
 * 3. When a document management system processes incoming CDR submissions and creates searchable PDFs that retain the original layout by loading custom fonts from a shared network directory.
 * 4. When a marketing department wants to batch render product catalog pages stored as CDR files into PDFs with embedded brand fonts to guarantee correct display on any device.
 * 5. When a legal compliance tool converts archived CDR drawings into PDF/A files and needs to embed the exact fonts used in the original files to meet archival standards.
 */