using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath);
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
 * 1. When a developer needs to programmatically copy or convert a JPEG file to another location while ensuring the destination folder exists, they can use this Aspose.Imaging code to load and save the image.
 * 2. When an automated build process must validate that a source image file is present before performing any image manipulation, this snippet provides a simple existence check and error handling.
 * 3. When a web application generates thumbnails on the fly and wants to reuse the original JPEG data without altering its quality, the code demonstrates how to load the original and save it directly.
 * 4. When a desktop utility needs to batch rename or relocate image assets while preserving the original format, the example shows how to load each file with Aspose.Imaging and write it to the new path.
 * 5. When a migration script moves image files from a legacy directory structure to a new one and must create missing directories automatically, this code illustrates the required C# file system and Aspose.Imaging operations.
 */