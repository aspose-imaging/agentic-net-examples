using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Open input stream and load JPEG image
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (JpegImage jpegImage = new JpegImage(inputStream))
            {
                // Rotate 120 degrees, resize canvas proportionally, fill background with white
                jpegImage.Rotate(120f, true, Aspose.Imaging.Color.White);

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Save rotated image to output stream
                using (FileStream outputStream = File.Create(outputPath))
                {
                    jpegImage.Save(outputStream, jpegOptions);
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
 * 1. When a web service receives a user‑uploaded JPEG via an HTTP stream and must rotate the picture 120° for correct orientation before storing it back to a cloud storage bucket.
 * 2. When a desktop application processes scanned receipts, loading each JPEG from a file stream, rotating them to align text at a 120° angle, and saving the corrected images for OCR.
 * 3. When an automated batch job reads product photos from a network share, rotates them 120° to match a catalog layout, fills empty corners with white, and writes the results to another stream for publishing.
 * 4. When a mobile backend receives camera images as streams, needs to apply a 120° rotation with a white background to meet a printing service’s layout requirements, and then streams the JPEG back to the client.
 * 5. When a document generation system imports JPEG graphics from a database BLOB, rotates them 120° to fit a template, and streams the adjusted images into a PDF creation pipeline.
 */