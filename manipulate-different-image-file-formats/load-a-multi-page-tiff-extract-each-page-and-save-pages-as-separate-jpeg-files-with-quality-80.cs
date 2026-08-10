// HOW-TO: Extract Multi‑Page TIFF Pages to JPEG with Quality 80 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputPath = @"C:\Temp\input_multi_page.tif";
            string outputDirectory = @"C:\Temp\OutputJpeg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional as per rule)
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Prepare JPEG options with quality 80
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80
                };

                // Iterate over each frame (page) in the TIFF
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.jpg");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as a JPEG file
                    tiffImage.Frames[i].Save(outputPath, jpegOptions);
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
 * 1. When you need to convert each page of a scanned multi‑page TIFF document into separate JPEG images for web preview or thumbnail generation.
 * 2. When a medical imaging system stores patient scans as multi‑frame TIFFs and you must export each frame as a JPEG with a specific compression quality for integration with a PACS viewer.
 * 3. When an archival workflow requires extracting individual pages from a large TIFF file to create JPEG files that can be uploaded to a content management system with size constraints.
 * 4. When a desktop application processes multi‑page TIFF invoices and needs to save each page as a JPEG at quality 80 to balance visual fidelity and file size for email attachment.
 * 5. When a batch script automates the conversion of multi‑page TIFF maps into JPEG tiles, preserving a consistent quality setting for GIS applications.
 */
