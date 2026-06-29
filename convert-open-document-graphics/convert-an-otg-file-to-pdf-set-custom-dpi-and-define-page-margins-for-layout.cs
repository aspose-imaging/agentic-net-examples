using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure OTG rasterization options
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    // Set page size to match the source image size
                    PageSize = image.Size,
                    // Define page margins (borders) in points
                    BorderX = 50,
                    BorderY = 50
                };

                // Configure PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Set custom DPI for the PDF output
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    // Attach the vector rasterization options
                    VectorRasterizationOptions = otgOptions
                };

                // Save the image as PDF with the specified options
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
 * 1. When a CAD application exports designs as OTG vector files and the project requires printable PDFs with precise DPI and margin settings for client review.
 * 2. When an engineering workflow needs to batch‑convert OTG schematics to high‑resolution PDF documentation while preserving layout by defining custom page borders.
 * 3. When a web service receives OTG drawings from users and must generate PDF previews with 300 dpi resolution and consistent margins for on‑screen display.
 * 4. When a legal department must archive OTG‑based technical drawings as PDFs with standardized page size and margin constraints to meet filing guidelines.
 * 5. When a desktop utility in C# automates the creation of printable PDFs from OTG files, ensuring the output matches the original image dimensions and includes a 50‑point margin for binding.
 */