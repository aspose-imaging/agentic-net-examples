using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string fontFolder = "Fonts";

            Directory.CreateDirectory(outputDirectory);
            Directory.CreateDirectory(fontFolder);

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((fontArgs) =>
            {
                string fontsPath = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var file in Directory.GetFiles(fontsPath))
                    {
                        byte[] data = File.ReadAllBytes(file);
                        string name = Path.GetFileNameWithoutExtension(file);
                        fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fonts.ToArray();
            }, fontFolder);

            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.Quality = 90;
                        image.Save(outputPath, jpegOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}