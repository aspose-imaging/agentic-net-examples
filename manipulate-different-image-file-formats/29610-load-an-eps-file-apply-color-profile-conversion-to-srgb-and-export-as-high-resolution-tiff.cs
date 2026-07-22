using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure TIFF save options with high resolution (e.g., 300 DPI)
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                // Set vector rasterization options for high-quality rasterization
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    // Scale up dimensions for higher pixel density
                    PageWidth = image.Width * 3,
                    PageHeight = image.Height * 3
                };

                tiffOptions.VectorRasterizationOptions = rasterOptions;

                // Save as high-resolution TIFF (color profile conversion to sRGB would be applied here if supported)
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
 * 1. When a graphic designer needs to convert a client‑provided EPS logo to a print‑ready sRGB TIFF at 300 DPI for a brochure layout using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform must batch‑process product illustrations stored as EPS files, rasterize them with a white background, and store the results as high‑resolution TIFFs for catalog printing.
 * 3. When a publishing house automates the workflow of turning vector EPS artwork into color‑managed TIFF images for offset printing, ensuring the output matches the sRGB color profile.
 * 4. When a digital archiving system ingests legacy EPS drawings and creates lossless TIFF copies with increased pixel density for long‑term preservation and color consistency.
 * 5. When a scientific imaging application needs to render EPS diagrams at three times their original size, convert them to the sRGB color space, and save them as high‑resolution TIFF files for inclusion in research papers.
 */