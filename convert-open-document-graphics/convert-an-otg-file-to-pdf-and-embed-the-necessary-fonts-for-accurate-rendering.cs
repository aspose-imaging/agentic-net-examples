using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input, output, and fonts directories
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.pdf");
        string fontsPath = Path.Combine("Fonts");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load options with custom font source
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(args =>
        {
            var fontDataList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (Directory.Exists(fontsPath))
            {
                foreach (var fontFile in Directory.GetFiles(fontsPath))
                {
                    byte[] data = File.ReadAllBytes(fontFile);
                    string name = Path.GetFileNameWithoutExtension(fontFile);
                    fontDataList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                }
            }
            return fontDataList.ToArray();
        }, fontsPath);

        // Load the OTG image with the custom fonts
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Configure rasterization options for OTG
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            // Set up PDF save options
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}