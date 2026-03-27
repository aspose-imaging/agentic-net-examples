using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input, output, and fonts folder paths
        string inputPath = "C:\\Input\\sample.emf";
        string outputPath = "C:\\Output\\sample.pdf";
        string fontsFolder = "C:\\Fonts";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure custom font source
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(GetFontSource, fontsFolder);

        // Load EMF image with custom fonts
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Set vector rasterization options for PDF conversion
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save as PDF with embedded fonts
            image.Save(outputPath, pdfOptions);
        }
    }

    // Custom font provider delegate
    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
        var fonts = new System.Collections.Generic.List<Aspose.Imaging.CustomFontHandler.CustomFontData>();

        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
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