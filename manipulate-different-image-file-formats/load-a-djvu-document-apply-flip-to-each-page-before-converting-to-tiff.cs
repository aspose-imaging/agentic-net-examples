using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                foreach (Image page in djvuImage.Pages)
                {
                    page.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    string outputPath = Path.Combine(outputDirectory, $"page_{((DjvuPage)page).PageNumber}.tiff");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    page.Save(outputPath, new TiffOptions(TiffExpectedFormat.TiffDeflateBw));
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
 * 1. When a developer needs to extract each page of a scanned DjVu document and create horizontally flipped black‑and‑white TIFF files for archival storage.
 * 2. When a document‑management system must preprocess DjVu pages by applying a left‑right flip before converting them to compressed TIFF for OCR processing.
 * 3. When a printing workflow requires converting multi‑page DjVu files into individual TIFF images with a horizontal flip to match printer orientation.
 * 4. When a digital library wants to generate searchable TIFF thumbnails from DjVu books while correcting page orientation using a flip operation.
 * 5. When a batch‑processing tool has to load a DjVu file, apply RotateFlipType.RotateNoneFlipX to every page, and save the results as deflated BW TIFF files for downstream image analysis.
 */