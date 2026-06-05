using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input files
            string[] inputFiles = new string[]
            {
                "input1.png",
                "input2.png",
                "input3.png"
            };

            // Process each file in parallel using PLINQ
            inputFiles.AsParallel().ForAll(inputPath =>
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputPath = Path.Combine("output", Path.GetFileNameWithoutExtension(inputPath) + "_filtered.png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image, apply convolution filter, and save
                using (Image img = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)img;

                    // Simple 3x3 averaging kernel
                    double[,] kernel = new double[,]
                    {
                        { 1, 1, 1 },
                        { 1, 1, 1 },
                        { 1, 1, 1 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 3);

                    raster.Filter(raster.Bounds, filterOptions);
                    raster.Save(outputPath);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑process thousands of PNG product photos with a 3×3 averaging kernel before uploading them to an e‑commerce site, a thread‑safe ConvolutionFilter allows the PLINQ parallel loop to run without corrupting image data.
 * 2. When an image‑analysis pipeline must preprocess a large collection of satellite JPEG tiles in parallel to accelerate terrain classification, ensuring the ConvolutionFilter instance is thread‑safe prevents race conditions during raster filtering.
 * 3. When a medical‑imaging application generates filtered DICOM slices on multiple CPU cores to improve visual clarity for radiologists, using a thread‑safe ConvolutionFilter guarantees each slice is processed correctly without pixel artifacts.
 * 4. When an automated content‑management system creates filtered thumbnails for user‑uploaded GIF and BMP files concurrently, thread safety of the ConvolutionFilter ensures every thumbnail is rendered accurately.
 * 5. When a computer‑vision training workflow applies the same convolution kernel to thousands of PNG training images in parallel, a thread‑safe ConvolutionFilter provides consistent preprocessing across all threads.
 */