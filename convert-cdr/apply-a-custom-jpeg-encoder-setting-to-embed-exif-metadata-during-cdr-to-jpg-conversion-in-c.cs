using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG options with EXIF metadata
                var jpegOptions = new JpegOptions
                {
                    Quality = 90, // example quality setting
                    ExifData = new JpegExifData()
                };

                // Populate some EXIF fields
                var exif = jpegOptions.ExifData as JpegExifData;
                if (exif != null)
                {
                    exif.Make = "MyCompany";
                    exif.Model = "CDRtoJPGConverter";
                    exif.Software = "Aspose.Imaging";
                    exif.ImageDescription = "Converted from CDR with embedded EXIF";
                }

                // Save as JPEG with the specified options
                image.Save(outputPath, jpegOptions);
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
 * 1. When a graphic design studio needs to batch‑convert CorelDRAW (.cdr) artwork to JPEG for web galleries while preserving camera‑like EXIF tags for cataloging.
 * 2. When an e‑commerce platform automatically generates product thumbnails from CDR source files and wants to embed brand and software information in the JPEG EXIF fields for SEO and asset tracking.
 * 3. When a digital archiving system migrates legacy CDR illustrations to JPEG and must include descriptive metadata such as image description and creator in the EXIF block for searchable archives.
 * 4. When a mobile app backend processes user‑uploaded CDR designs, converts them to high‑quality JPEG, and adds custom EXIF data to identify the conversion tool and maintain image provenance.
 * 5. When a printing service prepares print‑ready JPEGs from CDR files and needs to embed EXIF metadata like make, model, and software to ensure downstream workflow tools recognize the source and processing parameters.
 */