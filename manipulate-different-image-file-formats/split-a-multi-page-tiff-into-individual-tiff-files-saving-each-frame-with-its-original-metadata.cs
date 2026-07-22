using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = @"C:\temp\multipage.tif";
        string outputDirectory = @"C:\temp\output";

        try
        {
            // Verify that the source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage multiPage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate over each frame in the source image
                for (int i = 0; i < multiPage.Frames.Length; i++)
                {
                    // Retrieve the current frame
                    TiffFrame frame = multiPage.Frames[i];

                    // Create a new TiffImage that contains only this frame
                    using (TiffImage singlePage = new TiffImage(frame))
                    {
                        // Build the output file path (preserves original metadata)
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑frame TIFF
                        singlePage.Save(outputPath);
                    }
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
 * 1. When a medical imaging system receives a multi‑page DICOM‑converted TIFF scan and needs to store each slice as a separate TIFF file with its original metadata for PACS integration.
 * 2. When a document management application must extract individual pages from a scanned multi‑page TIFF contract so each page can be indexed, searched, and archived separately while preserving EXIF and TIFF tags.
 * 3. When a printing workflow requires splitting a high‑resolution multi‑page TIFF brochure into single‑page TIFFs to feed each page into a printer that only accepts one image per job, keeping color profile metadata intact.
 * 4. When a GIS developer wants to separate each layer stored as a frame in a multi‑page TIFF satellite image into distinct TIFF files for independent analysis, ensuring geospatial metadata is retained.
 * 5. When an e‑learning platform needs to convert a multi‑page TIFF textbook into individual page images for web delivery, using C# and Aspose.Imaging to preserve page‑level metadata such as resolution and compression settings.
 */