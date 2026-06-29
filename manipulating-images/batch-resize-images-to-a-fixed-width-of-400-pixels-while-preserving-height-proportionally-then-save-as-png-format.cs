using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory);

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output file path (same name, .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, resize width to 400 pixels proportionally, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    // Resize width proportionally while preserving aspect ratio
                    image.ResizeWidthProportionally(400, ResizeType.HighQualityResample);

                    // Save the resized image in PNG format
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a web application must generate thumbnail previews of user‑uploaded JPEG or BMP files by resizing them to a fixed width of 400 px while keeping the original aspect ratio and storing the results as PNGs for fast loading.
 * 2. When an e‑commerce platform needs to prepare product images for a mobile catalog by batch processing a folder of mixed‑format pictures, scaling each to 400 px wide and converting them to lossless PNG to ensure consistent display across devices.
 * 3. When a digital asset management system has to automate the conversion of legacy scanned documents (TIFF, GIF) into web‑friendly PNG thumbnails of 400 px width without distorting the original proportions.
 * 4. When a content‑management workflow requires nightly processing of a directory of marketing graphics, resizing each image to a uniform 400 px width using high‑quality resampling and saving them as PNG for inclusion in newsletters.
 * 5. When a desktop utility built with C# and Aspose.Imaging must clean up a folder of assorted image files by batch resizing them to a standard 400 px width, preserving aspect ratio, and outputting PNG files for archival or further processing.
 */