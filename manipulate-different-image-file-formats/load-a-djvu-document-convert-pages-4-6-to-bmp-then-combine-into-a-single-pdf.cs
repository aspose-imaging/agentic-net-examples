using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.djvu";
            string outputPdfPath = "output/combined.pdf";
            string outputBmpDir = "output/bmp_pages";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(outputBmpDir);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load DjVu document
            using (Image image = Image.Load(inputPath))
            {
                DjvuImage djvu = (DjvuImage)image;

                // Convert pages 4‑6 to BMP
                int[] pageNumbers = { 4, 5, 6 };
                foreach (int pageNum in pageNumbers)
                {
                    int index = pageNum - 1; // zero‑based index
                    if (index < 0 || index >= djvu.Pages.Length)
                        continue;

                    var page = djvu.Pages[index];
                    string bmpPath = Path.Combine(outputBmpDir, $"page{pageNum}.bmp");
                    page.Save(bmpPath, new BmpOptions());
                }

                // Combine pages 4‑6 into a single PDF
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 3, 4, 5 }); // zero‑based pages 4‑6
                djvu.Save(outputPdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}