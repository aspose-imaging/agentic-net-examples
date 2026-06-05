using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = "input.tif";
        string outputDirectory = "output_frames";

        try
        {
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
                TiffFrame[] frames = tiffImage.Frames;

                // Iterate over each frame and save it as an individual TIFF file
                for (int i = 0; i < frames.Length; i++)
                {
                    // Create a new TiffImage containing only the current frame
                    using (TiffImage singleFrameImage = new TiffImage(new TiffFrame[] { frames[i] }))
                    {
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
 * 1. When a developer needs to extract individual pages from a multi‑frame TIFF scanned document for separate processing or archival, they can use this C# Aspose.Imaging code to split the file into per‑page TIFFs named by frame index.
 * 2. When an application must convert each frame of a multi‑page medical imaging TIFF (e.g., DICOM‑derived) into separate files for integration with other diagnostic tools, the code provides a straightforward way to save each frame as its own TIFF.
 * 3. When a workflow requires sending individual frames of a multi‑frame satellite imagery TIFF to different micro‑services for analysis, this snippet automates the extraction and naming of each frame in C#.
 * 4. When a developer is building a print‑ready PDF generator that needs separate TIFF files for each page of a scanned book, the example shows how to split the source TIFF and preserve the original order using frame indices.
 * 5. When a content management system must index each page of a multi‑page TIFF separately for search and retrieval, the code demonstrates how to programmatically break the TIFF into single‑frame images with predictable filenames.
 */