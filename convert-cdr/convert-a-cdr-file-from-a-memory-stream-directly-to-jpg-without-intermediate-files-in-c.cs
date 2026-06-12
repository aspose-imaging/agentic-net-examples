using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                CdrImage cdrImage = image as CdrImage;
                if (cdrImage == null)
                {
                    Console.Error.WriteLine("Failed to load CDR image.");
                    return;
                }

                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdrImage.Width,
                        PageHeight = cdrImage.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

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
 * 1. When a web application receives a CorelDRAW (CDR) file as an uploaded memory stream and needs to generate a JPEG preview for display without writing temporary files to disk.
 * 2. When a background service processes a queue of CDR documents stored in a database BLOB column and converts each to a JPEG image for archival or reporting purposes using Aspose.Imaging in C#.
 * 3. When an email automation system must attach a JPEG snapshot of a CDR design that was created in‑memory, ensuring the conversion happens entirely in RAM to improve performance and security.
 * 4. When a cloud‑based document management platform wants to provide on‑the‑fly thumbnail generation for CDR files stored in Azure Blob Storage, converting the stream directly to JPEG to reduce storage costs.
 * 5. When a desktop application allows users to drag‑and‑drop CDR files into a UI component and instantly renders a JPEG version for quick visual feedback without creating intermediate files on the user's machine.
 */