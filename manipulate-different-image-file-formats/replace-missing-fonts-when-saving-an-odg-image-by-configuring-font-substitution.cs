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
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output.pdf";

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
        loadOptions.AddCustomFontSource(GetFontSource, "fonts"); // "fonts" folder contains required fonts

        // Load ODG image with custom fonts
        using (var image = Image.Load(inputPath, loadOptions))
        {
            // Set up ODG rasterization options (used for vector formats like PDF)
            var odgRasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Configure PDF save options with the rasterization settings
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = odgRasterOptions
            };

            // Save the image to PDF, substituting missing fonts with the provided ones
            image.Save(outputPath, pdfOptions);
        }
    }

    // Custom font provider delegate
    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
        var fontDataList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();

        if (Directory.Exists(fontsPath))
        {
            foreach (var fontFile in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                byte[] fontBytes = File.ReadAllBytes(fontFile);
                fontDataList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
            }
        }

        return fontDataList.ToArray();
    }
}