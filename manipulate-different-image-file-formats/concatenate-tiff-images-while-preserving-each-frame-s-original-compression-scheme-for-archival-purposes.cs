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
            // Hard‑coded input and output paths
            string[] inputPaths = new string[] { "input1.tif", "input2.tif", "input3.tif" };
            string outputPath = "output.tif";

            // Verify each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the first TIFF as the base image
            using (Image firstImg = Image.Load(inputPaths[0]))
            {
                var baseTiff = (TiffImage)firstImg;

                // Append frames from the remaining TIFF files
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (Image img = Image.Load(inputPaths[i]))
                    {
                        var tiff = (TiffImage)img;
                        baseTiff.Add(tiff); // Preserves each frame's original compression
                    }
                }

                // Save the concatenated multi‑page TIFF
                baseTiff.Save(outputPath);
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
 * 1. When a developer needs to merge multiple scanned TIFF documents into a single multi‑page TIFF for archival while preserving each page’s original compression scheme (e.g., LZW, CCITT).
 * 2. When building a C# application that consolidates medical imaging reports exported as TIFF files into one file for easier storage and compliance auditing without re‑encoding the images.
 * 3. When creating a digital library system that combines separate high‑resolution TIFF photographs into a single catalog file while keeping each image’s native compression intact.
 * 4. When automating the generation of multi‑page TIFF invoices from individual page TIFFs, ensuring the original compression is retained to minimize file size.
 * 5. When developing a document management workflow that appends newly scanned TIFF pages to an existing TIFF archive without losing the original compression settings.
 */