using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify that the input WMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options
                var pdfOptions = new PdfOptions();

                // Set vector rasterization options to preserve original line thickness and colors
                var vectorOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    // Disable smoothing to keep exact line rendering
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    // Render text as single-bit per pixel to avoid anti‑aliasing changes
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                };

                pdfOptions.VectorRasterizationOptions = vectorOptions;

                // Save the image as PDF
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
 * 1. When a developer needs to convert legacy Windows Metafile (WMF) diagrams into searchable PDF reports while keeping the original line thickness and colors intact.
 * 2. When an engineering application must generate printable PDFs from vector‑based WMF schematics without anti‑aliasing artifacts.
 * 3. When a document management system requires batch conversion of WMF icons to PDF for archival, preserving exact visual fidelity.
 * 4. When a C# desktop tool needs to embed WMF flowcharts into PDF manuals and ensure the lines appear crisp and true to the source.
 * 5. When an automated build pipeline must transform WMF assets into PDF assets for cross‑platform distribution while maintaining original vector styling.
 */