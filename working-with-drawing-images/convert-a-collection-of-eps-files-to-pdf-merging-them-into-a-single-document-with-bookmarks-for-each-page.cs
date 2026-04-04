using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input EPS files (hardcoded relative paths)
        string[] epsFiles = {
            "Input/file1.eps",
            "Input/file2.eps",
            "Input/file3.eps"
        };

        // Define output PDF file (hardcoded relative path)
        string outputPath = "Output/merged.pdf";

        // Validate each input file
        foreach (string epsPath in epsFiles)
        {
            if (!File.Exists(epsPath))
            {
                Console.Error.WriteLine($"File not found: {epsPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load all EPS images
        List<Image> epsImages = new List<Image>();
        foreach (string epsPath in epsFiles)
        {
            Image img = Image.Load(epsPath);
            epsImages.Add(img);
        }

        // Create a multipage image from the EPS collection
        using (Image multipage = Image.Create(epsImages.ToArray(), true))
        {
            // Save the multipage image as a single PDF document
            var pdfOptions = new PdfOptions();
            multipage.Save(outputPath, pdfOptions);
        }

        // Dispose loaded EPS images
        foreach (Image img in epsImages)
        {
            img.Dispose();
        }
    }
}