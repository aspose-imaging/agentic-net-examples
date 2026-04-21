using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";
            string fontFolder = "Fonts";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(fontFolder);

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var file in Directory.GetFiles(fontsPath))
                    {
                        string name = Path.GetFileNameWithoutExtension(file);
                        byte[] data = File.ReadAllBytes(file);
                        fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fonts.ToArray();
            }, fontFolder);

            foreach (var inputPath in Directory.GetFiles(inputDir, "*.wmf"))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    var jpegOptions = new JpegOptions
                    {
                        VectorRasterizationOptions = rasterOptions,
                        Quality = 90
                    };

                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}