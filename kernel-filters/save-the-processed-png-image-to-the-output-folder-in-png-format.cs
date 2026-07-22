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
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG using default options
                PngOptions pngOptions = new PngOptions();
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
 * 1. When a developer needs to convert a JPEG photograph to a lossless PNG for web display or archival, they can use this code to load the JPEG and save it as PNG in a specified folder.
 * 2. When an application must ensure that all uploaded images are stored in a consistent PNG format before further processing, this snippet validates the source file and writes the PNG output using Aspose.Imaging.
 * 3. When a batch job processes images from a legacy system and requires creating PNG thumbnails for a mobile app, the code demonstrates loading the original image and saving it with default PNG options.
 * 4. When a developer wants to programmatically generate PNG assets for a reporting tool and needs to guarantee the output directory exists, the example shows directory creation and error handling while saving the image.
 * 5. When integrating image conversion into a C# service that receives JPEG files and must deliver PNG files to downstream services, this example provides a simple, exception‑safe way to perform the conversion using Aspose.Imaging.ImageOptions.
 */