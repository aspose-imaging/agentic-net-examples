using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\large.jpg";
            string outputPath = "Output\\thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image with a memory limit (e.g., 100 MB)
            using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 100 }))
            {
                // Resize to 200x200 thumbnail
                image.Resize(200, 200, ResizeType.NearestNeighbourResample);

                // Save the thumbnail as JPEG using default options
                JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a web application must display preview images of user‑uploaded high‑resolution JPEG photos without exhausting server memory, developers can use this code to load the image with a 100 MB buffer, create a 200×200 thumbnail, and save it as a separate JPEG file.
 * 2. When an e‑commerce platform needs to generate product thumbnail images on the fly from large catalog photos while keeping the process lightweight, this snippet shows how to resize the JPEG using Aspose.Imaging’s memory‑strategy and store the thumbnail for fast page loads.
 * 3. When a desktop photo‑organizer tool wants to create small preview icons for massive JPEG files without loading the entire image into RAM, the example demonstrates loading with BufferSizeHint, resizing to 200 px, and saving the thumbnail for the UI gallery.
 * 4. When a cloud‑based image‑processing pipeline must process batch JPEG uploads under strict memory quotas, developers can apply this code to enforce a memory limit, generate uniform 200×200 thumbnails, and write them to an output folder for downstream services.
 * 5. When a mobile backend service needs to prepare low‑resolution JPEG thumbnails for device sync while ensuring the server stays within a 100 MB memory ceiling, this example illustrates the C# workflow of loading, resizing, and saving the thumbnail using Aspose.Imaging.
 */