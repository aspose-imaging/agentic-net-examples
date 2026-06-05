using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "corrupted.tif";
            string outputPath = "recovered.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Cast to TiffImage for TIFF-specific operations
                TiffImage tiff = image as TiffImage;
                if (tiff != null)
                {
                    // Example of accessing image properties
                    int width = tiff.Width;
                    int height = tiff.Height;
                    // Additional processing can be performed here
                }

                // Save the recovered image
                image.Save(outputPath);
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
 * 1. When a medical imaging system receives a partially damaged DICOM‑exported TIFF file and needs to recover it with Aspose.Imaging’s ConsistentRecover mode before extracting pixel data for analysis.
 * 2. When a document management workflow encounters a corrupted scanned TIFF invoice and must restore the image to white‑background consistency so it can be indexed and OCR‑processed.
 * 3. When a GIS application loads large satellite TIFF tiles that were truncated during transfer and requires automatic background‑color filling to keep the map rendering pipeline functional.
 * 4. When an e‑commerce platform imports user‑uploaded product photos in TIFF format that contain header errors, and the developer needs to recover the images and then resize them for web thumbnails.
 * 5. When a digital archiving tool processes historic TIFF photographs with missing metadata and must use the first recovery mode to load the images for further color correction and archival storage.
 */