using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output\\Thumbnails";

            // Get all JPEG files in the input directory
            var jpegFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (var inputPath in jpegFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_thumb.jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    // Determine thumbnail size (max dimension 150 pixels)
                    const int maxSize = 150;
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;
                    double ratio = Math.Min((double)maxSize / originalWidth, (double)maxSize / originalHeight);

                    if (ratio < 1.0)
                    {
                        int thumbWidth = (int)(originalWidth * ratio);
                        int thumbHeight = (int)(originalHeight * ratio);
                        image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);
                    }

                    // Save thumbnail with JPEG options
                    JpegOptions thumbOptions = new JpegOptions
                    {
                        Quality = 80
                    };
                    image.Save(outputPath, thumbOptions);
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
 * 1. When a web developer needs to create a gallery preview page, they can use this C# Aspose.Imaging code to batch‑process a folder of JPEG photos and generate 150‑pixel thumbnails saved in a dedicated subdirectory.
 * 2. When an e‑commerce platform must display product image previews on search results, the code can automatically scan the product image folder, resize each JPEG to a thumbnail, and store them for fast loading.
 * 3. When a digital asset management system requires periodic thumbnail regeneration after image edits, the snippet can be scheduled to iterate over the JPEG collection, create consistent thumbnail sizes, and place them in an Output\Thumbnails folder.
 * 4. When a mobile app backend needs to reduce bandwidth by serving small preview images, developers can run this batch process to convert high‑resolution JPEG uploads into lightweight thumbnails using Aspose.Imaging in C#.
 * 5. When a content management workflow involves archiving original JPEG files while keeping low‑resolution previews for editors, the code provides a simple way to generate and organize thumbnails alongside the source images.
 */