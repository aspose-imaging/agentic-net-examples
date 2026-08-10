// HOW-TO: Convert Multiple WMF Files to PDF with Table of Contents in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded collection of WMF files to process
            string[] wmfFiles = new[]
            {
                @"C:\Images\first.wmf",
                @"C:\Images\second.wmf"
            };

            // Output directory for all generated PDFs
            string outputDir = @"C:\Output\";
            Directory.CreateDirectory(outputDir);

            // -----------------------------------------------------------------
            // Create a simple Table of Contents PDF listing the file names
            // -----------------------------------------------------------------
            string tocPath = Path.Combine(outputDir, "TableOfContents.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(tocPath));

            // A4 size in points (approx 72 DPI)
            int tocWidth = 595;
            int tocHeight = 842;

            Source tocSource = new FileCreateSource(tocPath, false);
            PdfOptions tocOptions = new PdfOptions() { Source = tocSource };

            using (RasterImage tocCanvas = (RasterImage)Image.Create(tocOptions, tocWidth, tocHeight))
            {
                // Draw the list of file names onto the first page
                Graphics graphics = new Graphics(tocCanvas);
                int y = 50;
                foreach (string wmfPath in wmfFiles)
                {
                    string fileName = Path.GetFileName(wmfPath);
                    graphics.DrawString(
                        fileName,
                        new Font("Arial", 12, FontStyle.Regular),
                        new SolidBrush(Color.Black),
                        50,
                        y);
                    y += 20;
                }

                // Save the TOC PDF (bound image)
                tocCanvas.Save();
            }

            // -----------------------------------------------------------------
            // Convert each WMF file to an individual PDF
            // -----------------------------------------------------------------
            foreach (string wmfPath in wmfFiles)
            {
                if (!File.Exists(wmfPath))
                {
                    Console.Error.WriteLine($"File not found: {wmfPath}");
                    return;
                }

                string pdfPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(wmfPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                using (Image wmfImage = Image.Load(wmfPath))
                {
                    wmfImage.Save(pdfPath, new PdfOptions());
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
 * 1. When you need to bundle several WMF vector drawings into a single PDF report that includes an automatically generated table of contents for easy navigation.
 * 2. When automating the creation of printable documentation from legacy WMF graphics and want each file listed on a TOC page at the beginning of the PDF.
 * 3. When building a batch conversion tool that transforms a collection of WMF assets into PDF pages while providing a summary page with the file names.
 * 4. When integrating Aspose.Imaging into a C# application to generate PDFs from WMF diagrams and include a first‑page index for end‑users.
 * 5. When preparing archival PDFs of engineering schematics stored as WMF files and require an automatically created contents list.
 */
