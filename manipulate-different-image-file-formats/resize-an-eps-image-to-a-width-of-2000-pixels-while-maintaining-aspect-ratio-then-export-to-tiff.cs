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
            // Hardcoded input and output paths
            string inputPath = "Input/input.eps";
            string outputPath = "Output/output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate proportional height for the target width of 2000 pixels
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

                // Resize using high‑quality Lanczos resampling
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Save the resized image as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a print shop needs to convert large vector EPS artwork to a high‑resolution TIFF for raster‑based pre‑press workflows while keeping the original proportions.
 * 2. When a web service must generate thumbnail‑size TIFF previews of submitted EPS files for archival storage without distorting the image.
 * 3. When a desktop application automates the preparation of EPS logos for inclusion in PDF reports by resizing them to a fixed width of 2000 px and saving as TIFF.
 * 4. When a batch‑processing script needs to ensure that EPS diagrams fit within a specific pixel width for e‑learning platforms, preserving aspect ratio and using Lanczos resampling for quality.
 * 5. When a document management system imports EPS drawings and requires them to be stored as TIFF images with a consistent width for fast rendering and searchable metadata extraction.
 */