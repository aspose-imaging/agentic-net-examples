using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outPath = Path.Combine(outputDir, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White
                    };
                    tiffOptions.VectorRasterizationOptions = vectorOptions;

                    if (multipage != null)
                    {
                        tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));
                    }

                    image.Save(outPath, tiffOptions);
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
 * 1. When a CAD application needs to archive each page of a multi‑page EMF drawing as a high‑resolution, print‑ready TIFF for long‑term storage.
 * 2. When a document management system must split a vector‑based EMF report into individual TIFF images to be indexed by OCR engines that only accept raster formats.
 * 3. When a publishing workflow requires converting each page of a multi‑page EMF brochure into separate TIFF files at a specific DPI for high‑quality offset printing.
 * 4. When a legal compliance tool has to generate immutable TIFF copies of each EMF page for electronic evidence preservation and e‑discovery.
 * 5. When a medical imaging platform needs to transform multi‑page EMF schematics into separate high‑resolution TIFFs to embed them into DICOM files for radiology reports.
 */