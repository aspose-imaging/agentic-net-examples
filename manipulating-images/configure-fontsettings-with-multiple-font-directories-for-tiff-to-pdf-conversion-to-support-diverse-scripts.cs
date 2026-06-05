using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tiff";
        string outputPath = @"C:\Converted\sample.pdf";

        // Hardcoded font directories
        string[] fontDirectories = new string[]
        {
            @"C:\Fonts\Dir1",
            @"C:\Fonts\Dir2"
        };

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

            // Configure Aspose.Imaging to use multiple font folders (recursive search)
            FontSettings.SetFontsFolders(fontDirectories, true);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Save as PDF using default PdfOptions
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
 * 1. When a developer needs to convert scanned multilingual TIFF documents (e.g., Arabic and Chinese) to searchable PDF files and must ensure the correct fonts are available from several custom font folders.
 * 2. When an enterprise application processes batch TIFF invoices stored on a network share and must embed company‑specific TrueType fonts located in different directories before saving them as PDF.
 * 3. When a document management system receives TIFF images from various regional offices, each using local font repositories, and the conversion to PDF must respect those font locations to preserve script rendering.
 * 4. When a C# service generates PDF reports from TIFF charts that include Unicode labels, and the required fonts are installed in separate folders on the server, requiring recursive font discovery.
 * 5. When a legal software platform converts TIFF evidence files containing mixed‑language annotations into PDF while loading fonts from multiple directories to comply with jurisdictional font standards.
 */