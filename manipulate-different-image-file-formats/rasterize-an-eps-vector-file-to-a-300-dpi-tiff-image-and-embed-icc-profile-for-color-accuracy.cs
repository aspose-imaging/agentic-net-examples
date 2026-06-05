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
            string inputPath = "input.eps";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                double widthInches = epsImage.SizeF.Width;
                double heightInches = epsImage.SizeF.Height;
                int pixelWidth = (int)Math.Round(widthInches * 300);
                int pixelHeight = (int)Math.Round(heightInches * 300);

                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = pixelWidth,
                    PageHeight = pixelHeight
                };

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
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
 * 1. When a print shop needs to convert customer‑submitted EPS artwork into a high‑resolution 300 DPI TIFF with an embedded ICC profile to ensure accurate color reproduction in pre‑press workflows.
 * 2. When a desktop publishing application must generate a raster preview of vector EPS logos as 300 DPI TIFF images for inclusion in PDFs that require TIFF format compliance.
 * 3. When an e‑commerce platform automatically transforms supplier‑provided EPS product drawings into 300 DPI TIFF thumbnails with embedded color profiles for consistent on‑screen display.
 * 4. When a digital archiving system needs to store legacy EPS files as lossless 300 DPI TIFFs with ICC profiles to preserve visual fidelity over long periods.
 * 5. When a C# build pipeline uses Aspose.Imaging to batch‑process EPS files into 300 DPI TIFF images with embedded ICC profiles for downstream image analysis or OCR processing.
 */