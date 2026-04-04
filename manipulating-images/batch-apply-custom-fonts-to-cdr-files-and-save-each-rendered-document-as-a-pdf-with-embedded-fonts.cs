using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input, output, and fonts directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDir = Path.Combine(baseDir, "Input");
        string outputDir = Path.Combine(baseDir, "Output");
        string fontsDir = Path.Combine(baseDir, "Fonts");

        // Ensure directories exist
        Directory.CreateDirectory(inputDir);
        Directory.CreateDirectory(outputDir);
        Directory.CreateDirectory(fontsDir);

        // Get all CDR files in the input directory
        string[] files = Directory.GetFiles(inputDir, "*.cdr");
        foreach (var inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Prepare output PDF path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileName + ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load options with custom font source
            var loadOptions = new Aspose.Imaging.LoadOptions();
            loadOptions.AddCustomFontSource((args) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args.Length > 0)
                {
                    string fontsPath = args[0]?.ToString() ?? string.Empty;
                    if (Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            byte[] fontData = File.ReadAllBytes(fontFile);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
                        }
                    }
                }
                return fonts.ToArray();
            }, fontsDir);

            // Load CDR image with custom fonts
            using (var image = (CdrImage)Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                // Configure PDF export options with CDR rasterization settings
                var pdfOptions = new PdfOptions();
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save rendered PDF with embedded fonts
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}