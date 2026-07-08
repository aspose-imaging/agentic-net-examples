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
            // Hardcoded input, output, and custom font directory paths
            string inputPath = "input.wmf";
            string outputPath = "output/output.jpg";
            string fontFolder = "fonts";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure custom font source via a lambda delegate
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(
                (args) =>
                {
                    var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (args.Length > 0)
                    {
                        string fontsPath = args[0]?.ToString();
                        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                        {
                            foreach (var file in Directory.GetFiles(fontsPath))
                            {
                                byte[] data = File.ReadAllBytes(file);
                                string name = Path.GetFileNameWithoutExtension(file);
                                fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                            }
                        }
                    }
                    return fonts.ToArray();
                },
                fontFolder);

            // Load WMF image with custom fonts
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Set up JPEG export options
                var jpegOptions = new JpegOptions();

                // Save as JPEG
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
 * 1. When a legacy Windows Metafile (WMF) diagram that uses proprietary fonts must be displayed on a web page, a developer can convert it to a JPEG while pointing Aspose.Imaging to a custom font folder to preserve the original text appearance.
 * 2. When an automated reporting system generates charts in WMF format with corporate brand fonts, the code enables batch conversion to JPEG for inclusion in PDF reports, ensuring the brand fonts are loaded from a specified directory.
 * 3. When a document management workflow receives WMF files from external partners who embed custom TrueType fonts, the developer can render those files as JPEG thumbnails by supplying the partner’s font folder to maintain visual fidelity.
 * 4. When a desktop application needs to archive WMF icons that rely on non‑system fonts, this snippet converts each icon to a JPEG image while loading the required fonts from a configurable “fonts” directory.
 * 5. When a migration tool extracts legacy WMF graphics from an old database and must store them as JPEGs for a modern CMS, the code guarantees that any custom fonts referenced in the WMF are correctly applied during conversion.
 */