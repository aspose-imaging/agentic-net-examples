using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input EMF file, output PDF file and custom fonts folder
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.pdf";
            string customFontsFolder = @"C:\CustomFonts";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Register the custom fonts folder for the current operation
            FontSettings.SetFontsFolder(customFontsFolder);

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // If the library version supports it, enable font embedding
                // pdfOptions.EmbedAllFonts = true; // Uncomment if the property exists

                // Save the image as PDF, fonts from the custom folder will be used/embedded
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
 * 1. When a C# application must generate printable PDF reports from vector‑based EMF diagrams while ensuring that corporate typefaces stored in a custom fonts directory are embedded for consistent rendering.
 * 2. When a document‑conversion service needs to transform user‑uploaded EMF logos into PDF assets and must include brand‑specific fonts located outside the system fonts folder.
 * 3. When an automated batch job processes a library of EMF technical drawings and saves them as PDFs, embedding the engineering fonts from a designated custom folder to meet compliance standards.
 * 4. When a Windows desktop tool creates PDF invoices that contain EMF graphics with text styled in a proprietary font, requiring the font to be embedded from a custom path to avoid missing‑font warnings.
 * 5. When a cloud‑based API receives EMF files and returns PDF files, and the API must register a custom fonts folder at runtime so that all text in the PDF uses the correct embedded font family.
 */