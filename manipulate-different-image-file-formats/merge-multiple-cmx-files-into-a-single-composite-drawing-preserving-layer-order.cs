using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CMX file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\file1.cmx",
                @"C:\Images\file2.cmx",
                @"C:\Images\file3.cmx"
            };

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Hardcoded output path
            string outputPath = @"C:\Images\merged_output.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a multipage image from the CMX files
            using (Image multipageImage = Image.Create(inputPaths))
            {
                // Save the combined image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                multipageImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}