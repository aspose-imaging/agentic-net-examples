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
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, tiffOptions);
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
 * 1. When a print shop needs to convert customer‑submitted EPS artwork into a 300 dpi sRGB TIFF for high‑quality offset printing.
 * 2. When a digital asset management system must ingest vector EPS logos and store them as raster TIFF thumbnails with consistent color across browsers.
 * 3. When a scientific imaging pipeline requires converting EPS diagrams into lossless TIFF files at a specific resolution for inclusion in research publications.
 * 4. When an e‑commerce platform automates the generation of product catalog pages by rasterizing EPS product drawings into sRGB TIFF images for web and print.
 * 5. When a legal document processing tool needs to preserve the exact appearance of EPS signatures by rendering them as high‑resolution TIFF files with a white background.
 */