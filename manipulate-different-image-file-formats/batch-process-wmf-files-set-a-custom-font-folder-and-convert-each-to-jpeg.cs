// HOW-TO: Batch Convert WMF to JPEG with Custom Font Folder in C# (Aspose.Imaging for .NET)
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
            string fontFolderPath = Path.Combine(baseDir, "Fonts");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (var filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                string fileName = Path.GetFileName(filePath);
                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(fileName, ".jpg"));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                LoadOptions loadOptions = new LoadOptions();
                loadOptions.AddCustomFontSource(args =>
                {
                    string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                    var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            byte[] data = File.ReadAllBytes(fontFile);
                            string name = Path.GetFileNameWithoutExtension(fontFile);
                            list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                    return list.ToArray();
                }, fontFolderPath);

                using (Image image = Image.Load(filePath, loadOptions))
                {
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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

/*
 * Real-World Use Cases:
 * 1. When you need to automatically convert a large collection of legacy WMF vector drawings into JPEG thumbnails while ensuring the correct fonts are applied.
 * 2. When a reporting system must generate JPEG images from WMF charts stored in a folder, using a specific font directory to preserve corporate typography.
 * 3. When migrating design assets from a Windows Metafile archive to web‑friendly JPEGs and the files rely on custom TrueType fonts not installed on the server.
 * 4. When a batch image‑processing job has to read all WMF files in an input folder, apply a custom font source, and save the results to an output directory for further processing.
 * 5. When automating document conversion in a C# application and you need to handle missing files gracefully while converting WMF files to JPEG with Aspose.Imaging.
 */
