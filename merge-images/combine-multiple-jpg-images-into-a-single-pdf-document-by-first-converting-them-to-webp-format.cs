using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least one output path and one input JPG file.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <output.pdf> <input1.jpg> [<input2.jpg> ...]");
            return;
        }

        string outputPdfPath = args[0];
        var jpgPaths = new List<string>();
        for (int i = 1; i < args.Length; i++)
        {
            jpgPaths.Add(args[i]);
        }

        // Convert each JPG to WebP and collect the temporary WebP paths.
        var webpPaths = new List<string>();
        foreach (string jpgPath in jpgPaths)
        {
            string webpPath = Path.ChangeExtension(jpgPath, ".webp");
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Save as WebP using default options.
                jpgImage.Save(webpPath, new WebPOptions());
            }
            webpPaths.Add(webpPath);
        }

        // Create a multipage image from the WebP files.
        using (Image multiPageImage = Image.Create(webpPaths.ToArray()))
        {
            // Save the multipage image as a PDF document.
            PdfOptions pdfOptions = new PdfOptions();
            multiPageImage.Save(outputPdfPath, pdfOptions);
        }

        // Clean up temporary WebP files.
        foreach (string webpPath in webpPaths)
        {
            if (File.Exists(webpPath))
            {
                File.Delete(webpPath);
            }
        }
    }
}