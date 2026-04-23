using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.CustomFontHandler;

class Program
{
    // Custom font provider delegate
    private static CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0 && args[0] != null)
        {
            fontsPath = args[0].ToString();
        }

        var customFontData = new List<CustomFontData>();
        foreach (var fontFile in Directory.GetFiles(fontsPath))
        {
            customFontData.Add(new CustomFontData(
                Path.GetFileNameWithoutExtension(fontFile),
                File.ReadAllBytes(fontFile)));
        }

        return customFontData.ToArray();
    }

    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Input";
        string outputPath = @"C:\Output";
        string fileName = "sample.cdr";
        string fontFolder = @"C:\Fonts";

        try
        {
            // Verify input file exists
            string inputFile = Path.Combine(inputPath, fileName);
            if (!File.Exists(inputFile))
            {
                Console.Error.WriteLine($"File not found: {inputFile}");
                return;
            }

            // Ensure output directory exists
            string outputFile = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(fileName) + ".pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            // Load CDR with custom font source
            var loadOptions = new CdrLoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, fontFolder);

            using (Image image = Image.Load(inputFile, loadOptions))
            {
                // Prepare rasterization options for PDF
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as PDF
                image.Save(outputFile, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}