using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG file paths
        string[] jpegPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Array to hold corresponding temporary BMP paths
        string[] bmpPaths = new string[jpegPaths.Length];

        // Process each JPEG image
        for (int i = 0; i < jpegPaths.Length; i++)
        {
            string jpegPath = jpegPaths[i];

            // Verify input file exists
            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }

            // Define temporary BMP file name
            string bmpPath = $"temp{i + 1}.bmp";

            // Ensure output directory for BMP exists (guard against null/empty)
            string bmpDir = Path.GetDirectoryName(bmpPath);
            if (!string.IsNullOrWhiteSpace(bmpDir))
            {
                Directory.CreateDirectory(bmpDir);
            }

            // Load JPEG and save as BMP
            using (Image img = Image.Load(jpegPath))
            {
                img.Save(bmpPath, new BmpOptions());
            }

            bmpPaths[i] = bmpPath;
        }

        // Define final PDF output path
        string outputPdf = "merged.pdf";

        // Ensure output directory for PDF exists
        string pdfDir = Path.GetDirectoryName(outputPdf);
        if (!string.IsNullOrWhiteSpace(pdfDir))
        {
            Directory.CreateDirectory(pdfDir);
        }

        // Create a multipage image from BMP files and save as PDF
        using (Image pdf = Image.Create(bmpPaths))
        {
            pdf.Save(outputPdf, new PdfOptions());
        }

        // Clean up temporary BMP files
        foreach (var bmp in bmpPaths)
        {
            if (File.Exists(bmp))
            {
                File.Delete(bmp);
            }
        }
    }
}