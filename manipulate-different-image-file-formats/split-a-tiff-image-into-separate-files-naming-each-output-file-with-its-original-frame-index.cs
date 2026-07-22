using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑frame TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Create a new frame based on the current frame
                    TiffFrame newFrame = new TiffFrame(tiffImage.Frames[i]);

                    // Create a new TiffImage containing only this frame
                    using (TiffImage singleFrameImage = new TiffImage(newFrame))
                    {
                        // Build output file path using the original frame index
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑frame TIFF
                        singleFrameImage.Save(outputPath);
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
 * 1. When a medical imaging system receives a multi‑page TIFF scan and must store each slice as an individual file for downstream analysis, developers can use this code to split the TIFF and name each file with its original frame index.
 * 2. When a document management workflow needs to extract each page of a scanned multi‑page TIFF contract into separate files for OCR processing, the code provides a simple C# way to create per‑page TIFFs named by their page number.
 * 3. When a GIS application receives a multi‑band satellite TIFF and wants to isolate each band as its own image file for separate rendering, developers can employ this snippet to generate single‑frame TIFFs with indexed filenames.
 * 4. When an archival system must preserve the original ordering of frames in a multi‑frame TIFF animation by exporting each frame as an individual file for version control, this code automates the extraction and naming based on the frame index.
 * 5. When a printing service needs to split a multi‑page TIFF brochure into separate printable TIFF files while keeping the original sequence, the example shows how to programmatically save each frame as “frame_0.tif”, “frame_1.tif”, etc., using Aspose.Imaging for .NET.
 */