using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

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
 * 1. When a developer needs to display Windows Metafile (EMF) graphics on web pages that only support raster images, they can use this C# code to convert the EMF to a PNG file with a white background.
 * 2. When an automated reporting system generates charts as EMF files but the final PDF or email requires PNG images, the code provides a reliable way to rasterize the vector graphics and save them as PNG.
 * 3. When a desktop application must archive vector drawings from legacy engineering tools into a lossless PNG format for long‑term storage, this snippet shows how to load the EMF and save it with Aspose.Imaging.
 * 4. When a batch processing job needs to convert a folder of EMF icons into PNG thumbnails for a mobile app, the code demonstrates the necessary rasterization options and file handling in C#.
 * 5. When a CI/CD pipeline validates that all vector assets are correctly rendered before deployment, developers can integrate this code to programmatically convert EMF files to PNG and verify the output size and background color.
 */