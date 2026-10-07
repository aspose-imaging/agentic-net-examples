// HOW-TO: Convert WMF to PNG with Custom Font Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.png";
            string fontFolder = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FontSettings.SetFontsFolder(fontFolder);

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                using (var pngOptions = new PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to render vector WMF diagrams that use proprietary fonts on a server that does not have those fonts installed, you can point Aspose.Imaging to a custom font folder and export the image as PNG.
 * 2. When generating thumbnails for legacy Windows Metafile reports in a web application, setting a specific fonts directory ensures text appears correctly in the rasterized PNG output.
 * 3. When automating batch conversion of WMF assets for a mobile app, you can supply a shared font repository so each conversion produces consistent typography without installing fonts on every build machine.
 * 4. When creating PDF or HTML previews from WMF files in a document management system, using FontSettings lets you control which fonts are used before rasterizing the file to PNG for preview.
 * 5. When troubleshooting missing glyphs in WMF to PNG conversions, directing Aspose.Imaging to a custom fonts folder helps isolate font‑related issues and produce accurate raster images.
 */
