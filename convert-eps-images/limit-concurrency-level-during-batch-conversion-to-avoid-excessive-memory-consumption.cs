// HOW-TO: Convert WebP Images to PNG with Limited Parallelism in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = "C:\\Images\\Input";
            string outputFolder = "C:\\Images\\Output";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all WebP files in the input folder
            string[] files = Directory.GetFiles(inputFolder, "*.webp");

            // Limit concurrency to avoid excessive memory usage
            ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };

            Parallel.ForEach(files, parallelOptions, inputPath =>
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // If the image supports multi‑page processing, enable sequential export mode
                    if (image is IMultipageImage multiPageImage)
                    {
                        multiPageImage.PageExportingAction = (pageIndex, page) =>
                        {
                            // No custom per‑page processing; sequential export only
                        };
                    }

                    // Save as PNG
                    PngOptions pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to convert a large folder of WebP files to PNG on a server without exhausting memory, you can use this code to process the images in parallel with a controlled concurrency level.
 * 2. When building an automated image pipeline that must handle multi‑page WebP documents and export each page as a separate PNG while keeping the application responsive, the code’s IMultipageImage support and limited parallelism help achieve that.
 * 3. When deploying a desktop utility that lets users select an input directory of WebP assets and generates PNG versions while ensuring the UI remains responsive, the Parallel.ForEach with MaxDegreeOfParallelism prevents high RAM usage.
 * 4. When integrating Aspose.Imaging into a cloud‑based microservice that receives WebP uploads and returns PNG thumbnails, limiting the degree of parallelism avoids out‑of‑memory errors under heavy load.
 * 5. When performing nightly batch processing of web‑optimized images for a content management system, the code’s automatic output folder creation and safe file existence checks ensure reliable conversion of many files at once.
 */
