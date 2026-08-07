using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output locations
            string inputPath = @"C:\Images\input.tif";
            string outputDirectory = @"C:\Images\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Define the action executed before each page is saved
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Build a unique WebP file name for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{index}.webp");

                    // Ensure the directory for the current file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as WebP
                    page.Save(outputPath, new WebPOptions());
                };

                // Trigger the batch export by saving the TIFF to a temporary file.
                // The temporary file is not needed after the operation.
                string tempTiffPath = Path.Combine(outputDirectory, "temp.tif");
                Directory.CreateDirectory(Path.GetDirectoryName(tempTiffPath));
                tiffImage.Save(tempTiffPath);
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
 * 1. When a developer needs to convert a large multi‑page TIFF scan into individual WebP files for faster web loading while keeping memory usage low, they can use this sequential batch export code.
 * 2. When an image‑processing service must generate page‑by‑page WebP previews of a multi‑page TIFF archive without loading the entire document into RAM, this approach provides an efficient solution.
 * 3. When a document‑management system requires extracting each page of a multi‑page TIFF and saving them as WebP thumbnails for mobile devices, the code enables low‑footprint conversion in C#.
 * 4. When a cloud‑based workflow has to batch‑export thousands of TIFF pages to WebP format on a server with limited resources, the page‑exporting action ensures pages are processed one at a time.
 * 5. When a legacy application needs to migrate archived multi‑page TIFF files to modern WebP format for reduced storage costs, this sequential export method avoids loading all pages simultaneously.
 */