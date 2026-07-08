using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.jpg";

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

            Image image = null;
            try
            {
                // Load the image
                image = Image.Load(inputPath);

                // ----- Begin filter application -----
                // Example: convert to grayscale (placeholder for actual filter logic)
                // The actual filter code would depend on the specific Aspose.Imaging API.
                // For demonstration, we simply leave the image unchanged.
                // ----- End filter application -----

                // Save the processed image
                image.Save(outputPath);
            }
            finally
            {
                // Guarantee disposal of the image object
                if (image != null)
                {
                    image.Dispose();
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
 * 1. When a developer needs to apply a grayscale filter to a JPEG file and guarantee that the image object is released even if an error occurs, they can wrap Image.Load and Image.Save in a try‑finally block as shown.
 * 2. When building a C# service that converts uploaded PNG images to a different format (e.g., BMP) and must create the target folder on‑the‑fly, the pattern ensures the directory is created and the image resources are disposed correctly.
 * 3. When processing a large batch of high‑resolution TIFF files and want to avoid memory leaks, using the nested try‑finally structure guarantees each Image instance is disposed after the filter operation before moving to the next file.
 * 4. When implementing error‑resilient image watermarking in an ASP.NET application, the code checks for the source file, creates the output path, and uses finally to clean up the Image object regardless of exceptions.
 * 5. When writing a console utility that reads a user‑specified JPEG, applies any custom Aspose.Imaging filter (such as contrast adjustment), and saves the result while handling missing files and ensuring proper disposal, this try‑finally approach provides a reliable solution.
 */