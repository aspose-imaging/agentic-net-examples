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
        string inputPath = "sample.djvu";
        string outputPath = "output/output.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                foreach (Image page in djvu.Pages)
                {
                    if (page is DjvuPage djvuPage)
                    {
                        djvuPage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                }

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffDeflateBw);
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

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
 * 1. When a developer needs to convert scanned book pages stored in a DjVu file into a searchable multi‑page TIFF while mirroring the pages for right‑to‑left languages.
 * 2. When an archival system requires batch processing of DjVu documents to create compressed black‑and‑white TIFF files with a horizontal flip to correct orientation before indexing.
 * 3. When a printing workflow must transform DjVu manuals into multi‑page TIFFs with lossless Deflate compression and flip each page to match printer feed direction.
 * 4. When a document management application needs to load a DjVu image, apply a horizontal flip to every page, and export it as a single TIFF file for compatibility with legacy software.
 * 5. When a legal e‑discovery tool has to preprocess DjVu evidence files by flipping pages and saving them as multi‑page TIFFs for OCR and review.
 */