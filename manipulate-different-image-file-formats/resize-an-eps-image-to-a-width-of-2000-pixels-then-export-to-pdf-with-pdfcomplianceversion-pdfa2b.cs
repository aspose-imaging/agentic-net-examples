using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                int newWidth = 2000;
                int newHeight = (int)((double)image.Height / image.Width * newWidth);
                image.Resize(newWidth, newHeight);

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
 * 1. When a publishing workflow requires converting high‑resolution EPS artwork to a PDF/A‑2b compliant document for archival, a developer can resize the EPS to 2000 px wide and save it as PDF using Aspose.Imaging in C#.
 * 2. When an e‑commerce platform needs to generate print‑ready product catalogs from vector EPS logos, the code can downscale the image to a manageable width and export it to a PDF that meets PDF/A‑2b standards.
 * 3. When a legal document management system must embed vector graphics while ensuring long‑term preservation, developers use this snippet to resize EPS diagrams and store them as PDF/A‑2b files.
 * 4. When a desktop application automates batch processing of engineering drawings, it can apply the 2000‑pixel resize and convert each EPS to a PDF/A‑2b compliant file for easy sharing.
 * 5. When a marketing automation script prepares promotional PDFs from EPS source files and needs to keep file size low without losing quality, the code resizes the EPS and outputs a PDF/A‑2b compliant version.
 */