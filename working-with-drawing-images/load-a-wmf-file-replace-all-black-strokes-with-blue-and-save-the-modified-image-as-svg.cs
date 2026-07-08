using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\input.wmf";
            string outputPath = @"C:\temp\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Replace black strokes with blue.
                // Note: The actual implementation depends on the internal structure of WMF records.
                // This placeholder demonstrates where such logic would be applied.
                // Example (pseudo-code):
                // foreach (var record in wmfImage.Records)
                // {
                //     if (record is PenRecord pen && pen.Color == Color.Black)
                //         pen.Color = Color.Blue;
                // }

                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                WmfRasterizationOptions rasterizationOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                saveOptions.VectorRasterizationOptions = rasterizationOptions;

                wmfImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert legacy WMF technical drawings to scalable SVG files and replace black strokes with a corporate blue color for consistent branding.
 * 2. When an application must programmatically update black line art in WMF icons to blue before embedding them in a web page that uses SVG for resolution‑independent rendering.
 * 3. When a batch‑processing tool has to modernize old WMF charts by changing their black outlines to blue and saving them as SVG for responsive UI designs.
 * 4. When a document‑generation system requires converting WMF schematics to SVG while applying a blue stroke style to meet accessibility contrast guidelines.
 * 5. When a C# service automates the migration of WMF assets to SVG format and needs to recolor black pen records to blue to match a new visual theme.
 */