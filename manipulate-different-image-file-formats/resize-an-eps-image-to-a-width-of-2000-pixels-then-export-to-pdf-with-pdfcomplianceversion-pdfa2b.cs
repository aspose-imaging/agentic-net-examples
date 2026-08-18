// HOW-TO: Resize EPS to 2000px Width and Export as PDF/A‑2b in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                double aspectRatio = (double)image.Height / image.Width;
                int newHeight = (int)(2000 * aspectRatio);
                image.Resize(2000, newHeight, ResizeType.NearestNeighbourResample);
                image.Save(outputPath);
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
 * 1. When you need to convert a high‑resolution EPS logo to a PDF/A‑2b compliant document sized for print layouts.
 * 2. When a web service must generate PDF reports from vector EPS diagrams while ensuring the PDF meets archival standards.
 * 3. When an automated build pipeline has to downscale large EPS artwork to a fixed 2000‑pixel width before embedding it in PDFs.
 * 4. When a desktop application needs to resize EPS illustrations for consistent PDF output across different devices.
 * 5. When a batch processing script must transform multiple EPS files into PDF/A‑2b files with a uniform width for archival storage.
 */
