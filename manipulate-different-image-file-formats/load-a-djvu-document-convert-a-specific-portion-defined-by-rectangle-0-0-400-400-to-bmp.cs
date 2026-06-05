using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "output\\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Define BMP save options
                    BmpOptions bmpOptions = new BmpOptions();

                    // Define the rectangle area to extract (0,0,400,400)
                    Rectangle bounds = new Rectangle(0, 0, 400, 400);

                    // Save the specified portion as BMP
                    djvuImage.Save(outputPath, bmpOptions, bounds);
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
 * 1. When a developer needs to generate a thumbnail preview of the first page of a multi‑page DjVu file for a document management system, they can extract the top‑left 400×400 pixels and save it as a BMP image.
 * 2. When integrating legacy scanned archives into a .NET application, a developer may convert a specific region of a DjVu scan (e.g., a signature block) to BMP for OCR processing.
 * 3. When creating a printable sample of a large DjVu illustration, a developer can crop the initial 400×400 pixel area and output it as BMP to ensure lossless quality for the sample.
 * 4. When building a web service that returns a BMP snapshot of a DjVu file’s header section, a developer can use the rectangle (0,0,400,400) to extract that portion on demand.
 * 5. When automating batch conversion of DjVu pages to BMP for a digital asset pipeline, a developer can limit each conversion to the top‑left 400×400 region to reduce file size and processing time.
 */