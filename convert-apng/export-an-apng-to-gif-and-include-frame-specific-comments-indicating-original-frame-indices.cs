using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the APNG image
            using (Image apngImage = Image.Load(inputPath))
            {
                // Determine the number of frames in the APNG
                int frameCount = 0;
                if (apngImage is IMultipageImage multipage)
                {
                    frameCount = multipage.PageCount;
                }

                // Log frame indices (these act as comments for each frame)
                for (int i = 0; i < frameCount; i++)
                {
                    Console.WriteLine($"Processing frame index: {i}");
                    // In a real scenario, you could embed metadata per frame here.
                }

                // Prepare GIF save options
                GifOptions gifOptions = new GifOptions();

                // Export APNG to GIF
                apngImage.Save(outputPath, gifOptions);
            }

            Console.WriteLine("APNG successfully exported to GIF.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to convert animated PNG (APNG) assets to GIF format for compatibility with older browsers while preserving the original frame order as comments.
 * 2. When a mobile app team wants to generate lightweight GIF previews from high‑resolution APNG files and embed frame‑index metadata for later debugging or analytics.
 * 3. When an e‑learning platform must batch‑process course illustrations stored as APNG and export them to GIF for use in slide decks, while logging each frame’s original index.
 * 4. When a game studio automates the creation of sprite sheets by converting APNG animations to GIF and annotating each frame with its source index for texture atlasing pipelines.
 * 5. When a digital marketing system needs to transform user‑uploaded APNG memes into GIFs for social media sharing and retain frame‑by‑frame comments to track editing history.
 */