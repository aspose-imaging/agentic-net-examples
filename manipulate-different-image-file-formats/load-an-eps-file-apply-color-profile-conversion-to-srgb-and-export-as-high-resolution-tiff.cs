using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new EpsRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = 3000,
                    PageHeight = 3000
                };

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
                };

                epsImage.Save(outputPath, tiffOptions);
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
 * 1. When a print shop needs to convert client‑provided EPS artwork into a color‑managed sRGB TIFF at high resolution for proofing or pre‑press workflows.
 * 2. When a digital asset management system must ingest vector EPS logos and store them as high‑resolution sRGB TIFF thumbnails for consistent web display.
 * 3. When an e‑commerce platform automates the generation of product catalog images by rasterizing EPS design files into sRGB TIFF files that meet the publisher’s resolution standards.
 * 4. When a publishing house archives legacy EPS illustrations by converting them to color‑corrected sRGB TIFFs to ensure long‑term preservation and compatibility with modern editing tools.
 * 5. When a scientific imaging application needs to render EPS diagrams into high‑resolution sRGB TIFFs for inclusion in research papers and presentations.
 */