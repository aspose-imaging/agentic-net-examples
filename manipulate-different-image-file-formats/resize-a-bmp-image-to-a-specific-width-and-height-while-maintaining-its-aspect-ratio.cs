using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output/resized.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load BMP image
            using (BmpImage image = (BmpImage)Image.Load(inputPath))
            {
                // Desired maximum dimensions
                int targetWidth = 800;   // example width
                int targetHeight = 600;  // example height

                // Original dimensions
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Compute scaling factor to maintain aspect ratio
                double widthRatio = (double)targetWidth / originalWidth;
                double heightRatio = (double)targetHeight / originalHeight;
                double scale = Math.Min(widthRatio, heightRatio);

                // If the image is already smaller than the target, keep original size
                if (scale > 1.0) scale = 1.0;

                int newWidth = (int)(originalWidth * scale);
                int newHeight = (int)(originalHeight * scale);

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Save the resized BMP
                image.Save(outputPath);
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
 * 1. When a desktop application needs to generate thumbnail previews of user‑uploaded BMP files while preserving the original aspect ratio for a consistent UI layout.
 * 2. When an automated batch‑processing script must downscale large BMP scans to fit within a printable page size of 800×600 pixels without distorting the image.
 * 3. When a game development pipeline requires converting high‑resolution BMP textures to a maximum size for faster loading on low‑end devices while keeping the visual proportions intact.
 * 4. When a document management system resizes BMP screenshots to a standard size before embedding them in PDFs to ensure uniform appearance across different documents.
 * 5. When a web service that accepts BMP uploads needs to resize images to a maximum width and height for storage optimization, using C# and Aspose.Imaging while maintaining the original aspect ratio.
 */