using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToPdfConverter
{
    static void Main()
    {
        // Define input BMP file and output PDF file paths
        string dataDir = @"C:\temp\";
        string inputBmpPath = Path.Combine(dataDir, "sample.bmp");
        string outputPdfPath = Path.Combine(dataDir, "sample.pdf");

        // Load the BMP image using Aspose.Imaging's load rule
        using (Image bmpImage = Image.Load(inputBmpPath))
        {
            // Save the loaded image as PDF using Aspose.Imaging's save rule
            // PdfOptions is used to specify PDF-specific saving parameters (default options here)
            bmpImage.Save(outputPdfPath, new PdfOptions());
        }
    }
}