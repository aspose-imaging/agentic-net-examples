using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputDir = "frames";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Cast to multipage interface to access frames
                IMultipageImage multipage = webPImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage WebP.");
                    return;
                }

                int pageCount = multipage.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    // Retrieve the frame and cast to RasterImage
                    var frame = multipage.Pages[i];
                    using (RasterImage raster = (RasterImage)frame)
                    {
                        // Build output path for the current frame
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as BMP
                        raster.Save(outputPath, new BmpOptions());
                    }
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
 * 1. When a developer needs to convert an animated WebP advertisement into separate BMP frames for legacy Windows applications that only support BMP format.
 * 2. When a developer wants to extract each page of a multi‑page WebP document to generate thumbnail previews in a C# desktop tool.
 * 3. When a developer must preprocess animated WebP assets for a machine‑learning pipeline that requires BMP input images.
 * 4. When a developer is building a batch‑processing script that archives every frame of a WebP animation as individual BMP files for compliance auditing.
 * 5. When a developer needs to isolate and save individual frames from a WebP sprite sheet to edit them in a graphics editor that only reads BMP format.
 */