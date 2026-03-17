using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class DjvuToPdfConverter
{
    static void Main()
    {
        // Path to the source DjVu file
        string inputPath = "sample.djvu";
        // Desired path for the resulting PDF file
        string outputPath = "sample.pdf";

        // Open the DjVu file as a read‑only stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            // Load the DjVu document using Aspose.Imaging's LoadDocument method
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
            {
                // Save the loaded DjVu document as a PDF using PdfOptions
                djvuImage.Save(outputPath, new PdfOptions());
            }
        }
    }
}