// HOW-TO: Batch Convert OTG Images to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgToPdfBatchConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output directories
                string inputFolder = @"C:\OTG\Input";
                string outputFolder = @"C:\OTG\Output";

                // Get all OTG files in the input folder
                string[] otgFiles = Directory.GetFiles(inputFolder, "*.otg", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in otgFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output PDF path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load OTG image and save as PDF
                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new PdfOptions());
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to transform a large collection of OTG graphics into searchable PDF documents for archiving.
 * 2. When an automated nightly job must read OTG files from a directory and generate PDF reports without manual intervention.
 * 3. When a web service receives OTG uploads and must store them as PDFs in a separate folder for downstream processing.
 * 4. When migrating legacy OTG assets to a PDF‑based workflow and want a simple C# script to handle the bulk conversion.
 * 5. When integrating Aspose.Imaging into a Windows utility that converts user‑selected OTG images to PDF for printing or sharing.
 */
