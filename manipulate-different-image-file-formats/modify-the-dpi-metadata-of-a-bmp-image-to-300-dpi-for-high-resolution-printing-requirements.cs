using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample_300dpi.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage to access BMP‑specific members
                BmpImage bmpImage = (BmpImage)image;

                // Set horizontal and vertical resolution to 300 DPI
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
 * 1. When a developer needs to prepare BMP graphics for high‑resolution printing, they can use Aspose.Imaging for .NET to set the image DPI to 300 before sending it to a printer.
 * 2. When a desktop publishing workflow requires converting low‑DPI BMP scans into print‑ready assets, the code can adjust the horizontal and vertical resolution to meet 300 DPI specifications.
 * 3. When an automated batch‑processing service must ensure that all BMP files uploaded by users meet the 300 DPI requirement for catalog production, the snippet can be integrated to update the metadata on the fly.
 * 4. When a C# application generates BMP charts that will be embedded in PDF reports intended for professional printing, the developer can call SetResolution to enforce 300 DPI for crisp output.
 * 5. When a legacy system exports BMP images with undefined DPI and a developer needs to standardize them for a marketing campaign’s high‑quality print collateral, this code provides a simple way to set the resolution to 300 DPI.
 */