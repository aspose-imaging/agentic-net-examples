// HOW-TO: Save EPS Preview As JPEG Image Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "preview.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new EpsRasterizationOptions();
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate a thumbnail JPEG from an EPS file for web preview.
 * 2. When converting vector EPS artwork to a raster JPEG for email attachments.
 * 3. When extracting the embedded preview of a CAD EPS drawing to display in a Windows application.
 * 4. When automating batch processing of EPS files to create JPEG previews for a digital asset management system.
 * 5. When integrating EPS to JPEG conversion into a reporting tool that requires raster images for PDF generation.
 */
