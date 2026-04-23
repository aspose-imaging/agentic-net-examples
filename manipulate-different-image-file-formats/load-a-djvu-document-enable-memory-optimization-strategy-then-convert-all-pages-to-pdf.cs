using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = @"C:\Temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load DjVu document with memory optimization (buffer size hint)
            LoadOptions loadOptions = new LoadOptions
            {
                // Example: limit internal buffers to 1 MB
                BufferSizeHint = 1 * 1024 * 1024
            };

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Iterate through each page and save as PDF
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    // Construct output PDF file path for the current page
                    string outputDirectory = @"C:\Temp\PdfOutput";
                    string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.pdf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PDF
                    djvuPage.Save(outputPath, new PdfOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}