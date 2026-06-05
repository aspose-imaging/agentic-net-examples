using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Save the BMP as a TIFF file (initial conversion)
                var tiffSaveOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                bmpImage.Save(outputPath, tiffSaveOptions);
            }

            // Load the newly created TIFF image
            using (Image tiffImg = Image.Load(outputPath))
            {
                // Cast to TiffImage to access Grayscale method
                TiffImage tiffImage = (TiffImage)tiffImg;

                // Convert to grayscale
                tiffImage.Grayscale();

                // Save the grayscale TIFF (overwrites the previous file)
                tiffImage.Save(outputPath);
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
 * 1. When a medical records system needs to convert scanned BMP X‑ray images to lossless grayscale TIFF files for long‑term archival compliance.
 * 2. When a government agency must store historical BMP maps as grayscale TIFFs to reduce file size while preserving detail for future reference.
 * 3. When a publishing workflow requires converting color BMP artwork into grayscale TIFFs before embedding them into print‑ready PDFs.
 * 4. When a document management solution needs to standardize incoming BMP scans by applying a grayscale filter and saving them as TIFF for consistent indexing.
 * 5. When a backup utility archives BMP screenshots by converting them to grayscale TIFF to ensure compatibility with long‑term storage standards.
 */