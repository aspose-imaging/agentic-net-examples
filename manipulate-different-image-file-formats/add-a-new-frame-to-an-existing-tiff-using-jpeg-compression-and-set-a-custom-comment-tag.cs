// HOW-TO: Add JPEG Compressed Frame to Existing TIFF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Jpeg;
                int width = tiffImage.Width;
                int height = tiffImage.Height;
                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

                tiffImage.AddFrame(newFrame);

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;

                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When you need to create a multi‑page TIFF by appending a new JPEG‑compressed image to an existing file in a C# application.
 * 2. When you want to reduce the file size of added pages in a TIFF document by using JPEG compression while preserving the original dimensions.
 * 3. When a document‑management system requires each page of a scanned TIFF to be stored as a separate frame with consistent compression settings.
 * 4. When you are building a batch‑processing tool that updates legacy TIFF archives by inserting additional pages without re‑encoding the whole file.
 * 5. When you need to programmatically generate a TIFF portfolio where new frames are added on the fly using Aspose.Imaging for .NET.
 */
