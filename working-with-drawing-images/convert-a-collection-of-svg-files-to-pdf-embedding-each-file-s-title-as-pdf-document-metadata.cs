using System;
using System.IO;
using System.Xml;
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
            @"C:\SvgFiles\image1.svg",
            @"C:\SvgFiles\image2.svg",
            @"C:\SvgFiles\image3.svg"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PDF path (same folder, same name with .pdf extension)
            string outputPath = Path.ChangeExtension(inputPath, ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Extract title from SVG (fallback to file name without extension if not found)
            string title = Path.GetFileNameWithoutExtension(inputPath);
            try
            {
                XmlDocument svgDoc = new XmlDocument();
                svgDoc.Load(inputPath);
                XmlNode titleNode = svgDoc.SelectSingleNode("//title");
                if (titleNode != null && !string.IsNullOrWhiteSpace(titleNode.InnerText))
                {
                    title = titleNode.InnerText.Trim();
                }
            }
            catch
            {
                // If any error occurs while reading the SVG, keep the default title
            }

            // Load SVG image and save as PDF with title metadata
            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();

                // Set PDF document metadata
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = title
                };

                // Save to PDF
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}