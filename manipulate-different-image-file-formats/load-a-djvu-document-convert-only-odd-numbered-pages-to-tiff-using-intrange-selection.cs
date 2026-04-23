using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputPath = "odd_pages_output.tif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Determine indices of odd‑numbered pages (1‑based odd => 0‑based even)
                List<int> oddPageIndices = new List<int>();
                for (int i = 0; i < djvuImage.PageCount; i++)
                {
                    if (i % 2 == 0) // page numbers 1,3,5,... correspond to indices 0,2,4,...
                    {
                        oddPageIndices.Add(i);
                    }
                }

                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                tiffOptions.BitsPerSample = new ushort[] { 1 };

                // Specify the pages to export using DjvuMultiPageOptions
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(oddPageIndices.ToArray());

                // Save selected pages as a multi‑page TIFF
                djvuImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}