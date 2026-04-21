using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CustomFontHandler;

class Program
{
    // Custom font source provider that loads all font files from the specified folder
    private static CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0 && args[0] != null)
        {
            fontsPath = args[0].ToString();
        }

        var fontDataList = new List<CustomFontData>();
        if (Directory.Exists(fontsPath))
        {
            foreach (var fontFile in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                byte[] fontBytes = File.ReadAllBytes(fontFile);
                fontDataList.Add(new CustomFontData(fontName, fontBytes));
            }
        }
        return fontDataList.ToArray();
    }

    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample_converted.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Custom fonts directory
        string customFontsFolder = @"C:\CustomFonts";

        // Load the WMF image with custom font source
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(GetFontSource, customFontsFolder);

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Set rasterization options based on the source image size
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // JPEG save options with vector rasterization
            var jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}