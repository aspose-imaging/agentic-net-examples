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
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                // Create a new blank frame with the same dimensions as the first frame
                int width = tiff.Frames[0].Width;
                int height = tiff.Frames[0].Height;
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

                // Insert the new frame at position two (index 1)
                tiff.InsertFrame(1, newFrame);

                // Save the modified TIFF
                tiff.Save(outputPath);
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
 * 1. When converting a multi‑page PDF to TIFF and need to insert a blank cover page as the second frame of the resulting TIFF using Aspose.Imaging for .NET.
 * 2. When processing scanned document batches and must add a separator page between existing pages to meet archival or workflow requirements in a C# TIFF image manipulation routine.
 * 3. When generating a multi‑page TIFF for a printing pipeline and need to insert a color‑calibration frame after the first page to ensure consistent output across printers.
 * 4. When assembling digital invoices as multi‑page TIFF files and require inserting a logo or title page as the second frame before saving the document with Aspose.Imaging.
 * 5. When developing a medical imaging application that extracts DICOM series to TIFF and must add a patient‑information frame at position two to comply with reporting standards.
 */