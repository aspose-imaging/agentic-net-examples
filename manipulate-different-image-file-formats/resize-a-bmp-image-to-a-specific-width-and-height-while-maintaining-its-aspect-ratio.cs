// HOW-TO: Resize BMP Image to Fit Specific Dimensions While Preserving Aspect Ratio in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Desired dimensions (maintain aspect ratio)
            int targetWidth = 800;   // example width
            int targetHeight = 600;  // example height

            // Load the BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Calculate scaling factor to preserve aspect ratio
                double widthRatio = (double)targetWidth / image.Width;
                double heightRatio = (double)targetHeight / image.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Resize using nearest neighbour resampling (default)
                image.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                // Save as BMP
                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to generate thumbnail previews of BMP files for a file‑manager UI without distorting the images.
 * 2. When preparing BMP assets for a legacy Windows application that only supports images up to a certain resolution.
 * 3. When batch‑processing scanned documents to fit within a printable page size while keeping the original proportions.
 * 4. When converting high‑resolution BMP screenshots to a smaller size for faster web upload but still require the BMP format.
 * 5. When integrating image resizing into an automated build pipeline that validates BMP dimensions before packaging.
 */
