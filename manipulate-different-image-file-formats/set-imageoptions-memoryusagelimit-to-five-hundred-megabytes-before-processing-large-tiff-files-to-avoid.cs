using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Configure TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Load the large TIFF image with memory usage limit
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath, new LoadOptions { BufferSizeHint = 500 * 1024 * 1024 }))
            {
                // Save the image using the configured options
                tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When a C# application must convert or copy a multi‑gigabyte TIFF file on a server with limited RAM, setting ImageOptions.MemoryUsageLimit to 500 MB prevents an OutOfMemoryException.
 * 2. When a desktop utility processes high‑resolution scanned documents stored as TIFF images and needs to ensure stable performance on machines with 4 GB of RAM, applying a 500 MB memory cap safeguards the process.
 * 3. When a cloud‑based image‑processing pipeline ingests large TIFF files from a file share and must resize or re‑encode them without exhausting the container’s memory quota, the memory‑usage limit keeps the job alive.
 * 4. When a batch job iterates over a directory of massive TIFF archives to generate compressed copies, configuring BufferSizeHint to 500 MB lets each image load safely before being saved with TiffOptions.
 * 5. When a .NET service extracts metadata from huge TIFF files for a document‑management system, limiting memory usage to 500 MB ensures the service remains responsive and avoids crashes.
 */