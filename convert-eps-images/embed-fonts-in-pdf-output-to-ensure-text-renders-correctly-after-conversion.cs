// HOW-TO: Embed Fonts When Converting EMF to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.emf");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string fontsFolder = "Fonts";
            if (!Directory.Exists(fontsFolder))
            {
                Directory.CreateDirectory(fontsFolder);
            }

            FontSettings.SetFontsFolders(new string[] { fontsFolder }, true);

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate PDF reports from EMF vector diagrams in a C# application and want the text to render correctly on any viewer by embedding the required fonts.
 * 2. When converting legacy Windows Metafile (EMF) files to PDF for long‑term archival and must ensure custom fonts are included in the PDF.
 * 3. When building an automated batch process that transforms multiple EMF assets into self‑contained PDFs on a server, embedding fonts to avoid missing‑font errors.
 * 4. When creating printable PDFs from EMF logos or branding assets in .NET and require the fonts to be embedded so the output looks identical on all platforms.
 * 5. When developing a document generation service that receives EMF input and outputs PDF files, and you need to guarantee consistent text appearance by embedding the source fonts.
 */
