using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load CDR image from memory stream
            byte[] cdrData = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(cdrData))
            {
                using (CdrImage cdrImage = new CdrImage(memoryStream, new LoadOptions()))
                {
                    // Configure JPEG export options with vector rasterization settings
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Aspose.Imaging.Color.White,
                            PageWidth = cdrImage.Width,
                            PageHeight = cdrImage.Height
                        }
                    };

                    // Save directly to JPEG without intermediate files
                    cdrImage.Save(outputPath, jpegOptions);
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
 * 1. When a web API receives a CorelDRAW (.cdr) file upload and needs to generate a JPEG preview for the user directly from a memory stream, avoiding any temporary files on the server.
 * 2. When a desktop application reads CDR images stored as BLOBs in a database and must export them as high‑resolution JPEGs for printable reports without writing intermediate files to disk.
 * 3. When an automated email service creates a JPEG thumbnail of an attached CDR document from a memory stream to embed in the email body, reducing I/O overhead.
 * 4. When a cloud function processes user‑submitted CDR artwork and converts it to JPEG for display in a mobile app, keeping the entire conversion in memory for better scalability.
 * 5. When a document management system streams CDR files from a network share and generates on‑the‑fly JPEG previews for indexing and search, eliminating the need for intermediate storage.
 */