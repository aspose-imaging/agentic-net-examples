using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Lazy‑load the image – it will be loaded only when the filter is applied
            Lazy<Image> lazyImage = new Lazy<Image>(() => Image.Load(inputPath));

            // Apply a simple processing step (e.g., convert to PNG) after the image is loaded
            using (Image image = lazyImage.Value)
            {
                // Example processing: no modification, just demonstrate lazy loading
                // Additional processing (e.g., grayscale) could be added here

                // Save the image using PNG options
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When processing large batches of high‑resolution JPEG photos and you want to defer loading each image until you actually apply a conversion to PNG, reducing memory usage.
 * 2. When building a web service that receives image paths and only needs to load the file if a client requests a transformation such as grayscale or format conversion, using Lazy<Image> to avoid unnecessary I/O.
 * 3. When implementing a background job that scans a directory for images but should only read each file when it is time to apply a watermark or other filter, leveraging lazy loading to improve throughput.
 * 4. When creating a desktop application that previews thumbnails of images stored on disk and only loads the full image data when the user selects a file for editing or export to PNG.
 * 5. When integrating Aspose.Imaging into a CI/CD pipeline that validates image assets and converts them to PNG only if they meet certain criteria, using lazy loading to skip loading files that fail early checks.
 */