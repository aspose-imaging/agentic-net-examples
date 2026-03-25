using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine("Input", "sample.cdr");
        string outputPath = Path.Combine("Output", "sample.cdr.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CDR with custom fonts
        var loadOptions = new Aspose.Imaging.ImageLoadOptions.CdrLoadOptions();
        loadOptions.AddCustomFontSource((args) =>
        {
            string fontsPath = "";
            if (args.Length > 0 && args[0] != null)
                fontsPath = args[0].ToString();

            var fontList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
            {
                foreach (var file in Directory.GetFiles(fontsPath))
                {
                    byte[] data = File.ReadAllBytes(file);
                    string name = Path.GetFileNameWithoutExtension(file);
                    fontList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                }
            }
            return fontList.ToArray();
        }, "Fonts");

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
}