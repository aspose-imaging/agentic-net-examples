// HOW-TO: Set Custom DPI When Converting PNG to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with custom DPI (e.g., 300 DPI)
                var pdfOptions = new PdfOptions
                {
                    // Do not inherit the original image resolution
                    UseOriginalImageResolution = false,
                    // Set the desired horizontal and vertical resolution
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the image as a PDF with the specified options
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a high‑resolution PDF from a PNG for professional printing, you can set a custom DPI using Aspose.Imaging in C#.
 * 2. When an application must create PDF documents that meet a specific 300 DPI requirement for archival standards, this code ensures the output resolution is controlled.
 * 3. When a web service receives user‑uploaded images and must produce PDF reports with consistent image quality, you can override the original image resolution with a custom DPI setting.
 * 4. When converting low‑resolution screenshots to PDFs for documentation, increasing the DPI prevents blurry text and graphics in the final file.
 * 5. When integrating image processing into a batch workflow that outputs PDFs to a printer that only accepts 300 DPI files, this approach guarantees the correct resolution before saving.
 */
