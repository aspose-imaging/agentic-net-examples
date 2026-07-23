using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.tif";
            string outputPath = @"C:\Output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure multiple font directories (recursive search enabled)
            string[] fontDirectories = new string[]
            {
                @"C:\Fonts\Latin",
                @"C:\Fonts\CJK",
                @"C:\Fonts\Arabic"
            };
            FontSettings.SetFontsFolders(fontDirectories, true);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Save as PDF
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
 * 1. When a multinational company needs to convert scanned TIFF documents containing Latin, CJK, and Arabic text into searchable PDFs, they can use this code to load the appropriate fonts from separate directories.
 * 2. When a legal firm digitizes multilingual contracts stored as TIFF files and must preserve the original script in the resulting PDF, the code ensures the correct fonts are applied during conversion.
 * 3. When a publishing house automates the generation of PDF e‑books from high‑resolution TIFF artwork that includes captions in various languages, configuring multiple font folders guarantees accurate rendering.
 * 4. When a government agency processes archival TIFF images of historical records written in different scripts and needs to produce PDF archives that display the text correctly, this code provides the necessary font resolution.
 * 5. When a medical imaging system exports patient scans saved as TIFF files with embedded annotations in several languages and must create PDF reports that retain those annotations, the code’s FontSettings setup handles the multilingual fonts.
 */