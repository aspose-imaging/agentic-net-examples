using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input folder and list of EMF files
            string inputFolder = @"C:\Images\Input";
            string[] emfFiles = new[]
            {
                "image1.emf",
                "image2.emf",
                "image3.emf"
            };

            // Hardcoded output folder
            string outputFolder = @"C:\Images\Output";

            foreach (var fileName in emfFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputFolder, fileName);
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(fileName) + ".png");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Measure processing time
                Stopwatch sw = Stopwatch.StartNew();

                // Load EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to EmfImage to access vector-specific methods
                    EmfImage emfImage = (EmfImage)image;

                    // Remove background (default removes any background)
                    emfImage.RemoveBackground();

                    // Prepare PNG save options with rasterization settings
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            // Set background color for rasterization (optional, can be transparent)
                            BackgroundColor = Aspose.Imaging.Color.White,
                            // Use original image size
                            PageSize = emfImage.Size
                        }
                    };

                    // Save rasterized PNG
                    emfImage.Save(outputPath, pngOptions);
                }

                sw.Stop();
                Console.WriteLine($"Processed '{fileName}' in {sw.ElapsedMilliseconds} ms. Output: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}