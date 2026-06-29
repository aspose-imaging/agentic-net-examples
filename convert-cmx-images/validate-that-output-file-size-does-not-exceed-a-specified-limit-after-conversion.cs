using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.jpg");
            string outputPath = Path.Combine("Output", "sample.tif");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define maximum allowed output file size (bytes)
            const long maxSizeBytes = 5_000_000; // 5 MB

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
            }

            // Verify output file size
            FileInfo outInfo = new FileInfo(outputPath);
            if (outInfo.Length > maxSizeBytes)
            {
                Console.WriteLine($"Warning: Output file size {outInfo.Length} bytes exceeds the limit of {maxSizeBytes} bytes.");
            }
            else
            {
                Console.WriteLine($"Success: Output file size {outInfo.Length} bytes is within the limit.");
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
 * 1. When a web application must convert user‑uploaded JPEG photos to TIFF for archival storage while ensuring each file stays under a 5 MB limit to comply with storage quotas.
 * 2. When a medical imaging system converts scanned documents to multi‑page TIFF and needs to verify the resulting file does not exceed the maximum size allowed by the PACS server.
 * 3. When an automated batch job processes product catalog images, converting them to TIFF and checking the file size to prevent oversized files from breaking downstream printing pipelines.
 * 4. When a cloud‑based document management service transforms incoming JPEG attachments to TIFF and validates the size to stay within API payload restrictions.
 * 5. When a desktop utility creates TIFF versions of high‑resolution photographs and alerts the user if the saved file surpasses a predefined byte limit to avoid exceeding disk space allocations.
 */