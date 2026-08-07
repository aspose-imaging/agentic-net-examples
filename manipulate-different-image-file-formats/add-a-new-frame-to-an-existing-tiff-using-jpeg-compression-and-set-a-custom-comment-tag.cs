using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputTiffPath = "input.tif";
            string newFramePath = "newframe.jpg";
            string outputTiffPath = "output.tif";

            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }
            if (!File.Exists(newFramePath))
            {
                Console.Error.WriteLine($"File not found: {newFramePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputTiffPath))
            {
                using (RasterImage raster = (RasterImage)Image.Load(newFramePath))
                {
                    TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                    frameOptions.Compression = TiffCompressions.Jpeg;

                    TiffFrame newFrame = new TiffFrame(raster, frameOptions);
                    tiffImage.AddFrame(newFrame);
                }

                tiffImage.Save(outputTiffPath);
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
 * 1. When a developer needs to append a newly captured JPEG photograph to an existing multi‑page TIFF archive while using JPEG compression to keep the overall file size low.
 * 2. When building a digital asset management system that stores high‑resolution scans as TIFF and must programmatically add additional images without re‑encoding the entire document.
 * 3. When generating multi‑page medical imaging reports where each new X‑ray image (provided as a JPEG) is inserted into an existing TIFF series for DICOM‑compatible workflows.
 * 4. When creating a multi‑page invoice PDF that is first converted to TIFF and later requires extra pages (such as supplemental terms saved as JPEG) to be appended in a C# application.
 * 5. When a document‑processing service updates an archival TIFF file with a newly scanned page while preserving JPEG compression and ensuring the file remains compatible with downstream image‑processing tools.
 */