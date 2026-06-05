using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\canvas.html";
        string outputPath = @"C:\Temp\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the input HTML5 Canvas file as a stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Load the image from the stream
                using (Image image = Image.Load(inputStream))
                {
                    // Prepare JPEG save options (default settings)
                    JpegOptions jpegOptions = new JpegOptions();

                    // Save the image as JPEG to the specified output path
                    image.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to archive user‑drawn HTML5 Canvas artwork on the server as a JPEG file for later viewing or printing.
 * 2. When an e‑learning platform converts Canvas diagrams created in the browser into JPEG thumbnails for course catalogs.
 * 3. When a digital signage system receives Canvas images via a network stream and must store them as JPEGs for fast loading on display devices.
 * 4. When a mobile backend processes uploaded Canvas screenshots and saves them as JPEGs to reduce storage size while preserving visual fidelity.
 * 5. When a reporting tool extracts Canvas‑based charts from HTML reports and converts them to JPEG images for inclusion in PDF or email summaries.
 */