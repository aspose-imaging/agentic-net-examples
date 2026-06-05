using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/resized.tiff";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new height to keep aspect ratio
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

                // Resize the image
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Prepare TIFF save options
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    // Save the resized image as TIFF
                    image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert a vector EPS logo to a high‑resolution TIFF for print production while preserving the original aspect ratio.
 * 2. When an automated workflow must resize EPS artwork to a fixed width of 2000 px before archiving it as a lossless TIFF file.
 * 3. When a web service generates thumbnails from EPS diagrams and stores them as TIFF images for downstream image‑processing pipelines.
 * 4. When a desktop application imports EPS drawings, scales them to a specific pixel width, and saves the result in TIFF to maintain compatibility with legacy imaging software.
 * 5. When a batch‑processing script validates the existence of EPS files, resizes them uniformly, and outputs TIFF files for use in document management systems.
 */