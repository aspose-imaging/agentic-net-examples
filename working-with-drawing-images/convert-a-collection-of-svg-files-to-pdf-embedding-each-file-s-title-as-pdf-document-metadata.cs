using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded collection of SVG input files
        string[] inputFiles = new[]
        {
            @"C:\SvgInput\image1.svg",
            @"C:\SvgInput\image2.svg",
            @"C:\SvgInput\image3.svg"
        };

        // Corresponding PDF output files (same folder, .pdf extension)
        string[] outputFiles = new[]
        {
            @"C:\PdfOutput\image1.pdf",
            @"C:\PdfOutput\image2.pdf",
            @"C:\PdfOutput\image3.pdf"
        };

        for (int i = 0; i < inputFiles.Length; i++)
        {
            string inputPath = inputFiles[i];
            string outputPath = outputFiles[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Extract title from SVG (if present)
            string title = ExtractSvgTitle(inputPath);

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options and set document metadata
                var pdfOptions = new PdfOptions();

                // Create and assign PDF document info with title metadata
                var docInfo = new PdfDocumentInfo();
                docInfo.Title = title ?? Path.GetFileNameWithoutExtension(inputPath);
                pdfOptions.PdfDocumentInfo = docInfo;

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
    }

    // Helper method to read the <title> element from an SVG file
    static string ExtractSvgTitle(string svgPath)
    {
        try
        {
            XDocument doc = XDocument.Load(svgPath);
            XNamespace svgNs = "http://www.w3.org/2000/svg";
            XElement titleElement = doc.Root.Element(svgNs + "title");
            return titleElement?.Value.Trim();
        }
        catch
        {
            // If any error occurs (e.g., malformed XML), return null
            return null;
        }
    }
}