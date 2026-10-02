// HOW-TO: Convert WMF to JPEG with Custom Font Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output.jpg";
            string fontFolder = "fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        byte[] fontBytes = File.ReadAllBytes(fontFile);
                        string fontName = Path.GetFileNameWithoutExtension(fontFile);
                        list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                    }
                }
                return list.ToArray();
            }, fontFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to render a WMF diagram that uses proprietary fonts on a server that doesn’t have those fonts installed, you can load the WMF with a custom font directory and save it as a JPEG for web display.
 * 2. When generating thumbnails of legacy vector graphics for a reporting dashboard, you can convert WMF files to JPEG while supplying the required fonts to preserve text appearance.
 * 3. When automating batch conversion of WMF assets in a CI pipeline and the source files rely on specific font files, you can point Aspose.Imaging to a font folder to ensure accurate conversion to JPEG.
 * 4. When creating printable previews of WMF‑based logos in a C# desktop application, you can load the vector file with custom fonts and export it as a high‑quality JPEG image.
 * 5. When migrating old Windows Metafile icons to a modern image format for mobile apps, you can use this code to embed missing fonts from a folder and output JPEG files that retain the original look.
 */
