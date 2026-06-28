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
            string inputPath = Path.Combine("Input", "maps.pdf");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            using (Image pdfImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = pdfImage as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = pdfImage.Width,
                            PageHeight = pdfImage.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                        tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                        pdfImage.Save(outputPath, tiffOptions);
                    }
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
 * 1. When a GIS developer must transform each page of a multi‑page PDF map into separate high‑resolution TIFF files for spatial analysis, this C# Aspose.Imaging code rasterizes the vector content while preserving detail.
 * 2. When an environmental consulting firm needs to batch‑convert vector‑based PDF survey sheets into TIFF images for integration with legacy mapping software, the code provides automated page‑by‑page conversion.
 * 3. When a city planning department requires lossless extraction of individual map layers from a PDF booklet into TIFF format for archival and printing, the example uses IMultipageImage and MultiPageOptions to save each page separately.
 * 4. When a remote‑sensing application demands consistent DPI and white background rendering of PDF cartography before performing image‑based classification, the VectorRasterizationOptions in the code ensure uniform TIFF output.
 * 5. When a construction company wants to generate editable raster images from vector PDF blueprints for on‑site mobile devices, this C# snippet creates per‑page TIFF files that can be easily displayed and annotated.
 */