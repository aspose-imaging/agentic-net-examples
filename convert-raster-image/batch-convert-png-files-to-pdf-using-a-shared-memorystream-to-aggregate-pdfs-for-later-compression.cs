using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputPngs";
        string outputDirectory = @"C:\OutputPdfs";

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Input directory does not exist: {inputDirectory}");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files (will filter PNGs later)
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        // List to hold PDF byte arrays for later compression
        List<byte[]> pdfByteList = new List<byte[]>();

        foreach (string filePath in files)
        {
            // Process only PNG files
            if (!filePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                continue;

            // Verify input file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Determine output PDF path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".pdf");

            // Ensure output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG image
            using (Image image = Image.Load(filePath))
            {
                // Prepare PDF options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Save PDF to a shared MemoryStream (as byte array)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, pdfOptions);
                        pdfByteList.Add(ms.ToArray());
                    }

                    // Also save PDF to file
                    image.Save(outputPath, pdfOptions);
                }
            }
        }

        // At this point pdfByteList contains all PDFs in memory for further processing/compression
        // Example placeholder for later compression logic:
        // CompressPdfs(pdfByteList);
    }
}