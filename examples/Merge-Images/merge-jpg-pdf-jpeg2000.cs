using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG file path
        string inputJpgPath = "input.jpg";

        // Temporary JPEG2000 file path
        string tempJp2Path = "temp.jp2";

        // Output PDF file path
        string outputPdfPath = "output.pdf";

        // Convert JPG to JPEG2000
        Jpeg2000Options jp2Options = new Jpeg2000Options();
        Source jp2Source = new FileCreateSource(tempJp2Path, false);
        jp2Options.Source = jp2Source;

        using (Image jpgImage = Image.Load(inputJpgPath))
        {
            jpgImage.Save(tempJp2Path, jp2Options);
        }

        // Load the JPEG2000 image and save it as PDF
        PdfOptions pdfOptions = new PdfOptions();

        using (Image jp2Image = Image.Load(tempJp2Path))
        {
            jp2Image.Save(outputPdfPath, pdfOptions);
        }

        // Clean up temporary JPEG2000 file
        if (File.Exists(tempJp2Path))
        {
            File.Delete(tempJp2Path);
        }
    }
}