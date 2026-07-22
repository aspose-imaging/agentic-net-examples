using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.eps";
        string outputPath = @"C:\Images\Resized\output.jpg";

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

            // Load EPS image, resize proportionally to width 2000, and save as JPEG
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new height to maintain aspect ratio
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

                // Resize using high quality interpolation
                image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

                // Save as JPEG (format inferred from file extension)
                image.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to convert a vector EPS logo into a high‑resolution JPEG thumbnail of exactly 2000 px width for web display while preserving the original aspect ratio.
 * 2. When an e‑commerce platform must batch‑process product EPS artwork to generate JPEG images that fit a fixed width constraint for product listings.
 * 3. When a printing service wants to preview customer‑uploaded EPS files as JPEGs at a specific pixel width before sending them to the press.
 * 4. When a mobile app backend needs to resize EPS icons to a 2000‑pixel width JPEG to reduce bandwidth while maintaining visual fidelity.
 * 5. When an automated CI/CD pipeline has to validate EPS assets by rendering them as JPEGs of a standard width for visual regression testing.
 */