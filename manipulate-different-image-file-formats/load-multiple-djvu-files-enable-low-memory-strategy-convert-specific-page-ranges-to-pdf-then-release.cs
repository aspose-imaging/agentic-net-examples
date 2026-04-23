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
            // Hard‑coded input and output file paths
            string[] inputPaths = { "input1.djvu", "input2.djvu" };
            string[] outputPaths = { "output1.pdf", "output2.pdf" };

            // Define page indexes to export for each file (1‑based indexes)
            int[][] pagesToExport = {
                new int[] { 1, 2, 3 },   // pages for input1.djvu
                new int[] { 2, 3, 4 }    // pages for input2.djvu
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Low‑memory loading options (e.g., 1 MB buffer)
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 1 * 1024 * 1024
                };

                // Load the DjVu document with the specified options
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                {
                    // Configure which pages to export
                    var multiPageOptions = new DjvuMultiPageOptions(pagesToExport[i]);

                    // Set up PDF saving options and attach the page selection
                    var pdfOptions = new PdfOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };

                    // Save the selected pages as a PDF file
                    djvuImage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}