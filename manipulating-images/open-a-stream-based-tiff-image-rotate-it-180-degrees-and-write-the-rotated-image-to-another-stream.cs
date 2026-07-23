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
            // Hard‑coded input and output file paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the input file as a stream and load it as a TiffImage
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputStream))
            {
                // Rotate the image 180 degrees around its centre, resizing proportionally
                tiffImage.Rotate(180f, true, Aspose.Imaging.Color.Black);

                // Save the rotated image to the output stream
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
 * 1. When a medical imaging system receives a scanned DICOM‑derived TIFF file that was stored upside‑down and needs to rotate it 180° before displaying it to clinicians.
 * 2. When a document management workflow processes multi‑page TIFF invoices that were scanned in reverse orientation and must be corrected using a stream‑based rotation before archiving.
 * 3. When a GIS application imports aerial photography stored as TIFF, rotates the image to match north‑up orientation, and writes the result to a memory or file stream for further analysis.
 * 4. When an e‑commerce platform generates product catalog pages as TIFF files, needs to flip them for right‑to‑left language layouts, and saves the rotated images directly to an output stream.
 * 5. When a batch processing service reads large TIFF files from a network share, rotates each image 180 degrees to correct scanner misalignment, and streams the corrected files to a cloud storage bucket.
 */