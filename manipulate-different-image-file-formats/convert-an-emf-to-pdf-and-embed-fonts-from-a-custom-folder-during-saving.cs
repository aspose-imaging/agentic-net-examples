// HOW-TO: Convert EMF to PDF with Custom Font Embedding in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.pdf";
        string customFontsFolder = @"C:\CustomFonts";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Register custom fonts folder for rendering
            FontSettings.SetFontsFolder(customFontsFolder);

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Save as PDF, fonts from the custom folder will be embedded automatically
                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to generate a PDF report from vector EMF graphics while ensuring that corporate fonts stored in a separate folder are embedded for consistent rendering.
 * 2. When an application must batch‑process EMF logos and embed licensed fonts from a custom directory into the resulting PDFs for print‑ready documents.
 * 3. When a web service receives user‑uploaded EMF files and must return PDFs that preserve the original typography by loading fonts from a specified folder.
 * 4. When automating the creation of PDF manuals that contain EMF diagrams and require embedding of specialized engineering fonts located outside the system fonts folder.
 * 5. When integrating Aspose.Imaging into a C# workflow to convert EMF icons to PDF and guarantee that all text appears correctly on machines that do not have the custom fonts installed.
 */
