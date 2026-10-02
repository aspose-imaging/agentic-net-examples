// HOW-TO: Batch Convert WMF Files to JPEG with Custom Font Folder in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";
            string fontFolder = "Fonts";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var wmfFiles = Directory.GetFiles(inputDir, "*.wmf");
            foreach (var wmfPath in wmfFiles)
            {
                if (!File.Exists(wmfPath))
                {
                    Console.Error.WriteLine($"File not found: {wmfPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDir, Path.ChangeExtension(Path.GetFileName(wmfPath), ".jpg"));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions();
                loadOptions.AddCustomFontSource((args) =>
                {
                    var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (args != null && args.Length > 0 && args[0] is string folder && Directory.Exists(folder))
                    {
                        foreach (var fontFile in Directory.GetFiles(folder))
                        {
                            byte[] fontBytes = File.ReadAllBytes(fontFile);
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                        }
                    }
                    return result.ToArray();
                }, fontFolder);

                using (WmfImage wmfImage = (WmfImage)Image.Load(wmfPath, loadOptions))
                {
                    var jpegOptions = new JpegOptions();
                    wmfImage.Save(outputPath, jpegOptions);
                }
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
 * 1. When you need to automatically convert a collection of legacy WMF drawings to JPEG images while ensuring the correct fonts are applied from a specific directory.
 * 2. When a reporting system must generate thumbnail previews of WMF charts stored on a server and the fonts used are not installed on the machine.
 * 3. When migrating a design archive that contains WMF files to a web‑friendly format and you have custom corporate fonts located in a separate folder.
 * 4. When building a batch image processing pipeline that reads WMF files, applies custom font resources, and outputs high‑quality JPEGs for use in PDFs or email.
 * 5. When automating the preparation of WMF assets for a mobile app, requiring conversion to JPEG and loading fonts from a bundled font folder to preserve text appearance.
 */
