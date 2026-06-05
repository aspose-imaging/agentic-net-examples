using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.png");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    var filterOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5);
                    raster.Filter(raster.Bounds, filterOptions);
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
 * 1. When a developer needs to automatically add a 3‑D emboss effect to every PNG asset in a folder before publishing a web gallery, they can use this code to batch‑process the images with Aspose.Imaging’s Emboss5x5 filter.
 * 2. When a CI/CD pipeline must generate stylized preview thumbnails for PNG icons stored in a repository, the script can be integrated to apply the Emboss5x5 convolution filter to all files in the source directory.
 * 3. When a desktop application requires preprocessing of user‑uploaded PNG screenshots to enhance edge contrast for OCR accuracy, the code provides a fast way to apply the emboss filter to each image in bulk.
 * 4. When a game developer wants to create a consistent embossed texture set from a collection of PNG sprites without manually editing each file, this solution iterates through the directory and saves the filtered results automatically.
 * 5. When a marketing team needs to produce a batch of embossed PNG product images for a promotional catalog, the program can be run by a non‑technical user to transform all files in the input folder with a single command.
 */