// HOW-TO: Configure Multiple Font Folders for TIFF to PDF Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Output\sample.pdf";

        // Font directories to support diverse scripts
        string[] fontDirectories = new string[]
        {
            @"C:\Fonts\Latin",
            @"C:\Fonts\CJK",
            @"C:\Fonts\Arabic"
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

            // Configure Aspose.Imaging font settings with multiple folders (non‑recursive)
            FontSettings.SetFontsFolders(fontDirectories, recursive: false);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Save as PDF
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
 * 1. When converting scanned documents that contain Latin, CJK, and Arabic text to PDF, you need to point Aspose.Imaging to the appropriate font folders so the characters render correctly.
 * 2. When generating PDF reports from multi‑language TIFF images in a .NET application, setting multiple font directories ensures each script uses the right typeface.
 * 3. When deploying an image‑to‑PDF service on a server that stores fonts in separate directories, you must configure FontSettings non‑recursively to avoid loading unwanted fonts.
 * 4. When processing archival TIFF files with mixed scripts and you want to preserve text appearance in the resulting PDF, adding specific font paths guarantees accurate glyph mapping.
 * 5. When building a batch conversion tool that handles TIFF files from different regions, configuring multiple font folders lets the application support diverse scripts without manual font installation.
 */
