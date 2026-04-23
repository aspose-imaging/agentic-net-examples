using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputDir = "output_pages";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page PNG (APNG)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to multipage interface
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The loaded image does not contain multiple pages.");
                    return;
                }

                // Define motion blur angles for each page (example: 0°, 45°, 90°, 135°, repeat if more pages)
                double[] angles = new double[] { 0.0, 45.0, 90.0, 135.0 };

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Retrieve the page as a raster image
                    RasterImage page = (RasterImage)multipage.Pages[i];

                    // Determine angle for this page
                    double angle = angles[i % angles.Length];

                    // Apply motion blur (MotionWienerFilterOptions) with chosen angle
                    var motionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, angle);
                    page.Filter(page.Bounds, motionOptions);

                    // Prepare output file path for this page
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");

                    // Ensure directory exists (already created above, but follow safety rule)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the modified page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}