// HOW-TO: Crop Central 500x500 Area from CDR and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int cropWidth = 500;
                int cropHeight = 500;

                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;

                if (left < 0) left = 0;
                if (top < 0) top = 0;
                if (cropWidth > image.Width) cropWidth = image.Width;
                if (cropHeight > image.Height) cropHeight = image.Height;

                var cropRect = new Rectangle(left, top, cropWidth, cropHeight);
                image.Crop(cropRect);

                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract the main part of a CorelDRAW (CDR) illustration and deliver it as a PDF report.
 * 2. When an automated workflow must generate a thumbnail‑like 500×500 PDF from large CDR files for preview purposes.
 * 3. When a document management system requires converting cropped sections of vector drawings into searchable PDF documents.
 * 4. When batch processing of CDR assets is required to produce uniformly sized PDF pages for printing or archiving.
 * 5. When integrating Aspose.Imaging into a C# application to programmatically trim and export CDR graphics without manual editing.
 */
