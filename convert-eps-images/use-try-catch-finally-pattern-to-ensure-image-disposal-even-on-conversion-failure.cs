using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            Image image = null;
            try
            {
                // Load the source image
                image = Image.Load(inputPath);

                // Save the image in PNG format
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
            finally
            {
                // Ensure the image is disposed even if saving fails
                if (image != null)
                {
                    image.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            // Report any errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must convert user‑uploaded JPEG photos to PNG for web display while guaranteeing that the Image object is released even if the conversion fails.
 * 2. When an automated batch job processes a directory of images, checking for file existence and creating output folders before safely converting each JPG to PNG without leaking memory.
 * 3. When a desktop utility allows users to select a source image and export it in a different format, using try‑catch‑finally to handle errors and ensure the image stream is disposed.
 * 4. When a server‑side service receives image paths, validates them, and needs to convert the files while handling IO exceptions and guaranteeing cleanup of the Aspose.Imaging Image instance.
 * 5. When integrating Aspose.Imaging into a CI/CD pipeline that transforms test screenshots from JPEG to PNG, employing nested try‑catch‑finally to report conversion issues without crashing the build.
 */