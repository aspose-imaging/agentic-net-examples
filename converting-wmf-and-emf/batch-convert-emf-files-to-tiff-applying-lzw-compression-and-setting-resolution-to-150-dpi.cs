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
            // Hardcoded input and output directories
            string inputFolder = "Input";
            string outputFolder = "Output";

            // Validate input directory
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Validate each input file
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Construct output TIFF path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".tif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image and save as TIFF with LZW compression and 150 DPI resolution
                using (Image image = Image.Load(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Lzw;
                    tiffOptions.ResolutionSettings = new ResolutionSetting(150, 150);

                    image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to migrate a legacy collection of vector EMF drawings into compressed TIFF files for archival storage while preserving a 150 DPI resolution.
 * 2. When an automated build pipeline must generate print‑ready TIFF assets from EMF logos, applying LZW compression to reduce file size.
 * 3. When a document management system requires batch conversion of user‑uploaded EMF diagrams to TIFF format with consistent DPI for OCR processing.
 * 4. When a Windows desktop application has to export multiple EMF charts to TIFF for inclusion in PDF reports, ensuring lossless compression and uniform resolution.
 * 5. When a cloud service processes bulk EMF files from a shared folder and needs to output TIFF images with LZW compression and 150 DPI for downstream image analysis.
 */