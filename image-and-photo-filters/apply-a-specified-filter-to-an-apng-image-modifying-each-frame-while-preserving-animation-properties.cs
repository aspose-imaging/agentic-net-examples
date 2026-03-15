using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (can be passed via args or hard‑coded)
        string inputPath = args.Length > 0 ? args[0] : "input.apng";
        string outputPath = args.Length > 1 ? args[1] : "output.apng";

        // Load the existing APNG image
        using (Image image = Image.Load(inputPath))
        {
            ApngImage apng = (ApngImage)image;

            // Apply a Gaussian blur filter to each frame while keeping animation properties unchanged
            foreach (ApngFrame frame in apng.Pages)
            {
                // Apply filter to the whole frame area
                frame.Filter(frame.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            }

            // Save the modified APNG preserving its original animation settings
            apng.Save(outputPath);
        }
    }
}