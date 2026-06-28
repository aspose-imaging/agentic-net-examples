using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.tga";
            string outputPath = "output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TGA image
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Change DPI from 72 to 300
                tgaImage.HorizontalResolution = 300;
                tgaImage.VerticalResolution = 300;

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save as TIFF
                tgaImage.Save(outputPath, tiffOptions);
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
 * 1. When a game developer needs to export high‑resolution texture assets originally stored as 72 DPI TGA files into 300 DPI TIFFs for print‑ready marketing materials.
 * 2. When a GIS analyst converts legacy TGA satellite imagery to 300 DPI TIFF to meet the resolution requirements of a spatial analysis software that only accepts TIFF input.
 * 3. When a medical imaging software vendor processes TGA scans from legacy equipment and must increase the DPI to 300 before saving as TIFF for compliance with DICOM archiving standards.
 * 4. When an e‑commerce platform prepares product photos saved as TGA files for high‑quality catalog PDFs, requiring a DPI boost to 300 and conversion to TIFF for lossless printing.
 * 5. When a digital archivist migrates low‑resolution TGA artwork to a preservation‑grade 300 DPI TIFF format to ensure future scalability and compatibility with archival image management systems.
 */