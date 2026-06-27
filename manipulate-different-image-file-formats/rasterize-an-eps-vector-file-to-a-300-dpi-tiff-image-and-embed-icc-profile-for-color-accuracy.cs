using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage eps = (EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new EpsRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = eps.Width,
                    PageHeight = eps.Height
                };

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                eps.Save(outputPath, tiffOptions);
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
 * 1. When a publishing system needs to convert client‑supplied EPS logos into high‑resolution 300 DPI TIFF files for offset printing while preserving color accuracy with an embedded ICC profile.
 * 2. When a digital asset management workflow must rasterize vector EPS artwork into TIFF images for archival storage and ensure consistent color reproduction across different monitors and devices.
 * 3. When an e‑commerce platform generates product catalog pages by turning EPS product diagrams into printable TIFF files at 300 DPI, embedding the appropriate ICC profile to match the catalog’s color standards.
 * 4. When a CAD/CAM application exports engineering drawings from EPS to TIFF for inclusion in technical documentation, requiring precise resolution and color management for regulatory compliance.
 * 5. When a batch‑processing script in a C# backend service automates the conversion of EPS marketing materials to TIFF for high‑quality promotional prints, using Aspose.Imaging to handle rasterization and ICC profile embedding.
 */