using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the multipage TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Set page exporting action to release resources after each page is saved
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Optional per-page processing (e.g., rotate each page)
                    GC.Collect();
                    ((RasterImage)page).Rotate(90);
                };

                // Save the processed image to the output path
                tiffImage.Save(outputPath);
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
 * 1. When processing a large multi‑page TIFF document on a server with limited RAM, a developer can use sequential export mode to rotate each page and save it without loading the entire file into memory.
 * 2. When converting scanned legal contracts stored as multi‑page TIFFs into a new TIFF where each page must be reoriented, the code lets the developer handle one page at a time to avoid out‑of‑memory errors.
 * 3. When building a desktop application that applies per‑page transformations such as watermarking or rotation to high‑resolution TIFF images, the developer can use this pattern to release resources after each page is saved.
 * 4. When integrating Aspose.Imaging into a batch‑processing pipeline that processes thousands of multi‑page TIFF files, the sequential export approach ensures the pipeline stays memory‑efficient.
 * 5. When creating a cloud function that receives a multi‑page TIFF, modifies each page (e.g., rotating 90°), and returns a new TIFF, the developer can rely on this code to keep the function within the memory limits of the execution environment.
 */