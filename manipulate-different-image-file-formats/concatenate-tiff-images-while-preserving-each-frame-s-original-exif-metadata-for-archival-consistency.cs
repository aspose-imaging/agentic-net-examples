// HOW-TO: Combine Multiple TIFF Files Into a Multi-Page TIFF With EXIF Metadata In C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input TIFF files
            string[] inputPaths = new[]
            {
                @"C:\Images\input1.tif",
                @"C:\Images\input2.tif",
                @"C:\Images\input3.tif"
            };

            // Hard‑coded output TIFF file
            string outputPath = @"C:\Images\output.tif";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load the first TIFF image – it will become the base of the concatenated image
            using (TiffImage result = (TiffImage)Image.Load(inputPaths[0]))
            {
                // Append frames from the remaining TIFF images
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (TiffImage src = (TiffImage)Image.Load(inputPaths[i]))
                    {
                        // Add all frames (including their EXIF metadata) from src to result
                        result.Add(src);
                    }
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the combined multi‑page TIFF
                result.Save(outputPath);
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
 * 1. When archiving scanned documents that include camera information, you can merge several single‑page TIFFs into one multi‑page file while keeping each page’s original EXIF data.
 * 2. When preparing a digital submission for a museum, you may need to combine high‑resolution TIFF images of artwork into a single file without losing the embedded shooting details.
 * 3. When building a batch processing tool that consolidates medical imaging scans, you can concatenate the TIFF frames and retain patient‑specific EXIF metadata for regulatory compliance.
 * 4. When creating a printable PDF from a series of TIFF photographs, you first combine them into a multi‑page TIFF that preserves exposure and orientation metadata for later conversion.
 * 5. When developing a backup script for field‑collected TIFF images, you can merge them into one archive file while ensuring each image’s EXIF tags remain intact for future reference.
 */
