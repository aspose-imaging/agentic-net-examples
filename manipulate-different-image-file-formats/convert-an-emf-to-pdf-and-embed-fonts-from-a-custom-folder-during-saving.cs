using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input, output and custom fonts folder paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.pdf";
            string fontsFolder = @"C:\CustomFonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Preserve the original font folders to restore later
            string[] originalFontFolders = FontSettings.GetFontsFolders();

            // Set the custom fonts folder for this operation
            FontSettings.SetFontsFolders(new string[] { fontsFolder }, true);

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF save options with vector rasterization based on EMF
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save the image as PDF, embedding fonts from the custom folder
                image.Save(outputPath, pdfOptions);
            }

            // Restore the original font folders
            FontSettings.SetFontsFolders(originalFontFolders, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer must convert EMF vector graphics into PDF documents for client‑facing reports while embedding corporate fonts located in a custom directory to preserve branding.
 * 2. When an application generates printable invoices that include EMF logos and needs to embed specific typefaces from a non‑system fonts folder to ensure consistent rendering on any device.
 * 3. When a batch‑processing service transforms a library of EMF schematics into searchable PDFs and must use a custom fonts folder to comply with licensing restrictions on font usage.
 * 4. When a desktop tool creates PDF manuals from EMF illustrations and requires embedding fonts from a designated folder to avoid missing‑font warnings in PDF viewers.
 * 5. When a CI/CD pipeline automates the conversion of EMF assets to PDF for documentation builds and needs to temporarily override system font paths with a custom fonts folder during the save operation.
 */