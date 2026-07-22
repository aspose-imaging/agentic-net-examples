using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/output.tiff";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Flip each page horizontally
                foreach (Image pageImage in djvu.Pages)
                {
                    if (pageImage is DjvuPage djvuPage)
                    {
                        djvuPage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                }

                // Save the modified document as a multi-page TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                djvu.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert scanned DjVu documents into multi‑page TIFF files while horizontally flipping each page for correct orientation in archival systems.
 * 2. When an application must batch‑process DjVu files from a legacy scanning workflow, apply a mirror flip to every page, and output a single TIFF for compatibility with document management software.
 * 3. When a .NET service is required to validate the existence of a DjVu source, ensure the output folder exists, and transform the pages into a flipped TIFF for printing on devices that expect mirrored images.
 * 4. When integrating Aspose.Imaging into a C# project to programmatically rotate‑flip DjVu pages before saving them as a TIFF to meet regulatory standards for document presentation.
 * 5. When automating the conversion of DjVu e‑books into flipped multi‑page TIFFs for use in OCR pipelines that only accept TIFF input.
 */