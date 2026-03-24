using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // JPEG to PDF
        string jpegInputPath = "input.jpg";
        string jpegOutputPath = Path.Combine("output", "input_from_jpeg.pdf");

        if (!File.Exists(jpegInputPath))
        {
            Console.Error.WriteLine($"File not found: {jpegInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));

        using (Image jpegImage = Image.Load(jpegInputPath))
        {
            var pdfOptions = new PdfOptions();
            jpegImage.Save(jpegOutputPath, pdfOptions);
        }

        // PNG to PDF
        string pngInputPath = "input.png";
        string pngOutputPath = Path.Combine("output", "input_from_png.pdf");

        if (!File.Exists(pngInputPath))
        {
            Console.Error.WriteLine($"File not found: {pngInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

        using (Image pngImage = Image.Load(pngInputPath))
        {
            var pdfOptions = new PdfOptions();
            pngImage.Save(pngOutputPath, pdfOptions);
        }

        // BMP to PDF
        string bmpInputPath = "input.bmp";
        string bmpOutputPath = Path.Combine("output", "input_from_bmp.pdf");

        if (!File.Exists(bmpInputPath))
        {
            Console.Error.WriteLine($"File not found: {bmpInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(bmpOutputPath));

        using (Image bmpImage = Image.Load(bmpInputPath))
        {
            var pdfOptions = new PdfOptions();
            bmpImage.Save(bmpOutputPath, pdfOptions);
        }
    }
}