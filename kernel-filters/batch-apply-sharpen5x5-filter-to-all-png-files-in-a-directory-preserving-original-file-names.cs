using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
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
 * 1. When a developer needs to automatically enhance the sharpness of a large collection of PNG assets—such as product photos for an e‑commerce site—before uploading them to a web server, they can use this code to apply a 5×5 sharpen filter to every file while keeping the original filenames.
 * 2. When a desktop application must prepare user‑generated PNG screenshots for printing by improving edge definition in bulk, the batch Sharpen5x5 routine lets the program process the entire input folder and save the sharpened results to an output folder.
 * 3. When a CI/CD pipeline for a game studio requires preprocessing of UI icon PNGs to ensure visual clarity on high‑resolution displays, this C# script can be integrated to run the SharpenFilterOptions on all icons without manual intervention.
 * 4. When a content management system needs to periodically re‑sharpen archived PNG illustrations after a format conversion, the code provides a simple way to scan a directory, apply the 5×5 sharpen filter, and overwrite the files with the same names in a separate folder.
 * 5. When a developer is building a batch image‑processing tool that must preserve the original file naming scheme while improving the detail of PNG graphics for a marketing campaign, the Aspose.Imaging Sharpen5x5 filter loop fulfills that requirement.
 */