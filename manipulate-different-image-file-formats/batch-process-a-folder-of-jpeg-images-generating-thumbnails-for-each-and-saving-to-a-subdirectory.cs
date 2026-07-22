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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string extension = Path.GetExtension(inputPath);
                if (!extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_thumb.jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int thumbWidth = 150;
                    int thumbHeight = 150;
                    image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                    JpegOptions jpegOptions = new JpegOptions();
                    jpegOptions.Quality = 80;

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
 * 1. When an e‑commerce site needs to create small preview images for thousands of product photos stored as JPEG files, a developer can use this code to batch‑process the folder and generate 150 × 150 thumbnails in an Output subdirectory.
 * 2. When a digital asset management system must provide quick visual indexes for user‑uploaded JPEG pictures, the snippet can be run nightly to resize each image and store thumbnail versions alongside the originals.
 * 3. When a content‑management workflow requires automatically creating thumbnail previews for blog post images before publishing, the code can scan the Input folder, resize the JPEGs, and save the thumbnails to a separate Output folder.
 * 4. When a mobile app backend needs to reduce bandwidth by serving low‑resolution JPEG thumbnails for gallery views, a developer can employ this batch processing routine to pre‑generate the thumbnails on the server.
 * 5. When a photo‑sharing platform wants to generate consistent square thumbnails for user‑profile pictures stored as JPEGs, this C# example using Aspose.Imaging can resize and save each thumbnail in a dedicated Output directory.
 */