using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CMX image with custom fonts
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(GetFontSource, "fonts"); // folder containing font files

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Configure PDF export options with vector rasterization settings
            var pdfOptions = new PdfOptions();
            var rasterOptions = new CmxRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
                // FontEmbeddingMode = FontEmbeddingMode.Subset // Uncomment if property exists
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }

    // Custom font provider returning font data for embedding
    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
        var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();

        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
        {
            foreach (var file in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(file);
                byte[] fontBytes = File.ReadAllBytes(file);
                fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
            }
        }

        return fonts.ToArray();
    }
}