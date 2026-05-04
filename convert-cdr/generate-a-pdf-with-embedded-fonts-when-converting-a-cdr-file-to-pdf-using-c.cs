using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.cdr";
        string outputPath = "Output\\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Folder containing custom fonts
            string fontsFolder = "Fonts";
            Directory.CreateDirectory(fontsFolder);

            var loadOptions = new Aspose.Imaging.ImageLoadOptions.CdrLoadOptions();
            loadOptions.AddCustomFontSource((args) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args.Length > 0)
                {
                    string path = args[0]?.ToString() ?? string.Empty;
                    if (Directory.Exists(path))
                    {
                        foreach (var file in Directory.GetFiles(path))
                        {
                            string name = Path.GetFileNameWithoutExtension(file);
                            byte[] data = File.ReadAllBytes(file);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                }
                return fonts.ToArray();
            }, fontsFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var pdfOptions = new PdfOptions();

                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}