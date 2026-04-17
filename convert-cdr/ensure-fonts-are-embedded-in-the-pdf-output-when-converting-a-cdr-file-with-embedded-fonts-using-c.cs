using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.cdr";
        string outputPath = "Output\\sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load options with custom font source to embed fonts
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(GetFontSource, "Fonts");

        // Load the CDR image with the custom font source
        using (var image = Image.Load(inputPath, loadOptions))
        {
            // Configure PDF save options
            var pdfOptions = new PdfOptions();

            // Configure rasterization options for CDR to ensure fonts are rendered correctly
            var rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
            };

            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PDF with embedded fonts
            image.Save(outputPath, pdfOptions);
        }
    }

    // Custom font provider delegate
    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
        var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();

        if (Directory.Exists(fontsPath))
        {
            foreach (var file in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(file);
                byte[] fontData = File.ReadAllBytes(file);
                fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
            }
        }

        return fonts.ToArray();
    }
}