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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            string fontFolder = Path.Combine(baseDir, "Fonts");
            if (!Directory.Exists(fontFolder))
            {
                Directory.CreateDirectory(fontFolder);
            }

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!string.Equals(Path.GetExtension(inputPath), ".wmf", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(Path.GetFileName(inputPath), ".jpg"));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions();
                loadOptions.AddCustomFontSource((args) =>
                {
                    string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                    var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            byte[] data = File.ReadAllBytes(fontFile);
                            string name = Path.GetFileNameWithoutExtension(fontFile);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                    return fonts.ToArray();
                }, fontFolder);

                using (var image = Image.Load(inputPath, loadOptions))
                {
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    };

                    using (var jpegOptions = new JpegOptions
                    {
                        Quality = 90,
                        VectorRasterizationOptions = rasterOptions
                    })
                    {
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