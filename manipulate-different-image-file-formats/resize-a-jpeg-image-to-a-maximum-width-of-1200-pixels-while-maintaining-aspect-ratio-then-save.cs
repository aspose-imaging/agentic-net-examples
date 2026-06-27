using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_resized.jpg";

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

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                const int maxWidth = 1200;

                // Determine if resizing is needed
                if (jpegImage.Width > maxWidth)
                {
                    // Calculate new height to maintain aspect ratio
                    int newWidth = maxWidth;
                    int newHeight = (int)Math.Round((double)jpegImage.Height * newWidth / jpegImage.Width);

                    // Resize the image
                    jpegImage.Resize(newWidth, newHeight);
                }

                // Save the resized image
                jpegImage.Save(outputPath);
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded JPEG photos while keeping the original aspect ratio, this C# Aspose.Imaging code can resize images to a maximum width of 1200 px before saving.
 * 2. When an e‑commerce platform must optimize product images for faster page loads by limiting JPEG width to 1200 pixels without distortion, developers can use this snippet to resize and preserve quality.
 * 3. When a digital asset management system processes batch uploads and has to ensure all JPEG files conform to a maximum width of 1200 px for consistent display across devices, the code provides a reliable C# solution.
 * 4. When a mobile‑first website requires server‑side image scaling of high‑resolution JPEGs to fit responsive layouts while maintaining aspect ratio, this Aspose.Imaging example handles the resizing automatically.
 * 5. When a content management workflow needs to validate and downsize large JPEG images before publishing to avoid storage bloat, the provided C# program resizes any image wider than 1200 pixels and saves the result.
 */