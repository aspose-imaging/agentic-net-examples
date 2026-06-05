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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and guarantee disposal with try‑finally
            Image image = null;
            try
            {
                image = Image.Load(inputPath);

                // ----- Begin filter application -----
                // Example: convert to grayscale (placeholder for actual filter logic)
                // if (image is RasterImage raster)
                // {
                //     raster.Grayscale();
                // }
                // ----- End filter application -----

                // Save the processed image
                image.Save(outputPath);
            }
            finally
            {
                // Ensure the image is disposed even if an exception occurs
                if (image != null)
                {
                    image.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# developer needs to load a JPEG file, apply a grayscale filter using Aspose.Imaging, and guarantee that the Image object is disposed even if an error occurs.
 * 2. When an automated batch job must convert a collection of input images to another format such as PNG while ensuring resources are released with a try‑finally block.
 * 3. When building a web service that receives user‑uploaded images, processes them (e.g., resizing or color adjustment), and must prevent memory leaks by disposing the Image instance in the finally clause.
 * 4. When creating a desktop utility that validates the existence of source files, creates the output directory, and safely saves the processed image without leaving file handles open.
 * 5. When integrating Aspose.Imaging into a CI/CD pipeline to run image quality checks and apply filters, and you need robust error handling that logs exceptions and always disposes the Image object.
 */