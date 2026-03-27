using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputFolder = @"C:\InputWmf";
        string outputFolder = @"C:\OutputJpeg";
        string fontFolder = @"C:\CustomFonts";

        // Get all WMF files in the input folder
        string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

        foreach (string inputPath in wmfFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure LoadOptions with custom font source
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(
                args =>
                {
                    string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                    var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            byte[] fontBytes = File.ReadAllBytes(fontFile);
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                        }
                    }
                    return result.ToArray();
                },
                fontFolder);

            // Load WMF image with custom fonts
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Obtain vector rasterization options for proper rendering
                var vectorRasterizationOptions = (VectorRasterizationOptions)image.GetDefaultOptions(new object[] { Color.White, image.Width, image.Height });

                // Set up JPEG export options
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = vectorRasterizationOptions,
                    Quality = 90
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}