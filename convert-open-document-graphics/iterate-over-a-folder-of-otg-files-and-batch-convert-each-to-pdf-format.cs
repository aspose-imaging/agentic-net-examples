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
            // Hardcoded input and output directories
            string inputFolder = @"C:\OTGFiles";
            string outputFolder = @"C:\OTGFiles\PdfOutput";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all OTG files in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.otg"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PDF path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the OTG image, configure rasterization, and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    // Set up rasterization options to match the source image size
                    OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Configure PDF save options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = otgRasterizationOptions
                    };

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a medical imaging system stores scanned documents as OTG files and the hospital needs to archive them as searchable PDF reports, a developer can use this code to batch convert the folder of OTG images to PDF.
 * 2. When an engineering firm receives design drawings in OTG format from a partner and must deliver them to clients in PDF for universal viewing, the code automates the conversion of all files in a directory.
 * 3. When a legal office digitizes case files as OTG images and wants to create PDF bundles for e‑discovery, the developer can run this C# routine to process the entire folder at once.
 * 4. When a construction company uses a mobile app that captures site photos as OTG files and later needs to generate PDF progress logs, this script iterates through the folder and saves each image as a PDF page.
 * 5. When a publishing workflow receives OTG graphics from a graphic designer and must embed them into PDF catalogs, the code provides a fast way to rasterize each OTG image and save it as a PDF using Aspose.Imaging for .NET.
 */