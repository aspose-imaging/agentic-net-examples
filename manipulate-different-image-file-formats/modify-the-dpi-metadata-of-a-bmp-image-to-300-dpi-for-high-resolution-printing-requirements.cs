using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_300dpi.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage to access SetResolution
                BmpImage bmpImage = (BmpImage)image;

                // Set horizontal and vertical DPI to 300
                bmpImage.SetResolution(300.0, 300.0);

                // Save the modified image
                bmpImage.Save(outputPath);
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
 * 1. When a developer needs to prepare a BMP logo for a high‑resolution brochure, they can use this code to set the image DPI to 300 before sending it to the printer.
 * 2. When an automated build pipeline generates BMP screenshots that must meet print‑ready specifications, the snippet updates the DPI metadata to 300 DPI automatically.
 * 3. When a desktop application allows users to export diagrams as BMP files for large‑format posters, the code ensures the exported files have 300 DPI for crisp printing.
 * 4. When a document management system ingests BMP scans and must standardize them for archival quality, the developer can apply this routine to enforce a 300 DPI resolution.
 * 5. When a batch‑processing tool converts scanned BMP images to a print‑ready format, the example provides a simple way to adjust the horizontal and vertical DPI to 300 DPI.
 */