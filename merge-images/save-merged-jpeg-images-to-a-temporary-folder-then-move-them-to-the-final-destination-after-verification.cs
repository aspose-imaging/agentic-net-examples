using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input JPEG files
            string[] inputPaths = new[]
            {
                @"C:\temp\input1.jpg",
                @"C:\temp\input2.jpg"
            };

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load each JPEG image
            var loadedImages = new List<Image>();
            foreach (var inputPath in inputPaths)
            {
                // Load the image and keep it in the list
                Image img = Image.Load(inputPath);
                loadedImages.Add(img);
            }

            // Create a multipage image from the loaded JPEGs
            Image mergedImage = Image.Create(loadedImages.ToArray());

            // Temporary output path
            string tempOutputPath = @"C:\temp\merged_temp.jpg";

            // Ensure the directory for the temporary file exists
            Directory.CreateDirectory(Path.GetDirectoryName(tempOutputPath));

            // Save the merged image to the temporary location
            mergedImage.Save(tempOutputPath, new JpegOptions());

            // Verify the temporary file was created
            if (!File.Exists(tempOutputPath))
            {
                Console.Error.WriteLine($"Failed to create temporary file: {tempOutputPath}");
                return;
            }

            // Final destination path
            string finalOutputPath = @"C:\output\merged.jpg";

            // Ensure the final directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));

            // If a file already exists at the final location, delete it
            if (File.Exists(finalOutputPath))
            {
                File.Delete(finalOutputPath);
            }

            // Move the verified temporary file to the final destination
            File.Move(tempOutputPath, finalOutputPath);

            // Clean up loaded images
            foreach (var img in loadedImages)
            {
                img.Dispose();
            }
            mergedImage.Dispose();

            Console.WriteLine("Images merged successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to combine multiple user‑uploaded JPEG photos into a single multi‑page image before storing it in a permanent directory, it can use this code to merge the files, save them to a temporary folder, verify the output, and then move the verified file to the final location.
 * 2. When an automated batch‑processing service creates a composite JPEG report from scanned documents and must ensure the merged file is correctly generated before overwriting existing reports, the temporary‑save‑and‑verify pattern shown here guarantees data integrity.
 * 3. When a desktop utility consolidates product catalog images into one JPEG for printing and wants to avoid partial or corrupted files in the output folder, it can write the merged image to a temp path, check its existence, and then move it to the destination folder.
 * 4. When a cloud‑based image‑processing pipeline assembles JPEG thumbnails into a single preview image and needs to handle intermittent I/O failures safely, saving to a temporary location first allows the system to confirm the file before committing it to the final storage bucket.
 * 5. When a document management system merges JPEG pages of a scanned contract and must comply with audit requirements that the final file be verified before being placed in the secure archive, this code provides a reliable temporary‑file verification step prior to moving the merged image.
 */