using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CustomFontHandler;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((args) =>
            {
                string fontsPath = "";
                if (args.Length > 0 && args[0] != null)
                    fontsPath = args[0].ToString();

                var fontList = new List<CustomFontData>();
                if (Directory.Exists(fontsPath))
                {
                    foreach (var file in Directory.GetFiles(fontsPath))
                    {
                        fontList.Add(new CustomFontData(Path.GetFileNameWithoutExtension(file), File.ReadAllBytes(file)));
                    }
                }
                return fontList.ToArray();
            }, "Fonts");

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var vectorOpts = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOpts
                };

                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}