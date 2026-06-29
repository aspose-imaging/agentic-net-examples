using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        // List of PNG files to process (without path)
        string[] files = new[]
        {
            "lowlight1.png",
            "lowlight2.png",
            "lowlight3.png"
        };

        try
        {
            foreach (string fileName in files)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".MotionWiener.png");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Motion Wiener filter to the whole image
                    // Parameters: size = 10, sigma = 1.0, angle = 90.0 degrees
                    var options = new MotionWienerFilterOptions(10, 1.0, 90.0);
                    rasterImage.Filter(rasterImage.Bounds, options);

                    // Save the processed image
                    rasterImage.Save(outputPath);
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
 * 1. When a security system stores low‑light PNG snapshots of a parking lot and needs to batch‑process them in C# to remove motion blur using a motion‑Wiener filter before archiving.
 * 2. When a wildlife research project captures night‑time PNG images of animals and wants to automatically reduce motion artifacts across dozens of files using Aspose.Imaging’s MotionWienerFilterOptions in a .NET batch job.
 * 3. When an e‑commerce platform receives user‑uploaded product photos taken in dim lighting and must apply a motion‑Wiener filter to each PNG on the server to improve visual quality before publishing.
 * 4. When a mobile app backend processes low‑light PNG screenshots from users, applying a motion‑Wiener filter in a C# loop to enhance readability of text and details for OCR preprocessing.
 * 5. When a forensic analysis tool needs to clean up a series of low‑light PNG evidence images by batch applying a motion‑Wiener filter in .NET to reduce camera shake before further examination.
 */