using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\output.pdf";
            string fontsFolderPath = @"C:\Fonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure custom font source delegate
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(
                (object[] args) =>
                {
                    string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                    var fontList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var file in Directory.GetFiles(fontsPath))
                        {
                            byte[] data = File.ReadAllBytes(file);
                            string name = Path.GetFileNameWithoutExtension(file);
                            fontList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                    return fontList.ToArray();
                },
                fontsFolderPath);

            // Load ODG image with custom fonts
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Prepare PDF save options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image to PDF with font substitution
                image.Save(outputPath, pdfOptions);
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
 * 1. When converting OpenDocument Graphics (ODG) files to PDF in a C# application and the source document uses fonts that are not installed on the server, developers can use this code to supply a custom fonts folder and ensure the PDF preserves the original typography.
 * 2. When generating printable reports from ODG templates in an automated workflow, and the deployment environment lacks the required corporate fonts, this approach allows the application to substitute missing fonts during rasterization.
 * 3. When building a document archival system that ingests ODG drawings from various users and must store them as PDF with consistent visual appearance, developers can configure font substitution to avoid missing‑font warnings.
 * 4. When creating a cross‑platform .NET service that renders ODG diagrams to PDF on headless Linux containers, this code enables loading custom font files from a mounted directory to replace unavailable system fonts.
 * 5. When implementing a batch conversion tool that processes a large collection of ODG images into PDFs and needs to guarantee brand‑compliant fonts without installing them on each workstation, the custom font source delegate ensures correct font rendering automatically.
 */