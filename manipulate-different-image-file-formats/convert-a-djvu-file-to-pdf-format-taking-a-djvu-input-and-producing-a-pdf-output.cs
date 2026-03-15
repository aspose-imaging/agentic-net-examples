using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths for the source DjVu file and the target PDF file
        string inputDjvuPath = "input.djvu";
        string outputPdfPath = "output.pdf";

        // Open a read‑only stream for the DjVu file
        using (FileStream inputStream = File.OpenRead(inputDjvuPath))
        {
            // Load the DjVu document from the stream
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
            {
                // Save the loaded DjVu document as a PDF file
                djvuImage.Save(outputPdfPath, new PdfOptions());
            }
        }
    }
}