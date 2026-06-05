using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "Output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Access the first page (index 0)
                using (Image page = djvuImage.Pages[0])
                {
                    // Define the rectangle area to extract (x, y, width, height)
                    Rectangle rect = new Rectangle(50, 50, 300, 300);

                    // Save the specified portion as PNG
                    page.Save(outputPath, new PngOptions(), rect);
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
 * 1. When a developer needs to extract a thumbnail of a specific region from a multi‑page DjVu document for a web preview, they can load the DjVu file, crop the rectangle (50,50,300,300) and save it as a PNG.
 * 2. When an application must convert a selected area of a scanned DjVu blueprint into a high‑resolution PNG for inclusion in a PDF report, this C# code provides the required image processing steps.
 * 3. When a digital archive wants to generate preview images of annotated sections within DjVu manuscripts, the code can load the first page, extract the defined rectangle, and output a PNG thumbnail.
 * 4. When a document‑management system needs to create a PNG snapshot of a particular region of a DjVu invoice for OCR processing, the snippet demonstrates how to crop and save that area using Aspose.Imaging for .NET.
 * 5. When a developer is building a UI that lets users select a region of a DjVu map and export it as a PNG file, this example shows how to programmatically load the DjVu page, apply the rectangle coordinates, and save the cropped image.
 */