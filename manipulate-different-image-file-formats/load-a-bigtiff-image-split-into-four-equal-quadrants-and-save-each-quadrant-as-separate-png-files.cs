using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\bigimage.tif";
            string outputPath1 = @"C:\Images\Quadrants\quadrant1.png";
            string outputPath2 = @"C:\Images\Quadrants\quadrant2.png";
            string outputPath3 = @"C:\Images\Quadrants\quadrant3.png";
            string outputPath4 = @"C:\Images\Quadrants\quadrant4.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Determine half dimensions
                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;

                // Define rectangles for the four quadrants
                var rect1 = new Rectangle(0, 0, halfWidth, halfHeight);                     // Top‑Left
                var rect2 = new Rectangle(halfWidth, 0, halfWidth, halfHeight);            // Top‑Right
                var rect3 = new Rectangle(0, halfHeight, halfWidth, halfHeight);           // Bottom‑Left
                var rect4 = new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight);   // Bottom‑Right

                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Ensure output directories exist
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath4));

                // Save each quadrant as a separate PNG file
                image.Save(outputPath1, pngOptions, rect1);
                image.Save(outputPath2, pngOptions, rect2);
                image.Save(outputPath3, pngOptions, rect3);
                image.Save(outputPath4, pngOptions, rect4);
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
 * 1. When a GIS application needs to display sections of a massive satellite BigTIFF map in a web viewer, a developer can split the image into four PNG quadrants for faster loading.
 * 2. When a medical imaging system must extract high‑resolution pathology slides stored as BigTIFF files into smaller PNG tiles for analysis or annotation tools, this code provides the necessary quadrant extraction.
 * 3. When a printing workflow requires converting a large TIFF artwork into separate PNG pieces to fit printer hardware limitations, developers can use this approach to divide the image into equal parts.
 * 4. When a digital archiving solution wants to generate preview thumbnails of each quadrant of a huge scanned document stored as BigTIFF, the code enables creation of PNG previews for quick browsing.
 * 5. When a game development pipeline needs to import a massive texture stored in BigTIFF and break it into four manageable PNG assets for level‑of‑detail rendering, this snippet performs the split automatically.
 */