using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.jpg");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up JPEG save options with vector rasterization
                var jpegOptions = new JpegOptions();
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                jpegOptions.VectorRasterizationOptions = vectorOptions;

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to generate a JPEG preview of an ODG diagram for a web gallery using Aspose.Imaging for .NET, this code loads the ODG file and saves it as a JPEG with default compression.
 * 2. When an application must batch‑convert OpenDocument Graphics files into JPEG assets for email attachments, the snippet demonstrates the C# workflow to rasterize the vector content and write the output image.
 * 3. When a reporting tool requires embedding ODG charts as JPEG images in PDF reports, the code shows how to load the ODG, apply vector rasterization options, and export to JPEG with standard settings.
 * 4. When a content‑management system needs to store a lightweight JPEG version of user‑uploaded ODG files for thumbnail caching, this example illustrates the necessary file‑existence checks and directory creation in C#.
 * 5. When a developer is building a migration script that moves legacy ODG artwork to a JPEG‑based asset pipeline, the program provides a simple way to read the ODG, rasterize it, and save it using Aspose.Imaging’s default JPEG compression.
 */