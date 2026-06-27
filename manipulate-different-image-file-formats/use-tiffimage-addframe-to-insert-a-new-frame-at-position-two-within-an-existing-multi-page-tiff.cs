using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.tif";
        string outputPath = @"C:\Images\result.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the existing multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create a new frame to insert (could be any supported image)
                // Here we load it from another TIFF file; adjust the path as needed
                TiffFrame newFrame = new TiffFrame(@"C:\Images\newframe.tif");

                // Insert the new frame at index 2 (third position, zero‑based)
                tiffImage.InsertFrame(2, newFrame);

                // Save the modified TIFF to the output path
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
 * 1. When generating a multi‑page scanned document and need to add a cover page after the title page, a developer can use InsertFrame to place the new TIFF frame at index 2.
 * 2. When creating a medical imaging report that combines a new X‑ray image with existing patient scans, InsertFrame lets the developer insert the additional TIFF frame into the middle of the multi‑page file.
 * 3. When building a digital archive of historical photographs and want to insert a newly digitized image between two existing pages, the code can insert the frame at position two without rewriting the whole TIFF.
 * 4. When automating generation of a multi‑page invoice converted to TIFF and need to add a terms‑and‑conditions page after the item list, InsertFrame provides a simple C# way to add the extra frame at the correct index.
 * 5. When developing a document management system that merges scanned forms and must insert a signature page into an existing multi‑page TIFF, the InsertFrame method allows precise placement of the new frame at the third page.
 */