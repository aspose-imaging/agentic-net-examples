using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.pdf";
        string fontsFolder = "fonts";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load options with custom font source for embedding subsets
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(args =>
        {
            var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (args.Length > 0)
            {
                string path = args[0]?.ToString();
                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    foreach (var file in Directory.GetFiles(path))
                    {
                        byte[] data = File.ReadAllBytes(file);
                        string name = Path.GetFileNameWithoutExtension(file);
                        fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
            }
            return fonts.ToArray();
        }, fontsFolder);

        // Load CMX image with custom fonts
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Configure PDF export options with vector rasterization settings
            var pdfOptions = new PdfOptions();
            var rasterOptions = new CmxRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PDF; fonts will be embedded as subsets
            image.Save(outputPath, pdfOptions);
        }
    }
}