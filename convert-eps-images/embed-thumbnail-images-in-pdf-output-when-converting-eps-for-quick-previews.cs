using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPdfPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                epsImage.Save(outputPdfPath, pdfOptions);
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
 * 1. When a developer needs to generate PDF files from legacy EPS artwork and embed a low‑resolution thumbnail so file explorers or web galleries can display a quick preview without opening the full document.
 * 2. When building an automated document‑management pipeline that ingests EPS logos and converts them to searchable PDFs with an embedded preview image for faster indexing and user browsing.
 * 3. When creating a C# web service that receives EPS design files from clients and returns PDF reports that contain a thumbnail for instant visual confirmation in the client’s UI.
 * 4. When integrating Aspose.Imaging into a desktop publishing application to allow users to export their EPS illustrations as PDFs that show a preview thumbnail in the print dialog or thumbnail pane.
 * 5. When developing a batch‑processing tool that converts a folder of EPS files to PDFs and embeds small preview images to improve performance of document preview components in enterprise content management systems.
 */