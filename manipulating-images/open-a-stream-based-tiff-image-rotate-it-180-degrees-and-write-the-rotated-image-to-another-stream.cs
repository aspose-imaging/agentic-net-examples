using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the input TIFF image from a file stream
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputStream))
            {
                // Rotate the image 180 degrees around its center, resizing proportionally
                tiffImage.Rotate(180f, true, Aspose.Imaging.Color.Black);

                // Save the rotated image to the output stream (file)
                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    tiffImage.Save(outputStream);
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
 * 1. When a medical imaging application must rotate scanned DICOM‑derived TIFF files 180 degrees before storing them in a PACS archive using C# streams and Aspose.Imaging.
 * 2. When a document management system needs to correct upside‑down multi‑page TIFF invoices received from a fax server and save the corrected images back to a network share.
 * 3. When a GIS tool processes satellite TIFF rasters that were captured with inverted orientation and requires an in‑memory rotation before exporting the data to another service.
 * 4. When an e‑commerce platform automatically flips product catalog TIFF images uploaded by vendors so they display correctly on the website, using stream‑based processing to avoid temporary files.
 * 5. When a digital archiving workflow reads large TIFF scans from a cloud storage stream, rotates them 180° to match the original layout, and writes the adjusted images to a secure output stream for compliance storage.
 */