using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input PNG files
            string[] inputPaths = {
                @"C:\Images\blur1.png",
                @"C:\Images\blur2.png"
            };

            // Hard‑coded output directory
            string outputDirectory = @"C:\Images\Restored";

            foreach (string inputPath in inputPaths)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_restored.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image, apply deconvolution, and save the result
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    // Use MotionWienerFilterOptions with typical default parameters
                    var deconvOptions = new MotionWienerFilterOptions(5, 1.0, 0.0);

                    raster.Filter(raster.Bounds, deconvOptions);
                    raster.Save(outputPath);
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
 * 1. When a developer needs to automatically sharpen a collection of motion‑blurred PNG photographs taken by a security camera, they can use this C# code with Aspose.Imaging to batch apply deconvolution and save restored images.
 * 2. When a web application must preprocess user‑uploaded PNG scans of old documents that appear blurry, the code can run server‑side to deconvolve each file and store clearer versions for OCR.
 * 3. When a digital asset management system requires periodic enhancement of archived PNG graphics that suffered from lens shake, the batch deconvolution routine provides a quick C# solution to improve visual quality.
 * 4. When a scientific imaging workflow needs to correct motion blur in PNG microscopy images before analysis, developers can integrate this Aspose.Imaging filter loop to produce restored files automatically.
 * 5. When an e‑commerce platform wants to improve product PNG images that were unintentionally blurred during batch export, the code can deconvolve and overwrite them in a designated folder with higher‑definition copies.
 */