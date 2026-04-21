using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document with a memory‑friendly load option
        using (FileStream stream = File.OpenRead(inputPath))
        {
            LoadOptions loadOptions = new LoadOptions
            {
                // Limit internal buffers to 1 MB (enables memory strategy)
                BufferSizeHint = 1 * 1024 * 1024
            };

            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Prepare PDF save options and specify pages 1‑5
                PdfOptions pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(new int[] { 1, 2, 3, 4, 5 })
                };

                // Save the selected pages as a PDF file
                djvuImage.Save(outputPath, pdfOptions);
            }
        }
    }
}