using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Preserve original file name for the output
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDir, fileName);

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply the 5x5 sharpen filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
                    rasterImage.Save(outputPath);
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
 * 1. When a developer needs to batch‑sharpen a collection of PNG assets for a website, applying Aspose.Imaging’s 5×5 sharpen filter while preserving the original file names.
 * 2. When an e‑commerce platform must automatically enhance product photos stored as PNGs before publishing, using C# to process the entire folder and save the sharpened versions with the same names.
 * 3. When a digital archivist wants to improve the clarity of scanned PNG documents in bulk without altering their naming convention, leveraging Aspose.Imaging’s RasterImage filter in a .NET application.
 * 4. When a game developer prepares sprite sheets in PNG format and requires a quick script to apply a 5×5 sharpening effect to all files in a directory, preserving the original file names for asset pipelines.
 * 5. When a content management system needs to generate sharpened thumbnails from PNG uploads on the fly, processing the whole input folder with Aspose.Imaging and writing the results to an output folder using the same filenames.
 */