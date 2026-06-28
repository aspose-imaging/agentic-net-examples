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
        string inputPath = "Input\\sample.dng";
        string outputPath = "Output\\sample.tif";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                var dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;
                // Adjust contrast by 30 (range -100 to 100)
                dngImage.AdjustContrast(30f);
                // Save as TIFF
                dngImage.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When a photographer needs to increase the contrast of raw DNG files by 30 % before archiving them as lossless TIFFs for long‑term storage using C# and Aspose.Imaging.
 * 2. When a digital asset management system must automatically enhance raw camera images (DNG) and convert them to TIFF format for compatibility with legacy editing software.
 * 3. When a scientific imaging application requires preprocessing of DNG microscopy images by adjusting contrast and saving the results as TIFF for downstream analysis pipelines.
 * 4. When a printing workflow needs to boost the visual impact of raw DNG scans by 30 % contrast and export them as TIFF files that preserve full color depth for high‑resolution print production.
 * 5. When a batch processing tool written in C# uses Aspose.Imaging to standardize contrast across a collection of DNG files and generate TIFF outputs for web galleries or archival catalogs.
 */