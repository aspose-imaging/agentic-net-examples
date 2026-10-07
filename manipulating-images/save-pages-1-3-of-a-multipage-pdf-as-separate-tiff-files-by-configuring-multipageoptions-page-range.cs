// HOW-TO: Save Specific PDF Pages as Separate TIFF Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.pdf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            using (Image pdfImage = Image.Load(inputPath))
            {
                for (int i = 1; i <= 3; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"Page{i}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));
                    pdfImage.Save(outputPath, tiffOptions);
                }
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
 * 1. When you need to archive the first three pages of a multi‑page PDF as individual high‑resolution TIFF images for legal or compliance records.
 * 2. When a printing workflow requires extracting specific PDF pages and saving each as a separate TIFF to be processed by a raster image printer.
 * 3. When an application must generate thumbnail previews by converting selected PDF pages to TIFF files for faster loading in a document viewer.
 * 4. When a batch conversion tool must split a multi‑page PDF into separate TIFF files to feed into an OCR engine that only accepts single‑page TIFF inputs.
 * 5. When a medical imaging system stores scanned PDF reports and needs to export particular pages as TIFFs for integration with legacy DICOM software.
 */
