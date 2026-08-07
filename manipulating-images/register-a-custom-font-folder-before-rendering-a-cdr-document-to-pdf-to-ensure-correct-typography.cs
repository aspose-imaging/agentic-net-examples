using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input, output and font folder paths
            string inputPath = @"C:\input\sample.cdr";
            string outputPath = @"C:\output\sample.pdf";
            string fontFolder = @"C:\fonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare CDR load options with custom font source
            var loadOptions = new Aspose.Imaging.ImageLoadOptions.CdrLoadOptions();
            loadOptions.AddCustomFontSource(
                args =>
                {
                    string fontsPath = string.Empty;
                    if (args.Length > 0)
                    {
                        fontsPath = args[0]?.ToString();
                    }

                    var customFonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var file in Directory.GetFiles(fontsPath))
                        {
                            string name = Path.GetFileNameWithoutExtension(file);
                            byte[] data = File.ReadAllBytes(file);
                            customFonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                    return customFonts.ToArray();
                },
                fontFolder);

            // Load the CDR image with the custom font options
            using (var image = Image.Load(inputPath, loadOptions))
            {
                // Configure vector rasterization options
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Set up PDF save options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save the CDR document as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert CorelDRAW (CDR) files that use corporate brand fonts into PDF for printing, they register a custom font folder to preserve the exact typography.
 * 2. When an automated document generation service processes user‑uploaded CDR designs on a server that lacks the required fonts, adding a custom font source ensures the resulting PDF matches the original layout.
 * 3. When migrating legacy marketing assets stored as CDR files to a searchable PDF archive, loading custom fonts guarantees that special characters and logo text render correctly.
 * 4. When building a multi‑language e‑catalog that includes CDR graphics with localized fonts, registering a custom font directory before rendering to PDF prevents missing glyphs.
 * 5. When integrating Aspose.Imaging into a CI/CD pipeline that validates visual fidelity of CDR to PDF conversions, supplying a custom font folder allows consistent typography across build agents.
 */