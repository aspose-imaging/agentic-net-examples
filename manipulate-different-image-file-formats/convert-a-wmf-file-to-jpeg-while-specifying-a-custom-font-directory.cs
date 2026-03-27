using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.jpg";
        string fontDirectory = @"C:\Fonts";

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

            var fontList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
            {
                foreach (var file in Directory.GetFiles(fontsPath))
                {
                    string fontName = Path.GetFileNameWithoutExtension(file);
                    byte[] fontData = File.ReadAllBytes(file);
                    fontList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
                }
            }
            return fontList.ToArray();
        }, fontDirectory);

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            var jpegOptions = new JpegOptions
            {
                Quality = 90,
                VectorRasterizationOptions = vectorOptions
            };

            image.Save(outputPath, jpegOptions);
        }
    }
}