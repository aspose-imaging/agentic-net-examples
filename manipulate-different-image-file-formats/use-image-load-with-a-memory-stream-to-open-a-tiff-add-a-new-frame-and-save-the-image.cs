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
        string inputPath = "C:\\temp\\input.tif";
        string outputPath = "C:\\temp\\output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            byte[] data = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (TiffImage tiffImage = (TiffImage)Image.Load(ms))
                {
                    var frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                    using (TiffFrame newFrame = new TiffFrame(frameOptions, tiffImage.Width, tiffImage.Height))
                    {
                        tiffImage.AddFrame(newFrame);
                        tiffImage.Save(outputPath);
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
 * 1. When a developer needs to read a multi‑page TIFF from a byte array, add an extra blank frame, and save the updated image to disk using Aspose.Imaging for .NET.
 * 2. When an application receives a scanned document as a memory stream, must append a cover page as a new TIFF frame, and then write the combined file as a .tif.
 * 3. When a service processes uploaded TIFF images entirely in memory to avoid temporary files, adds an additional frame, and persists the result with Image.Save.
 * 4. When a batch job loads existing TIFF files stored as blobs in a database, inserts a metadata frame for OCR information, and writes the modified TIFF back to the file system.
 * 5. When a cloud function reads a TIFF from an HTTP request body, appends an extra page for a signature, and returns the updated image as a downloadable .tif file.
 */