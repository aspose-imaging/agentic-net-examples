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
            // Hardcoded input and output directory paths
            string inputPath = @"C:\Images\multipage.tif";
            string outputDir = @"C:\Images\Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // JPEG save options with quality 80
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80
                };

                // Iterate through each frame (page) of the TIFF
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.jpg");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as a JPEG file
                    // TiffFrame can be saved directly using the same Save method as Image
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
 * 1. When a medical imaging system stores scanned documents as multi‑page TIFF files and needs to generate individual JPEG previews for web display at a specific quality setting.
 * 2. When a document management workflow must extract each page of a multi‑page TIFF invoice and save them as separate JPEG files for OCR processing while controlling compression quality.
 * 3. When a publishing application converts multi‑page TIFF artwork into high‑quality JPEG images for inclusion in an e‑catalog, using Aspose.Imaging for .NET in C#.
 * 4. When a legacy archival archive contains multi‑page TIFF photographs that must be split into individual JPEG files for mobile app consumption, requiring a consistent quality level of 80.
 * 5. When an automated batch job processes scanned multi‑page TIFF contracts and needs to output each page as a JPEG image with defined compression to reduce storage size.
 */