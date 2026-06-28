using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "large.jpg";
            string outputPath = "thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG with memory limit (e.g., 50 MB)
            using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 50 }))
            {
                // Resize to 200x200 thumbnail using nearest-neighbour resampling
                image.Resize(200, 200, ResizeType.NearestNeighbourResample);

                // Save thumbnail as JPEG with desired quality
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
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
 * 1. When a web application needs to generate small preview images from large JPEG photos without exhausting server memory, developers can use this code to load the image with a memory‑strategy, resize it to a 200×200 thumbnail, and save it as a separate JPEG file.
 * 2. When an e‑commerce platform wants to create product thumbnail images on the fly from high‑resolution uploads, the code demonstrates how to limit the buffer size, resize the picture, and output a compressed JPEG with a specific quality setting.
 * 3. When a desktop photo‑management tool must batch‑process user‑selected large JPEG files into thumbnail icons for quick browsing, this snippet shows the C# approach using Aspose.Imaging to safely load, resize, and save each image.
 * 4. When a mobile backend service receives user‑uploaded photos and needs to store lightweight preview versions for gallery views, the example illustrates how to apply a memory‑hint, perform nearest‑neighbour resampling, and write the thumbnail as a separate JPEG file.
 * 5. When a content‑delivery network (CDN) automation script needs to generate 200×200 thumbnails for large JPEG assets while controlling memory usage, the code provides a reusable pattern for loading, resizing, and saving the thumbnails with Aspose.Imaging in .NET.
 */