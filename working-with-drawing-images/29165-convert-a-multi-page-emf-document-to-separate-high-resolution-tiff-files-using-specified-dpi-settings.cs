using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPattern = @"C:\Images\output_page_{0}.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Desired DPI settings
        int dpiX = 300;
        int dpiY = 300;

        // Load the EMF document
        using (Image image = Image.Load(inputPath))
        {
            // Check if the image supports multiple pages
            if (image is IMultipageImage multipage && multipage.PageCount > 0)
            {
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    string outputPath = string.Format(outputPattern, i + 1);
                    // Ensure output directory exists
                    string outputDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Configure TIFF save options
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                    // Configure vector rasterization (high‑resolution rendering)
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    tiffOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the current page as a separate TIFF file
                    image.Save(outputPath, tiffOptions);
                }
            }
            else
            {
                // Single‑page EMF handling
                string outputPath = string.Format(outputPattern, 1);
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);

                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };
                tiffOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, tiffOptions);
            }
        }
    }
}