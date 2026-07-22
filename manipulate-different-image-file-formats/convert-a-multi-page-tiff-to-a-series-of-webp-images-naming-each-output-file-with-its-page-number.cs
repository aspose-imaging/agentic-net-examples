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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputDirectory = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access frames
                TiffImage tiffImage = (TiffImage)image;
                TiffFrame[] frames = tiffImage.Frames;

                for (int i = 0; i < frames.Length; i++)
                {
                    // Build output file path with page number
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.webp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as WebP
                    frames[i].Save(outputPath, new WebPOptions());
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
 * 1. When a developer needs to extract each page of a multi‑page TIFF scan and generate lightweight WebP files for faster web delivery, they can use this code to save each frame as “page_1.webp”, “page_2.webp”, etc.
 * 2. When building a document‑management system that stores scanned PDFs as TIFF and must provide thumbnail previews in a modern browser‑compatible format, this snippet converts each TIFF page to a WebP thumbnail with sequential naming.
 * 3. When creating an automated batch job that archives medical imaging records stored in multi‑page TIFF and wants to reduce storage costs by converting each page to lossless WebP while preserving page order, the code performs the conversion and naming automatically.
 * 4. When developing a digital publishing workflow that receives multi‑page TIFF artwork and needs to supply individual WebP assets for responsive design layouts, this example extracts frames and saves them with page numbers for easy reference.
 * 5. When integrating Aspose.Imaging into a C# application that processes scanned invoices saved as multi‑page TIFF and must send each page as a separate WebP image to a third‑party API, the program handles loading, frame iteration, and numbered output files.
 */