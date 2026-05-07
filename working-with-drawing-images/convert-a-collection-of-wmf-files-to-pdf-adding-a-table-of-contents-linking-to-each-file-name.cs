using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output directories (relative)
            string inputFolder = "Input";
            string outputFolder = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all WMF files in the input folder
            string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

            // List to store generated PDF paths
            List<string> pdfFiles = new List<string>();

            foreach (var wmfPath in wmfFiles)
            {
                // Validate input file existence
                if (!File.Exists(wmfPath))
                {
                    Console.Error.WriteLine($"File not found: {wmfPath}");
                    return;
                }

                // Determine PDF output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(wmfPath);
                string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure output directory for this PDF exists
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                // Load WMF and save as PDF
                using (Image wmfImage = Image.Load(wmfPath))
                {
                    wmfImage.Save(pdfPath, new PdfOptions());
                }

                pdfFiles.Add(pdfPath);
            }

            // Create a simple Table of Contents PDF
            string tocPath = Path.Combine(outputFolder, "TableOfContents.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(tocPath));

            // Define TOC page size (A4 in points)
            int tocWidth = 595;
            int tocHeight = 842;

            // Create a JPEG canvas to draw TOC text, then save as PDF
            Source tocSource = new FileCreateSource(tocPath, false);
            JpegOptions jpegOptions = new JpegOptions { Source = tocSource, Quality = 100 };
            using (JpegImage tocCanvas = (JpegImage)Image.Create(jpegOptions, tocWidth, tocHeight))
            {
                Graphics graphics = new Graphics(tocCanvas);
                graphics.Clear(Color.White);
                Font font = new Font("Arial", 24, FontStyle.Regular);
                int y = 50;
                graphics.DrawString("Table of Contents", font, new SolidBrush(Color.Black), 50, y);
                y += 40;
                foreach (var wmfPath in wmfFiles)
                {
                    string name = Path.GetFileNameWithoutExtension(wmfPath);
                    graphics.DrawString(name, font, new SolidBrush(Color.Blue), 70, y);
                    y += 30;
                }

                // Save the drawn canvas as PDF
                tocCanvas.Save(tocPath, new PdfOptions());
            }

            // Note: Merging the TOC PDF with the individual PDFs into a single document
            // would require additional PDF manipulation not shown here.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}